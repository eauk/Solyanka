using System;
using System.Linq.Expressions;
using Solyanka.Domain.Core.WhereSpec;
using Solyanka.Domain.Persistance;

namespace Solyanka.Domain.Specifications
{
    public class UserByEmailWhereSpec : Specification<User>
    {
        #region Fields

        readonly string _email;

        #endregion

        #region Constructors

        public UserByEmailWhereSpec(string email)
        {
            this._email = email;
        }

        #endregion

        #region Override

        public override Expression<Func<User, bool>> IsSatisfiedBy()
        {
            return user => user.Email == this._email;
        }

        #endregion
    }
}