using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionGraphDrawing
{
    /// <summary>
    /// 函数语法树管理类
    /// 提供函数表达式解析、求值等功能
    /// </summary>
    class SyntaxManager
    {
        //运算符
        static List<SyntaxNodeType> list_operations = new List<SyntaxNodeType> {SyntaxNodeType.Plus,SyntaxNodeType.Minus,SyntaxNodeType.Multiplication,SyntaxNodeType.Division
        ,SyntaxNodeType.Power,SyntaxNodeType.Sin,SyntaxNodeType.Cos,SyntaxNodeType.Tan,SyntaxNodeType.Ctg,SyntaxNodeType.Log,SyntaxNodeType.Abs
        ,SyntaxNodeType.Sqrt,SyntaxNodeType.Factorial,SyntaxNodeType.Neg};
        /// <summary>
        /// 解析一元函数
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public UnaryFunction ParseUnaryFunction(string function)
        {
            List<SyntaxNode> list = CreateNodesList(function);
            SyntaxNode root = CreateSyntaxTree(list);

            return (UnaryFunction)((double x) => { return root.GetValue(x, 0, 0); });
        }
        /// <summary>
        /// 解析二元函数
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public BinaryFunction ParseBinaryFunction(string function)
        {
            List<SyntaxNode> list = CreateNodesList(function);
            SyntaxNode root = CreateSyntaxTree(list);

            return (BinaryFunction)((double x, double y) => { return root.GetValue(x, y, 0); });
        }
        /// <summary>
        /// 解析三元函数
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public MultiFunction ParseMultiFunction(string function)
        {
            List<SyntaxNode> list = CreateNodesList(function);
            SyntaxNode root = CreateSyntaxTree(list);

            return (MultiFunction)((double x, double y, double z) => { return root.GetValue(x, y, z); });
        }
        /// <summary>
        /// 根据函数表达式 构建节点集合
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        private List<SyntaxNode> CreateNodesList(string function)
        {
            List<SyntaxNode> listNode = new List<SyntaxNode>();
            function = function.ToLower();
            for (int i = 0; i < function.Length; i++)
            {
                if (function[i] == 'π')
                {
                    SyntaxNode pi = new SyntaxNode(SyntaxNodeType.PI);
                    listNode.Add(pi);
                }
                if (function[i] == 'e')
                {
                    SyntaxNode e = new SyntaxNode(SyntaxNodeType.E);
                    listNode.Add(e);
                }

                if (function[i] == 'x')
                {
                    SyntaxNode x = new SyntaxNode(SyntaxNodeType.X);
                    listNode.Add(x);
                }
                if (function[i] == 'y')
                {
                    SyntaxNode y = new SyntaxNode(SyntaxNodeType.Y);
                    listNode.Add(y);
                }
                if (function[i] == 'z')
                {
                    SyntaxNode z = new SyntaxNode(SyntaxNodeType.Z);
                    listNode.Add(z);
                }
                if (Char.IsNumber(function[i]))
                {
                    SyntaxNode cons = ReadConst(function, i, out i);
                    listNode.Add(cons);
                }
                if (function[i] == '-')
                {
                    if (i == 0 || function[i - 1] == '(' || function[i + 1] == '(')
                    {
                        SyntaxNode neg = new SyntaxNode(SyntaxNodeType.Neg);
                        listNode.Add(neg);
                        continue;
                    }
                }
                if (function[i] == '+' || function[i] == '-' || function[i] == '*' || function[i] == '/' || function[i] == '^')
                {
                    SyntaxNode op = ReadOperation(function, i, out i);
                    listNode.Add(op);
                }
                if (function[i] == '(')
                {
                    SyntaxNode lb = new SyntaxNode(SyntaxNodeType.LeftBracket);
                    listNode.Add(lb);
                }
                if (function[i] == ')')
                {
                    SyntaxNode rb = new SyntaxNode(SyntaxNodeType.RightBracket);
                    listNode.Add(rb);
                }
                if (function[i] == '!')
                {
                    SyntaxNode f = new SyntaxNode(SyntaxNodeType.Factorial);
                    listNode.Add(f);
                }
                if (function[i] == 's' || function[i] == 'c' || function[i] == 't' ||
                    function[i] == 'l' || function[i] == 'a')
                {
                    SyntaxNode func = ReadFunction(function, i, out i);
                    listNode.Add(func);
                }
            }
            return listNode;
        }
        /// <summary>
        /// 根据节点集合 创建函数语法树
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private SyntaxNode CreateSyntaxTree(List<SyntaxNode> nodes)
        {
            RemoveBrackets(nodes);
            if (nodes.Count == 1) return nodes[0];

            int position;
            SyntaxNode min = GetMinPriorOperation(nodes, out position);
            if (position == 0 && list_operations.Contains(min.NodeType))
            {
                min.Right = CreateSyntaxTree(nodes.GetRange(position + 1, nodes.Count - (position + 1)));
            }
            else if (position == nodes.Count - 1 && list_operations.Contains(min.NodeType))
            {
                min.Left = CreateSyntaxTree(nodes.GetRange(0, position));
            }
            else if (position > 0 && list_operations.Contains(min.NodeType))
            {
                min.Left = CreateSyntaxTree(nodes.GetRange(0, position));
                min.Right = CreateSyntaxTree(nodes.GetRange(position + 1, nodes.Count - (position + 1)));
            }
            return min;
        }
        /// <summary>
        /// 移出表达式中的（左右）括号
        /// </summary>
        /// <param name="listNode"></param>
        private void RemoveBrackets(List<SyntaxNode> listNode)
        {
            if (listNode.Count == 1) return;
            int countMinBracket = listNode.Count;
            int countLeftBracket = 0;
            int countRightBracket = 0;
            for (int i = 0; i < listNode.Count; i++)
            {
                if (listNode[i].NodeType  != SyntaxNodeType.LeftBracket && listNode[i].NodeType != SyntaxNodeType.RightBracket)
                {
                    countLeftBracket = 0;
                    countRightBracket = 0;
                    for (int k = i + 1; k < listNode.Count; k++)
                    {
                        if (listNode[k].NodeType == SyntaxNodeType.LeftBracket) countLeftBracket++;
                        if (listNode[k].NodeType == SyntaxNodeType.RightBracket) countRightBracket++;
                    }
                    int countBracket = Math.Abs(countLeftBracket - countRightBracket);
                    if (countBracket < countMinBracket) countMinBracket = countBracket;
                }
            }
            listNode.RemoveRange(0, countMinBracket);
            listNode.RemoveRange(listNode.Count - countMinBracket, countMinBracket);
        }
        /// <summary>
        /// 查找优先级最低的节点
        /// </summary>
        /// <param name="listNode"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private SyntaxNode GetMinPriorOperation(List<SyntaxNode> listNode, out int position)
        {
            SyntaxNode min = null;
            int countMinOperationBrachet = 0;
            int countLeftBracket = 0;
            int countRightBracket = 0;
            position = 0;
            for (int i = 0; i < listNode.Count; i++)
            {
                if (listNode[i].NodeType == SyntaxNodeType.LeftBracket) countLeftBracket++;
                if (listNode[i].NodeType == SyntaxNodeType.RightBracket) countRightBracket++;
                if (list_operations.Contains(listNode[i].NodeType))
                {
                    if (min == null)
                    {
                        min = listNode[i];
                        position = i;
                        countMinOperationBrachet = countLeftBracket - countRightBracket;
                        continue;
                    }
                    if (CompareOperations(min, listNode[i], countMinOperationBrachet, countLeftBracket - countRightBracket) == -1)
                    {
                        min = listNode[i];
                        position = i;
                        countMinOperationBrachet = countLeftBracket - countRightBracket;
                    }
                }
            }
            return min;
        }
        /// <summary>
        /// 判断运算符优先级
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="aBracket"></param>
        /// <param name="bBracket"></param>
        /// <returns></returns>
        private int CompareOperations(SyntaxNode a, SyntaxNode b, int aBracket, int bBracket)
        {
            if (aBracket < bBracket) return 1;
            if (aBracket > bBracket) return -1;
            if (a.NodeType < b.NodeType) return 1;
            if (a.NodeType > b.NodeType) return -1;
            return 0;
        }
        /// <summary>
        /// 从函数表达式中解析出常用函数 sin cos等
        /// </summary>
        /// <param name="function"></param>
        /// <param name="first"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private SyntaxNode ReadFunction(string function, int first, out int index)
        {
            index = first;
            if (function.Substring(first, 3).ToLower() == "sin")
            {
                index = first + 2;
                return new SyntaxNode(SyntaxNodeType.Sin);
            }

            if (function.Substring(first, 3).ToLower() == "cos")
            {
                index = first + 2;
                return new SyntaxNode(SyntaxNodeType.Cos);
            }

            if (function.Substring(first, 3).ToLower() == "tan")
            {
                index = first + 2;
                return new SyntaxNode(SyntaxNodeType.Tan);
            }

            if (function.Substring(first, 3).ToLower() == "ctg")
            {
                index = first + 2;
                return new SyntaxNode(SyntaxNodeType.Ctg);
            }

            if (function.Substring(first, 3).ToLower() == "log")
            {
                index = first + 2;
                return new SyntaxNode(SyntaxNodeType.Log);
            }

            if (function.Substring(first, 3).ToLower() == "abs")
            {
                index = first + 2;
                return new SyntaxNode(SyntaxNodeType.Abs);
            }
            if (function.Substring(first, 4).ToLower() == "sqrt")
            {
                index = first + 3;
                return new SyntaxNode(SyntaxNodeType.Sqrt);
            }
            return null;
        }
        /// <summary>
        /// 从函数表达式中解析出运算符
        /// </summary>
        /// <param name="function"></param>
        /// <param name="first"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private SyntaxNode ReadOperation(string function, int first, out int index)
        {
            index = first;
            if (function[first] == '+') return new SyntaxNode(SyntaxNodeType.Plus);
            if (function[first] == '-') return new SyntaxNode(SyntaxNodeType.Minus);
            if (function[first] == '*') return new SyntaxNode(SyntaxNodeType.Multiplication);
            if (function[first] == '/') return new SyntaxNode(SyntaxNodeType.Division);
            if (function[first] == '^') return new SyntaxNode(SyntaxNodeType.Power);
            return null;
        }
        /// <summary>
        /// 从函数表达式中解析出常数
        /// </summary>
        /// <param name="function"></param>
        /// <param name="first"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private SyntaxNode ReadConst(string function, int first, out int index)
        {
            string var = "";
            for (int i = first;
                i < function.Length && (Char.IsNumber(function[i]) || function[i] == '.'); i++)
            {
                if (function[i] == '.') var += ',';
                else var += function[i];
            }
            index = first + var.Length - 1;
            SyntaxNode const_node = new SyntaxNode(SyntaxNodeType.Const);
            const_node.ConstantValue = Convert.ToDouble(var);
            return const_node;
        }
    }
    /// <summary>
    /// 一元函数
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public delegate double UnaryFunction(double x);
    /// <summary>
    /// 二元函数
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public delegate double BinaryFunction(double x,double y);
    /// <summary>
    /// 三元函数
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public delegate double MultiFunction(double x,double y,double z);
}
