
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork.Mapping
{
    public class DailyToDoMap : IEntityTypeConfiguration<DailyToDo>
    {
        public void Configure(EntityTypeBuilder<DailyToDo> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.DayNumber).HasColumnType("smallint").IsRequired();
            builder.HasOne<ToDo>(c => c.ToDo).WithMany(s => s.DailyToDos).HasForeignKey(c => c.ToDoId);

            builder.ToTable("DailyToDos");
        }
    }
}
