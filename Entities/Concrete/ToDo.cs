using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ToDo:IEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string TaskName { get; set; }
        public short GoalCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RecordStatus { get; set; }
        public bool IsCompleted { get; set; }
        public IList<DailyToDo>? DailyToDos { get; set; }
    }
}
