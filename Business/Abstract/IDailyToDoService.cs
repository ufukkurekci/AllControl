using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDailyToDoService
    {
        IDataResult<DailyToDo> GetDailyResultById(int todoId);
        IDataResult<List<DailyToDo>> GetAllDailyResult();
        IResult Add(DailyToDo dailyToDo);
        IResult Update(DailyToDo dailyToDo);
        IResult Delete(DailyToDo dailyToDo);
    }
}
