using System;
using System.Linq.Expressions;

namespace Solyanka.Domain.Core.WhereSpec
{
    [Serializable]
    public class AndSpecification<T> : Specification<T>
    {
        #region Fields

        readonly Specification<T> spec1;

        readonly Specification<T> spec2;

        #endregion

        #region Constructors

        public AndSpecification(Specification<T> spec1, Specification<T> spec2)
        {
            this.spec1 = spec1;
            this.spec2 = spec2;
        }

        #endregion

        public override Expression<Func<T, bool>> IsSatisfiedBy()
        {
            var expr1 = this.spec1.IsSatisfiedBy();
            var expr2 = this.spec2.IsSatisfiedBy();

            if (expr1 == null && expr2 == null)
                return null;

            if (expr1 == null)
                return expr2;
            if (expr2 == null)
                return expr1;

            return expr1.AndAlso(expr2);
        }
    }
}