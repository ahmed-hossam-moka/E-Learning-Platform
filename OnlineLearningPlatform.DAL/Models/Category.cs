namespace OnlineLearningPlatform.DAL.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
