using Core.Entites;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int userid);
        IDataResult<List<User>> GetAllUser();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
