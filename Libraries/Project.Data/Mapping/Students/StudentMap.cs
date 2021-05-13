using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Domain.Students;

namespace Project.Data.Mapping.Students
{
    public class StudentMap : ProjectEntityTypeConfiguration<Student>
    {
        #region Methods

        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));
            builder.HasKey(student => student.Id);

            builder.Property(student => student.Name).HasMaxLength(1000);
            builder.Property(student => student.City).HasMaxLength(1000);
            builder.Property(student => student.State).HasMaxLength(1000);

            base.Configure(builder);
        }

        #endregion

        protected void m()
        {

        }
    }
}
