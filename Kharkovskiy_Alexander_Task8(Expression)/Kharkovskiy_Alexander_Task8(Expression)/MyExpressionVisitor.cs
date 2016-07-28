using System.Linq.Expressions;

namespace Kharkovskiy_Alexander_Task8_Expression_
{
    class MyExpressionVisitor: ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b.NodeType == ExpressionType.Add)
            {
                var left = Visit(b.Left);
                var right = Visit(b.Right);
                {
                    int temp;
                    if (int.TryParse(right.ToString(), out temp) && temp == 1)
                    { 
                        return Expression.MakeUnary(ExpressionType.Increment, left, b.Type, b.Method);
                    }
                    if (int.TryParse(left.ToString(), out temp) && temp == 1)
                    {
                        return Expression.MakeUnary(ExpressionType.Increment, right, b.Type, b.Method);
                    }
                }
            }

            return base.VisitBinary(b);
        }
    }
}
