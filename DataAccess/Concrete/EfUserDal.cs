using Core.DataAccess.EntityFramework;
using Core.Entites;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, AllControlContext>, IUserDal
    {
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            using (var context = new AllControlContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userClaim in context.UserClaims
                                on operationClaim.Id equals userClaim.OperationClaimId
                             where userClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return new SuccessDataResult<List<OperationClaim>>(result.ToList());
            }
        }
    }
}
