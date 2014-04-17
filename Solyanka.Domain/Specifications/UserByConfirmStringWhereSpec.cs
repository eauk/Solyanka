using System;
using System.Linq.Expressions;
using Solyanka.Domain.Core.WhereSpec;
using Solyanka.Domain.Persistance;

namespace Solyanka.Domain.Specifications
{
    public class UserByConfirmStringWhereSpec : Specification<User>
    {
        #region Fields

        readonly string _confirmString;

        #endregion

        #region Constructors

        public UserByConfirmStringWhereSpec(string confirmString)
        {
            this._confirmString = confirmString;
        }

        #endregion

        #region Override

        public override Expression<Func<User, bool>> IsSatisfiedBy()
        {
            return user => user.ConfirmString == this._confirmString;
        }

        #endregion
    }
}