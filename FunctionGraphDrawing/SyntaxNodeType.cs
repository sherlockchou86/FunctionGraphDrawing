using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionGraphDrawing
{
    /// <summary>
    /// 函数语法树 节点类型
    /// 每个枚举值的位置不要轻易改动！
    /// </summary>
    enum SyntaxNodeType
    {
        X=0,  //x自变量
        Y,  //y自变量
        Z,  //z自变量
        PI, //常数π
        E,  //常数e
        Const,    //常数
        Minus, //-
        Plus,  //+
        Multiplication,  //*
        Division,  // /
        Neg,  //负号
        Power, //^
        Sin, //sin函数
        Cos, //cos函数
        Tan,  //tan函数
        Ctg, //ctg函数
        Sqrt,  //开方
        Log, //log  默认以10为底数  求log(3)10 == log(10)/log(3)
        Abs, //绝对值
        Factorial, //阶乘
        LeftBracket,  //左括号
        RightBracket,  //右括号
    }
}
