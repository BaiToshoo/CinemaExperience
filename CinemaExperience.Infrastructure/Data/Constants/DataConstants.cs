﻿namespace CinemaExperience.Infrastructure.Data.Constants;
public static class DataConstants
{
    public static class Movie
    {
        //Name
        public const int TitleMaxLength = 50;
        public const int TitleMinLength = 3;
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

    public static class ApplicationUser
    {
        //FirstName
        public const int FirstNameMaxLength = 30;
        public const int FirstNameMinLength = 5;

        //LastName
        public const int LastNameMaxLength = 30;
        public const int LastNameMinLength = 5;


    }
}
