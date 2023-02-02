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
    public class DailyToDoManager : IDailyToDoService
    {
        IDailyToDoDal _dailyTodoDal;
        IToDoDal _iToDoDal;

        public DailyToDoManager(IDailyToDoDal dailyTodoDal, IToDoDal iToDoDal)
        {
            _dailyTodoDal = dailyTodoDal;
            _iToDoDal = iToDoDal;
        }

        public IResult Add(DailyToDo dailyToDo)
        {
            _dailyTodoDal.Add(dailyToDo);
            return new SuccessResult(Messages.DailyToAdd);
        }
        public IResult Update(DailyToDo dailyToDo)
        {
            _dailyTodoDal.Update(dailyToDo);
            return new SuccessResult(Messages.DailyToUpdate);
        }

        public IResult Delete(DailyToDo dailyToDo)
        {
            _dailyTodoDal.Delete(dailyToDo);
            return new SuccessResult(Messages.DailyToDelete);
        }

        public IDataResult<List<DailyToDo>> GetAllDailyResult()
        {

            return new SuccessDataResult<List<DailyToDo>>(_dailyTodoDal.GetAll(p => p.RecordStatus == "A").ToList(), Messages.DailyToAll);
        }

        public IDataResult<DailyToDo> GetDailyResultById(int todoId)
        {
            // bugünün tarihini al
            // görev startı al
            // görev startına hangi day number eklenmiş olduğunda bugüne eşit oluyorsa o day numberı şarta koy
            // test

            var today = DateTime.Now.Date; //02.01.2023
            var startDate = _iToDoDal.Get(i => i.Id == todoId).StartDate.Date; // 01.01.2023

            var diffDay = (today - startDate).TotalDays + 1; // 2

            if (diffDay > 30)
            {
                return new SuccessDataResult<DailyToDo>(Messages.DailyToDoNotExist);
            }
            var value = _dailyTodoDal.Get(p => p.ToDoId == todoId && p.DayNumber == diffDay && p.RecordStatus == "A");

            return new SuccessDataResult<DailyToDo>(_dailyTodoDal.Get(p => p.ToDoId == todoId && p.DayNumber == diffDay && p.RecordStatus == "A"));
        }


    }
}
