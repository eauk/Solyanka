using System;
using System.Linq.Expressions;
using Solyanka.Domain.Core.WhereSpec;
using Solyanka.Domain.Persistance;

namespace Solyanka.Domain.Specifications
{
    public class UserByNameWhereSpec : Specification<User>
    {
        #region Fields

        readonly string _name;

        #endregion

        #region Constructors

        public UserByNameWhereSpec(string name)
        {
            this._name = name;
        }

        #endregion

        #region Override

        public override Expression<Func<User, bool>> IsSatisfiedBy()
        {
            return user => user.Name == this._name;
        }

        #endregion
    }
}