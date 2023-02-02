using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DailyToDo : IEntity
    {
        public long Id { get; set; }
        public ToDo ToDo { get; set; }
        public long ToDoId { get; set; }
        public short DayNumber { get; set; }
        public bool IsCompleted { get; set; }
        public string RecordStatus { get; set; } = "A";
    }
}

