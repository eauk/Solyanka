using System;
using System.Linq.Expressions;
using Solyanka.Domain.Core.WhereSpec;
using Solyanka.Domain.Persistance;

namespace Solyanka.Domain.Specifications
{
    public class UserByPasswordWhereSpec : Specification<User>
    {
        #region Fields

        readonly string _password;

        #endregion

        #region Constructors

        public UserByPasswordWhereSpec(string password)
        {
            this._password = password;
        }

        #endregion

        #region Override

        public override Expression<Func<User, bool>> IsSatisfiedBy()
        {
            return user => user.Password == this._password;
        }

        #endregion
    }
}