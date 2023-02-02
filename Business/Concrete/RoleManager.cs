using Business.Abstract;
using Business.Constancts;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public IResult Add(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult(Messages.RoleAdd);
        }

        public IResult Delete(Role role)
        {
            _roleDal.Delete(role);
            return new SuccessResult(Messages.RoleDelete);
        }

        public IDataResult<List<Role>> GetAllRoles()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetAll().ToList());
        }

        public IDataResult<Role> GetRoleById(int id)
        {
            return new SuccessDataResult<Role>(_roleDal.Get(p => p.Id == id));
        }

        public IResult Update(Role appRole)
        {
            _roleDal.Update(appRole);
            return new SuccessResult(Messages.RoleUpdate);
        }
    }
}
