using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserRoleDal : EfEntityRepositoryBase<UserRole, AllControlContext>, IUserRoleDal
    {
        public GetUserRoleDto GetUserRoleByUserId(int userid)
        {
            using (AllControlContext context = new AllControlContext())
            {
                var result = from p in context.UserRoles
                             join u in context.Users
                             on
                             p.UserId equals u.Id
                             join r in context.Roles
                             on
                             p.RoleId equals r.Id
                             where u.Id == userid
                             select new GetUserRoleDto
                             {
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RoleName = r.Name
                             };


                return result.FirstOrDefault();

            }

        }

    }
}
