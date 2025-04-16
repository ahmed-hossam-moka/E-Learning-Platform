namespace OnlineLearningPlatform.DAL.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime AddedDate { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

}
