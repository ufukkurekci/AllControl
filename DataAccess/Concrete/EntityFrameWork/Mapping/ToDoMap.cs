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
    public class ToDoMap : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.TaskName).HasMaxLength(100).IsRequired();
            builder.Property(b => b.GoalCount).HasColumnType("smallint").IsRequired();
            builder.Property(b => b.RecordStatus).IsRequired().HasDefaultValue("A").HasMaxLength(1);
            builder.Property(b => b.StartDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(b => b.EndDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(b => b.IsCompleted).IsRequired();

            // to do : user ile ilişkilendir
            builder.ToTable("ToDos");
        }
    }
}
