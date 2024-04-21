namespace CinemaExperience.Infrastructure.Data.Constants;
public static class DataConstants
{
    public const string Dateformat = "dd/MM/yyyy";
    public const string LengthErrorMessage = "{0} must be between {2} and {1} characters long!";
    public const string RangeErrorMessage = "{0} must be a number between {1} and {2}!";
    public const string BirthDateErrorMessage = "Birth date cannot be in the future.";
    public const string DirectorErrorMessage = "Director does not exist.";
    public const string GenreNoExistErrorMessage = "Genre does not exist.";
    public const string AtLeastOneGenreErrorMessage = "At least one genre is required.";
    public const string RequiredFieldErrorMessage = "The field {0} is reqired.";
    public const int ImageUrlMinLength = 5;
    public const int ImageUrlMaxLength = 50;
    public static class Movie
    {
        //Name
        public const int TitleMaxLength = 50;
        public const int TitleMinLength = 3;

        //Description
        public const int DescriptionMaxLength = 1000;
        public const int DescriptionMinLength = 10;

        //Ratings
        public const int DefaultRating = 1;

        //Duration
        public const int MaxDuration = 1000;
        public const int MinDuration = 20;

        //CriticsRating
        public const int MaxCriticRating = 10;
        public const int MinCriticRating = 1;

        //UserRating
        public const int MaxUserRating = 10;
        public const int MinUserRating = 1;
    }

    public static class Genre
    {
        //Name
        public const int NameMaxLength = 15;
        public const int NameMinLength = 3;
    }

    public static class Actor
    {
        //Name
        public const int NameMaxLength = 70;
        public const int NameMinLength = 3;

        //Biography
        public const int BiographyMaxLength = 1000;
        public const int BiographyMinLength = 10;
    }

    public static class Director
    {
        //Name
        public const int NameMaxLength = 70;
        public const int NameMinLength = 3;

        //Biography
        public const int BiographyMaxLength = 1000;
        public const int BiographyMinLength = 10;
    }

    public static class Review
    {
        //Content
        public const int ContentMaxLength = 1000;
        public const int ContentMinLength = 30;

        //Rating
        public const int MaxRating = 10;
        public const int MinRating = 1;
    }

    public static class ApplicationUserConstants
    {
        //FirstName
        public const int FirstNameMaxLength = 30;
        public const int FirstNameMinLength = 3;

        //LastName
        public const int LastNameMaxLength = 30;
        public const int LastNameMinLength = 3;


    }

    public static class CriticConstants
    {
        public const string CriticEmailRegex = @"^[\w\.\-]+@[a-zA-Z_]+\.[a-zA-Z]{2,3}$";
    }
}
