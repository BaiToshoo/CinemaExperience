namespace CinemaExperience.Core.ViewModels.Review;
public class ReviewFormViewModel
{
    public int Id { set; get; }
    public int MovieId { set; get; }
    public string UserId { set; get; } = null!;
    public string AuthorName { set; get; } = null!;
    public string Content { set; get; } = null!;
    public int Rating { set; get; }
    public DateTime PostedOn { set; get; }
}
