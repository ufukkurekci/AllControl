using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ToDoValidator : AbstractValidator<ToDo>
    {
        public ToDoValidator()
        {
            RuleFor(p => p.TaskName).NotEmpty();
            RuleFor(p => p.TaskName).MinimumLength(5);
            RuleFor(p => p.GoalCount).GreaterThanOrEqualTo((short)1);
            RuleFor(p => p.RecordStatus).Equal("A");

        }
    }
}
