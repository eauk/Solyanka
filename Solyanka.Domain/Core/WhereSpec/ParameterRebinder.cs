using System.Collections.Generic;
using System.Linq.Expressions;

namespace Solyanka.Domain.Core.WhereSpec
{
    public class ParameterRebinder : ExpressionVisitor
    {
        #region Fields

        readonly Dictionary<ParameterExpression, ParameterExpression> map;

        #endregion

        #region Constructors

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        #endregion

        #region Factory constructors

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        #endregion

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (this.map.TryGetValue(p, out replacement))
                p = replacement;
            return base.VisitParameter(p);
        }
    }
}