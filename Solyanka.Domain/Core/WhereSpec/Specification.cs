﻿using System;
using System.Linq.Expressions;

namespace Solyanka.Domain.Core.WhereSpec
{
    [Serializable]
    public abstract class Specification<T>
    {
        #region Api Methods

        public abstract Expression<Func<T, bool>> IsSatisfiedBy();

        #endregion

        public static Specification<T> operator &(Specification<T> spec1, Specification<T> spec2)
        {
            return new AndSpecification<T>(spec1, spec2);
        }

        public static bool operator false(Specification<T> spec1)
        {
            return false;
        }

        public static bool operator true(Specification<T> spec1)
        {
            return false;
        }

        public static Specification<T> operator |(Specification<T> spec1, Specification<T> spec2)
        {
            return new OrSpecification<T>(spec1, spec2);
        }

        public static Specification<T> operator !(Specification<T> spec1)
        {
            return new NegateSpecification<T>(spec1);
        }
    }
}