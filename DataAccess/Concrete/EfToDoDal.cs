using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using EFCore.BulkExtensions;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfToDoDal : EfEntityRepositoryBase<ToDo, AllControlContext>, IToDoDal
    {
        AllControlContext _allControlContext;

        public EfToDoDal(AllControlContext allControlContext)
        {
            _allControlContext = allControlContext;
        }

        public void AddDailyToDo(ToDo toDo)
        {
            var bulkdata = new List<DailyToDo>();

            for (int i = 1; i <= toDo.GoalCount; i++)
            {
                DailyToDo item = new DailyToDo
                {
                    ToDoId = toDo.Id,
                    DayNumber = (short)i,
                    IsCompleted = false,
                    RecordStatus = "A",
                };
                bulkdata.Add(item);
            }

            using (var tran = _allControlContext.Database.BeginTransaction())
            {
                _allControlContext.BulkInsert(bulkdata);
                tran.Commit();
            }
        }
    }
}
