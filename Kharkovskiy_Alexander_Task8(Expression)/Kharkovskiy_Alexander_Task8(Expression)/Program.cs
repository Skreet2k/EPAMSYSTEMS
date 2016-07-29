using System;
using System.Linq.Expressions;


namespace Kharkovskiy_Alexander_Task8_Expression_
{
    class Program
    {
        static void Main()
        {
            Expression<Func<int, int>> expr = a => a + 1;
            Console.WriteLine($"{expr} при a = 5 дал результат: {expr.Compile().Invoke(5)}");

            var treeModifier = new MyExpressionVisitor();
            var modifiedExpr = treeModifier.Modify(expr);

            Console.WriteLine($"{modifiedExpr} при a = 5 дал результат: {expr.Compile().Invoke(5)}");

            Expression<Func<int, int>> expr2 = b => 1 + b;
            Console.WriteLine($"{expr2} при b = 5 дал результат: {expr2.Compile().Invoke(5)}");
            var modifiedExpr2 = treeModifier.Modify(expr2);
            Console.WriteLine($"{modifiedExpr2} при b = 5 дал результат: {expr2.Compile().Invoke(5)}");

            var a1 = Expression.Parameter(typeof(double), "a");
            var b1 = Expression.Parameter(typeof(double), "b");
            // Формула для подсчета среднего двух чисел:
            var expr3 = Expression.Lambda(
                Expression.Divide(
                    Expression.Add(a1, b1),
                    Expression.Constant(2.0)), a1, b1);
            Console.WriteLine($"{expr3} при a = 5 и b = 6 дал результат: {expr3.Compile().DynamicInvoke(5, 6)}");
            Console.Read();
        }
    }
}
