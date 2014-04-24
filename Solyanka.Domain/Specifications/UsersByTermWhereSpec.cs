using System;
using System.Linq.Expressions;
using Solyanka.Domain.Core.WhereSpec;
using Solyanka.Domain.Persistance;

namespace Solyanka.Domain.Specifications
{
    public class UsersByTermWhereSpec : Specification<User>
    {
        #region Fields

        readonly string _term;

        #endregion

        #region Constructors

        public UsersByTermWhereSpec(string term)
        {
            this._term = term;
        }

        #endregion

        #region Override

        public override Expression<Func<User, bool>> IsSatisfiedBy()
        {
            return user => user.Name.Contains(_term);
        }

        #endregion
    }
}