namespace Project.Core.Domain.Students
{
    public class Student : BaseEntity
    {
        #region Properties

        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        #endregion
    }
}
