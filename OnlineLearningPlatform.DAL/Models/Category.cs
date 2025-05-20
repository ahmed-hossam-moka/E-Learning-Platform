namespace OnlineLearningPlatform.DAL.Models
{
    public class Category : ISoftDeletable
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
