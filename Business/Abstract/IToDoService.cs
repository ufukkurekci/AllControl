using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IToDoService
    {
        IDataResult<List<ToDo>> GetAllToDo();
        IDataResult<ToDo> GetById(int id);
        Task<IResult> Add(ToDo toDo);
        IResult Update(ToDo toDo);
        IResult Delete(ToDo toDo);

    }
}
