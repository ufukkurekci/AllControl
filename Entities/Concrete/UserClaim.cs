using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserClaim : IEntity
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
