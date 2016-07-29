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
                {
                    if (b.Right.NodeType == ExpressionType.Constant)
                    {
                        if ((int)((ConstantExpression)b.Right).Value == 1)
                        {
                            return Expression.MakeUnary(ExpressionType.Increment, b.Left, b.Type, b.Method);
                            
                        }
                    }
                    
                    if (b.Left.NodeType == ExpressionType.Constant)
                    {
                        if ((int)((ConstantExpression)b.Left).Value == 1)
                        {
                            return Expression.MakeUnary(ExpressionType.Increment, b.Right, b.Type, b.Method);
                        }
                    }
                }
            }

            return base.VisitBinary(b);
        }
    }
}
