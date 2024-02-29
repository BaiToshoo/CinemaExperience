namespace CinemaExperience.Infrastructure.Data.Constants;
public static class DataConstants
{
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
        public const int FirstNameMinLength = 5;

        //LastName
        public const int LastNameMaxLength = 30;
        public const int LastNameMinLength = 5;


    }
}
