using Project.Core.Domain.Students;
using System.Collections.Generic;

namespace Project.Services.Students
{
    public interface IStudentService
    {
        #region Methods

        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);

        #endregion
    }
}
