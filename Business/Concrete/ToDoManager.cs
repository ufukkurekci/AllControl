using Business.Abstract;
using Business.Aspect.Autofac;
using Business.Constancts;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDoDal;
        IUserService _appUserService;
        public ToDoManager(IToDoDal toDoDal, IUserService appUserService)
        {
            _toDoDal = toDoDal;
            _appUserService = appUserService;
        }
        [SecuredOperation("todo.add,admin")]
        [ValidationAspect(typeof(ToDoValidator))]
        public async Task<IResult> Add(ToDo toDo)
        {
            IResult result = BusinessRules.Run(CheckIfToDoNameExist(toDo.TaskName), CheckUserHaveToDo(toDo.UserId), ControlMaxUser());

            if (result != null)
            {
                return result;
            }
            _toDoDal.Add(toDo);
            await _toDoDal.AddDailyToDo(toDo);
            return new SuccessResult(Messages.ToDoAdd);
        }
        public IResult Delete(ToDo toDo)
        {
            toDo.RecordStatus = "P";
            _toDoDal.Update(toDo);
            return new SuccessResult(Messages.ToDoDelete);
        }

        public IDataResult<List<ToDo>> GetAllToDo()
        {
            return new SuccessDataResult<List<ToDo>>(_toDoDal.GetAll(p => p.RecordStatus == "A").ToList(), Messages.UsersListed);
        }

        public IDataResult<ToDo> GetById(int toDoId)
        {
            return new SuccessDataResult<ToDo>(_toDoDal.Get(p => p.Id == toDoId));
        }

        public IResult Update(ToDo toDo)
        {
            _toDoDal.Update(toDo);
            return new SuccessResult(Messages.ToDoUpdate);
        }
        private IResult CheckUserHaveToDo(long userId)
        {
            // One userId have maximum 10 todos.
            var user_todo_count = _toDoDal.GetAll(p => p.UserId == userId);
            if (user_todo_count.Count >= 4)
            {
                return new ErrorResult("One use have max 4 Todos.");
            }
            return new SuccessResult();
        }
        private IResult CheckIfToDoNameExist(string taskName)
        {
            var result = _toDoDal.GetAll(p => p.TaskName == taskName).Any();
            if (result)
            {
                return new ErrorResult("You can not add same Todo TaskName.");
            }
            return new SuccessResult();
        }
        private IResult ControlMaxUser()
        {
            var result = _appUserService.GetAllUser();
            if (result.Data.Count > 30)
            {
                return new ErrorResult("User acccess limit max 30.");
            }
            return new SuccessResult();
        }

    }
}
