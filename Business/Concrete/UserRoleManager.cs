using Business.Abstract;
using Business.Constancts;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public IResult Add(UserRole userRole)
        {
            _userRoleDal.Add(userRole);
            return new SuccessResult(Messages.RoleAdd);
        }

        public IResult Delete(UserRole userRole)
        {
            _userRoleDal.Delete(userRole);
            return new SuccessResult(Messages.UserRoleDelete);
        }

        public IDataResult<List<UserRole>> GetAllUserRole()
        {
            return new SuccessDataResult<List<UserRole>>(_userRoleDal.GetAll().ToList(), Messages.DailyToDoNotExist);
        }

        public IDataResult<GetUserRoleDto> GetUserRoleByUserId(int userid)
        {
            var result = _userRoleDal.GetUserRoleByUserId(userid);
            if (result == null)
            {
                return new ErrorDataResult<GetUserRoleDto>(null, Messages.UserRoleUpdate);
            }

            return new SuccessDataResult<GetUserRoleDto>(result, Messages.UserRoleUpdate);

        }

        public IResult Update(UserRole userRole)
        {
            _userRoleDal.Update(userRole);
            return new SuccessResult(Messages.UserRoleUpdate);
        }
    }
}
