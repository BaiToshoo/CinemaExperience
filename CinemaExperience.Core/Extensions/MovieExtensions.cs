using CinemaExperience.Core.Contracts;
using System.Text.RegularExpressions;

namespace CinemaExperience.Core.Extensions;
public static class MovieExtensions
{
	public static string GetMovieInformation(this IMovieModel movie)
	{
		string info = movie.Title.Replace(" ", "-");
		info = Regex.Replace(info, @"[^0-9a-zA-Z]+", "-");
		return info;
	}
}
