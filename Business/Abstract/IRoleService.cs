using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService
    {
        IDataResult<List<Role>> GetAllRoles();
        IResult Add(Role role);
        IResult Update(Role role);
        IResult Delete(Role role);
        IDataResult<Role> GetRoleById(int id);
    }
}
