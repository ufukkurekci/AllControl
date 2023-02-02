using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserRole : IEntity
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }
}
