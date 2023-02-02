using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserRoleService
    {
        IDataResult<GetUserRoleDto> GetUserRoleByUserId(int userid);
        IDataResult<List<UserRole>> GetAllUserRole();
        IResult Add(UserRole userrole);
        IResult Update(UserRole userrole);
        IResult Delete(UserRole userrole);
    }
}
