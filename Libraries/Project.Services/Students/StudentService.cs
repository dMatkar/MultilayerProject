using Project.Core.Data;
using Project.Core.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Services.Students
{
    public class StudentService : IStudentService
    {
        #region Fields

        private readonly IRepository<Student> _studentRepository;

        #endregion

        #region Constructor

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #endregion

        #region Methods

        public void DeleteStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _studentRepository.Delete(student);
        }

        public IEnumerable<Student> GetStudents()
        {
            var list = _studentRepository.Table.ToList();
            return list;
        }

        public Student GetStudent(int id)
        {
            if (id == 0)
                return null;

            return _studentRepository.GetById(id);
        }

        public void InsertStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _studentRepository.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _studentRepository.Update(student);
        }

        #endregion
    }
}
