namespace Solyanka.Domain.Core.WhereSpec
{
    public static class SpecificationExtensions
    {
        #region Factory constructors

        public static Specification<T> And<T>(this Specification<T> first, Specification<T> second)
        {
            return first & second;
        }

        public static Specification<T> Or<T>(this Specification<T> first, Specification<T> second)
        {
            return first | second;
        }

        #endregion
    }
}