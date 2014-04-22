using System;
using System.Linq.Expressions;
using Solyanka.Domain.Core.WhereSpec;
using Solyanka.Domain.Persistance;

namespace Solyanka.Domain.Specifications
{
    public class UserByIdWhereSpec : Specification<User>
    {
        #region Fields

        readonly Guid _id;

        #endregion

        #region Constructors

        public UserByIdWhereSpec(string id)
        {
            this._id = Guid.Parse(id);
        }

        #endregion

        #region Override

        public override Expression<Func<User, bool>> IsSatisfiedBy()
        {
            return user => user.Id == this._id;
        }

        #endregion
    }
}