using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionGraphDrawing
{
    /// <summary>
    /// 函数语法树节点
    /// </summary>
    class SyntaxNode
    {
        /// <summary>
        /// 常数值（NodeType为SyntaxNodeType.Const时有效）
        /// </summary>
        public double ConstantValue
        {
            get;
            set;
        }
        /// <summary>
        /// 节点类型
        /// </summary>
        public SyntaxNodeType NodeType
        {
            get;
            set;
        }
        /// <summary>
        /// 左子节点
        /// </summary>
        public SyntaxNode Left
        {
            get;
            set;
        }
        /// <summary>
        /// 右子节点
        /// </summary>
        public SyntaxNode Right
        {
            get;
            set;
        }
        /// <summary>
        /// 根据自变量x、y、z求得该节点的值
        /// 一元函数x有效，二元函数x、y有效，三元函数x、y、z都有效
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public double GetValue(double x, double y, double z)
        {
            switch (NodeType)
            {
                case SyntaxNodeType.Abs:
                    {
                        return Math.Abs(Right.GetValue(x, y, z));
                    }
                case SyntaxNodeType.Const:
                    {
                        return ConstantValue;
                    }
                case SyntaxNodeType.Cos:
                    {
                        return Math.Cos(Right.GetValue(x, y, z));
                    }
                case SyntaxNodeType.Ctg:
                    {
                        return 1 / Math.Tan(Right.GetValue(x, y, z));
                    }
                case SyntaxNodeType.Division:
                    {
                        return Left.GetValue(x, y, z) / Right.GetValue(x, y, z);
                    }
                case SyntaxNodeType.E:
                    {
                        return Math.E;
                    }
                case SyntaxNodeType.Factorial:
                    {
                        double sum = 1;
                        double count = (int)Left.GetValue(x, y, z);
                        for (int i = 1; i <= count; ++i)
                        {
                            sum *= i;
                        }
                        return sum;
                    }
                case SyntaxNodeType.Neg:
                    {
                        return (-1) * Right.GetValue(x, y, z);
                    }
                case SyntaxNodeType.Log:
                    {
                        return Math.Log10(Right.GetValue(x, y, z));
                    }
                case SyntaxNodeType.Minus:
                    {
                        return Left.GetValue(x, y, z) - Right.GetValue(x, y, z);
                    }
                case SyntaxNodeType.Multiplication:
                    {
                        return Left.GetValue(x, y, z) * Right.GetValue(x, y, z);
                    }
                case SyntaxNodeType.PI:
                    {
                        return Math.PI;
                    }
                case SyntaxNodeType.Plus:
                    {
                        return Left.GetValue(x, y, z) + Right.GetValue(x, y, z);
                    }
                case SyntaxNodeType.Power:
                    {
                        return Math.Pow(Left.GetValue(x, y, z), Right.GetValue(x, y, z));
                    }
                case SyntaxNodeType.Sin:
                    {
                        return Math.Sin(Right.GetValue(x, y, z));
                    }
                case SyntaxNodeType.Sqrt:
                    {
                        return Math.Sqrt(Right.GetValue(x, y, z));
                    }
                case SyntaxNodeType.Tan:
                    {
                        return Math.Tan(Right.GetValue(x, y, z));
                    }
                case SyntaxNodeType.X:
                    {
                        return x;
                    }
                case SyntaxNodeType.Y:
                    {
                        return y;
                    }
                case SyntaxNodeType.Z:
                    {
                        return z;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public SyntaxNode(SyntaxNodeType type)
        {
            NodeType = type;
        }
    }
}
