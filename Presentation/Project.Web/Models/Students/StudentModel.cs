namespace Project.Web.Models.Students
{
    public class StudentModel : BaseEntityModel
    {
        #region Properties

        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        #endregion
    }
}
