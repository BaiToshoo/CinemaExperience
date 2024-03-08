using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaExperience.Core.ViewModels.Review;
public class ReviewViewModel
{
    public string Author { set; get; }
    public string Content { set; get; }
    public int Rating { set; get; }
    public DateTime PostedOn { set; get; }
    public bool IsCriticsReview { set; get; }
}
