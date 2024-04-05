namespace CinemaExperience.Core.ViewModels.Review;
public class ReviewDeleteViewModel
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }
    public DateTime PostedOn { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string MovieTitle { get; set; }
}
