namespace OnlineLearningPlatform.BLL.Dtos.Admin
{
    public class InstructorApprovalDto
    {
        public string InstructorId { get; set; }
        public bool IsApproved { get; set; }
        public string? AdminNotes { get; set; }  // Optional for rejection reasons
    }
}