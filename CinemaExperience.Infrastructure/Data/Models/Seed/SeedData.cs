using CinemaExperience.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;


namespace CinemaExperience.Infrastructure.Data.Models.Seed;
internal class SeedData
{
    //Users
    public ApplicationUser GuestUser { get; set; }
    public ApplicationUser CriticUser { get; set; }
    public ApplicationUser AdminUser { get; set; }
    public ApplicationUser DwightBrown { get; set; }
    public ApplicationUser KimberlyPierce { get; set; }

    //Movies
    public Movie Inception { get; set; }
    public Movie TheDarkKnight { get; set; }
    public Movie DunePartTwo { get; set; }

    //Directors
    public Director ChristopherNolan { get; set; }
    public Director DenisVilleneuve { get; set; }

    //Actors
    public Actor ChristianBale { get; set; }
    public Actor HeathLedger { get; set; }
    public Actor MichaelCaine { get; set; }
    public Actor AaronEckhart { get; set; }
    public Actor MaggieGyllenhaal { get; set; }
    public Actor LeonardoDiCaprio { get; set; }
    public Actor JosephGordonLevitt { get; set; }
    public Actor ElliotPage { get; set; }
    public Actor TomHardy { get; set; }
    public Actor KenWatanabe { get; set; }
    public Actor TimotheeChalamet { get; set; }
    public Actor Zendaya { get; set; }
    public Actor RebeccaFerguson { get; set; }
    public Actor JavierBardem { get; set; }
    public Actor AustinButler { get; set; }



    //Reviews
    public Review Review1 { get; set; }
    public Review Review2 { get; set; }
    public Review Review3 { get; set; }
    public Review Review4 { get; set; }
    public Review Review5 { get; set; }
    public Review Review6 { get; set; }
    public Review Review7 { get; set; }
    public Review Review8 { get; set; }
    public Review Review9 { get; set; }
    public Review Review10 { get; set; }

    //Genres
    public Genre Action { get; set; }
    public Genre Science { get; set; }
    public Genre Drama { get; set; }
    public Genre Thriller { get; set; }
    public Genre Crime { get; set; }
    public Genre SciFi { get; set; }
    public Genre Mystery { get; set; }
    public Genre Adventure { get; set; }

    //MovieGenres
    public List<MovieGenre> InceptionMovieGenres { get; set; }
    public List<MovieGenre> TheDarkKnightMovieGenres { get; set; }
    public List<MovieGenre> DunePartTwoMovieGenres { get; set; }

    //MovieActors
    public List<MovieActor> InceptionMovieActors { get; set; }
    public List<MovieActor> TheDarkKnightMovieActors { get; set; }
    public List<MovieActor> DunePartTwoMovieActors { get; set; }

    public SeedData()
    {
        SeedUsers();
        SeedDirectors();
        SeedActors();
        SeedGenres();
        SeedMovies();
        SeedReviews();
        SeedMovieGenres();
        SeedMovieActors();
    }

    private void SeedUsers()
    {

        var hasher = new PasswordHasher<ApplicationUser>();

        GuestUser = new ApplicationUser()
        {
            FirstName = "Todor",
            LastName = "Kuzmanov",
            Id = "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5",
            UserName = "guest@guest.com",
            NormalizedUserName = "GUEST@GUEST.COM",
            Email = "guest@guest.com",
            NormalizedEmail = "GUEST@GUEST.COM",
        };

        GuestUser.PasswordHash =
            hasher.HashPassword(GuestUser, "guest123456");

        CriticUser = new ApplicationUser()
        {
            FirstName = "Teodora",
            LastName = "Kuzmanova",
            Id = "cd5cc46a-ef03-4222-ad12-71572e2c61ba",
            UserName = "critic@critic.com",
            NormalizedUserName = "CRITIC@CRITIC.COM",
            Email = "critic@critic.com",
            NormalizedEmail = "CRITIC@CRITIC.COM",
        };

        CriticUser.PasswordHash =
            hasher.HashPassword(CriticUser, "critic123456");

        AdminUser = new ApplicationUser()
        {
            FirstName = "Admin",
            LastName = "Admin",
            Id = "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
        };

        AdminUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin123456");

        DwightBrown = new ApplicationUser()
        {
            FirstName = "Dwight",
            LastName = "Brown",
            Id = "5ed4fe5a-5f46-4223-bcd5-49e1263b4182",
            UserName = "dwight@brown.com",
            NormalizedUserName = "DWIGHT@BROWN.COM",
            Email = "dwight@brown.com",
            NormalizedEmail = "DWIGHT@BROWN.COM"
        };

        DwightBrown.PasswordHash =
            hasher.HashPassword(DwightBrown, "dwight123456");

        KimberlyPierce = new ApplicationUser()
        {
            FirstName = "Kimberly",
            LastName = "Pierce",
            Id = "f4320fef-5953-4193-8c9e-4b72f71873ab",
            UserName = "kimberly@pierce.com",
            NormalizedUserName = "KIMBERLY@PIERCE.COM",
            Email = "kimberly@pierce.com",
            NormalizedEmail = "KIMBERLY@PIERCE.COM"
        };

        KimberlyPierce.PasswordHash =
            hasher.HashPassword(KimberlyPierce, "kimberly123456");
    }

    private void SeedMovies()
    {
        Inception = new Movie()
        {
            Id = 1,
            Title = "Inception",
            Description = "Inception is a 2010 science fiction action film written and directed by Christopher Nolan, who also produced the film with Emma Thomas, his wife. The film stars Leonardo DiCaprio as a professional thief who steals information by infiltrating the subconscious of his targets. He is offered a chance to have his criminal history erased as payment for the implantation of another person's idea into a target's subconscious. The ensemble cast includes Ken Watanabe, Joseph Gordon-Levitt, Marion Cotillard, Elliot Page, Tom Hardy, Dileep Rao, Cillian Murphy, Tom Berenger, and Michael Caine.",
            ImageUrl = "/images/movies/inception.jpg",
            ReleaseDate = new DateTime(2010, 7, 16),
            Duration = 148,
            DirectorId = ChristopherNolan.Id
        };

        TheDarkKnight = new Movie()
        {
            Id = 2,
            Title = "The Dark Knight",
            Description = "The Dark Knight is a 2008 superhero film directed, produced, and co-written by Christopher Nolan. Based on the DC Comics character Batman, the film is the second installment of Nolan's The Dark Knight Trilogy and a sequel to 2005's Batman Begins, starring Christian Bale and supported by Michael Caine, Heath Ledger, Gary Oldman, Aaron Eckhart, Maggie Gyllenhaal, and Morgan Freeman. In the film, Bruce Wayne / Batman (Bale), Police Lieutenant James Gordon (Oldman) and District Attorney Harvey Dent (Eckhart) form an alliance to dismantle organized crime in Gotham City, but are menaced by an anarchistic mastermind known as the Joker (Ledger), who seeks to undermine Batman's influence and throw the city into anarchy.",
            Duration = 152,
            ImageUrl = "/images/movies/The_Dark_Knight.jpg",
            ReleaseDate = new DateTime(2008, 7, 18),
            DirectorId = ChristopherNolan.Id
        };

        DunePartTwo = new Movie()
        {
            Id = 3,
            Title = "Dune: Part Two",
            Description = "Dune: Part Two is an upcoming American epic science fiction film directed by Denis Villeneuve and written by Jon Spaihts, Villeneuve, and Eric Roth. It is the second of a planned two-part adaptation of the 1965 novel of the same name by Frank Herbert, and will cover the second half of the book. The film stars an ensemble cast including Timothée Chalamet, Rebecca Ferguson, Oscar Isaac, Josh Brolin, Stellan Skarsgård, Dave Bautista, Stephen McKinley Henderson, Zendaya, David Dastmalchian, Chang Chen, Sharon Duncan-Brewster, Charlotte Rampling, Jason Momoa, and Javier Bardem.",
            Duration = 166,
            ImageUrl = "/images/movies/Dune_Part_Two.jpg",
            ReleaseDate = new DateTime(2023, 10, 20),
            DirectorId = DenisVilleneuve.Id
        };
    }

    private void SeedDirectors()
    {
        ChristopherNolan = new Director()
        {
            Id = 1,
            Name = "Christopher Nolan",
            ImageUrl = "/images/directors/Christopher_Nolan.jpg",
            BirthDate = new DateTime(1970, 7, 30),
            Biography = "Christopher Edward Nolan CBE is a British-American film director, producer, and screenwriter. His films have grossed over US$5 billion worldwide, and he is one of the highest-grossing directors in history. Having made his directorial debut with Following (1998), Nolan gained considerable attention for his second feature, Memento (2000), for which he received a nomination for the Academy Award for Best Original Screenplay. The acclaim garnered by his independent films gave Nolan the opportunity to make the big-budget thriller Insomnia (2002), and the mystery drama The Prestige (2006). He found further popular and critical success with The Dark Knight Trilogy (2005–2012), Inception (2010), Interstellar (2014), Dunkirk (2017), and Tenet (2020)."
        };

        DenisVilleneuve = new Director()
        {
            Id = 2,
            Name = "Denis Villeneuve",
            ImageUrl = "/images/directors/Denis_Villeneuve.jpg",
            BirthDate = new DateTime(1967, 10, 3),
            Biography = "Denis Villeneuve is a Canadian film director, writer, and producer. He is a four-time recipient of the Canadian Screen Award for Best Direction, for Maelström in 2001, Polytechnique in 2009, Incendies in 2011, and Enemy in 2013. The first three of these films also won the Canadian Screen Award for Best Motion Picture, while the latter was awarded the prize for best Canadian film of the year by the Toronto Film Critics Association. The first feature film he directed is Un 32 août sur terre, which was selected as the Canadian entry for the Best Foreign Language Film at the 68th Academy Awards, but was not accepted as a nominee. He was later nominated three times for the Academy Award for Best Director, for the films Arrival (2016), Blade Runner 2049 (2017), and Dune (2021)."
        };
    }

    private void SeedActors()
    {
        ChristianBale = new Actor()
        {
            Id = 1,
            Name = "Christian Bale",
            ImageUrl = "/images/actors/Christian_Bale.jpg",
            BirthDate = new DateTime(1974, 1, 30),
            Biography = "Christian Charles Philip Bale is an English actor. Known for his versatility and intensive method acting, he is the recipient of many awards, including an Academy Award and two Golden Globe Awards. Time magazine included him on its list of the 100 most influential people in the world in 2011. Born in Haverfordwest, Wales, to English parents, Bale had his first starring role at age 13 in Steven Spielberg's war film Empire of the Sun (1987)."
        };
        HeathLedger = new Actor()
        {
            Id = 2,
            Name = "Heath Ledger",
            ImageUrl = "/images/actors/Heath_Ledger.jpg",
            BirthDate = new DateTime(1979, 4, 4),
            Biography = "Heath Andrew Ledger was an Australian actor and music video director. After performing roles in several Australian television and film productions during the 1990s, Ledger left for the United States in 1998 to further develop his film career. His work comprised nineteen films, including 10 Things I Hate About You (1999), The Patriot (2000), A Knight's Tale (2001), Monster's Ball (2001), Lords of Dogtown (2005), Brokeback Mountain (2005), Candy (2006), I'm Not There (2007), The Dark Knight (2008), and The Imaginarium of Doctor Parnassus (2009)."
        };
        AaronEckhart = new Actor()
        {
            Id = 3,
            Name = "Aaron Eckhart",
            ImageUrl = "/images/actors/Aaron_Eckhart.jpg",
            BirthDate = new DateTime(1968, 3, 12),
            Biography = "Aaron Edward Eckhart is an American actor. Born in Cupertino, California, Eckhart moved to England at age 13, when his father relocated the family. Several years later, he began his acting career by performing in school plays, before moving to Sydney, Australia, for his high school senior year. He left high school without graduating, but earned a diploma through an adult education course, and graduated from Brigham Young University (BYU) in 1994 with a Bachelor of Fine Arts degree in film."
        };
        MichaelCaine = new Actor()
        {
            Id = 4,
            Name = "Michael Caine",
            ImageUrl = "/images/actors/Michael_Caine.jpg",
            BirthDate = new DateTime(1933, 3, 14),
            Biography = "Sir Michael Caine CBE is an English actor. Known for his distinctive Cockney accent, he has appeared in more than 130 films during a career spanning over 70 years, and is considered a British film icon. As of February 2017, the films in which Caine has appeared have grossed over $7.8 billion worldwide. Often playing a Cockney, Caine made his breakthrough in the 1960s with starring roles in British films, including Zulu (1964), The Ipcress File (1965), Alfie (1966), for which he was nominated for an Academy Award, The Italian Job (1969), and Battle of Britain (1969)."
        };
        MaggieGyllenhaal = new Actor()
        {
            Id = 5,
            Name = "Maggie Gyllenhaal",
            ImageUrl = "/images/actors/Maggie_Gyllenhaal.jpg",
            BirthDate = new DateTime(1977, 11, 16),
            Biography = "Margalit Ruth Gyllenhaal is an American actress and film producer. Part of the Gyllenhaal family, she is the daughter of filmmakers Stephen Gyllenhaal and Naomi Achs, and the older sister of actor Jake Gyllenhaal. She began her career as a teenager with small roles in several of her father's films, and appeared with her brother in the cult favorite Donnie Darko (2001). She received critical acclaim for her leading roles in the independent films Secretary (2002) and Sherrybaby (2006), earning a Golden Globe Award for the latter."
        };
        LeonardoDiCaprio = new Actor()
        {
            Id = 6,
            Name = "Leonardo DiCaprio",
            ImageUrl = "/images/actors/Leonardo_DiCaprio.jpg",
            BirthDate = new DateTime(1974, 11, 11),
            Biography = "Leonardo Wilhelm DiCaprio is an American actor, film producer, and environmentalist. Known for his work in biopics and period films, DiCaprio is the recipient of numerous accolades, including an Academy Award, a British Academy Film Award, and three Golden Globe Awards. As of 2019, his films have grossed over $7.2 billion worldwide, and he has been placed eight times in annual rankings of the world's highest-paid actors."
        };
        JosephGordonLevitt = new Actor()
        {
            Id = 7,
            Name = "Joseph Gordon-Levitt",
            ImageUrl = "/images/actors/Joseph_Gordon_Levitt.jpg",
            BirthDate = new DateTime(1981, 2, 17),
            Biography = "Joseph Leonard Gordon-Levitt is an American actor, filmmaker, singer, and entrepreneur. As a child, Gordon-Levitt appeared in the films A River Runs Through It, Angels in the Outfield, Holy Matrimony and 10 Things I Hate About You, and as Tommy Solomon in the TV series 3rd Rock from the Sun. He took a break from acting to study at Columbia University, but dropped out in 2004 to pursue acting again. He has since starred in (500) Days of Summer, Inception, Hesher, 50/50, Premium Rush, The Night Before, and Snowden."
        };
        ElliotPage = new Actor()
        {
            Id = 8,
            Name = "Elliot Page",
            ImageUrl = "/images/actors/Elliot_Page.jpg",
            BirthDate = new DateTime(1987, 2, 21),
            Biography = "Elliot Page is a Canadian actor and producer. He first became known for his role in the film and television series Pit Pony (1997–2000), for which he won a Young Artist Award, and for recurring roles in Trailer"
        };
        TomHardy = new Actor()
        {
            Id = 9,
            Name = "Tom Hardy",
            ImageUrl = "/images/actors/Tom_Hardy.jpg",
            BirthDate = new DateTime(1977, 9, 15),
            Biography = "Edward Thomas Hardy CBE is an English actor and producer. After studying acting at the Drama Centre London, he made his film debut in Ridley Scott's Black Hawk Down (2001) and has since appeared in such films as Star Trek: Nemesis (2002), RocknRolla (2008), Bronson (2008), Warrior (2011), Tinker Tailor Soldier Spy (2011), Lawless (2012), Locke (2013), The Drop (2014), and The Revenant (2015), for which he received a nomination for the Academy Award for Best Supporting Actor."
        };
        KenWatanabe = new Actor()
        {
            Id = 10,
            Name = "Ken Watanabe",
            ImageUrl = "/images/actors/Ken_Watanabe.jpg",
            BirthDate = new DateTime(1959, 10, 21),
            Biography = "Ken Watanabe is a Japanese actor. To English-speaking audiences, he is known for playing tragic hero characters, such as General Tadamichi Kuribayashi in Letters from Iwo Jima and Lord Katsumoto Moritsugu in The Last Samurai, for which he was nominated for the Academy Award for Best Supporting Actor. Among other awards, he has won the Japan Academy Film Prize for Best Actor twice, in 2007 for Memories of Tomorrow and in 2010 for Shizumanu Taiyō. He is also known for his roles in Christopher Nolan's Batman Begins and The Dark Knight (as Ra's al Ghul), Inception, and Godzilla.",
        };
        TimotheeChalamet = new Actor()
        {
            Id = 11,
            Name = "Timothee Chalamet",
            ImageUrl = "/images/actors/Timothee_Chalamet.jpg",
            BirthDate = new DateTime(1995, 12, 27),
            Biography = "Timothee Hal Chalamet is an American actor. He began his acting career in short films, before appearing in the television drama series Homeland in 2012. Two years later, he made his feature film debut in the drama"
        };
        Zendaya = new Actor()
        {
            Id = 12,
            Name = "Zendaya",
            ImageUrl = "/images/actors/Zendaya.jpg",
            BirthDate = new DateTime(1996, 9, 1),
            Biography = "Zendaya Maree Stoermer Coleman is an American actress and singer. She began her career as a child model and backup dancer, before gaining prominence for her role as Rocky Blue on the Disney Channel sitcom Shake It Up (2010–2013). In 2013, Zendaya was a contestant on the sixteenth season of the competition series Dancing with the Stars. From 2015 to 2018, she produced and starred as the titular spy, K.C. Cooper, in the sitcom K.C. Undercover, and in 2019, she began playing the lead role in the HBO drama series Euphoria."
        };
        RebeccaFerguson = new Actor()
        {
            Id = 13,
            Name = "Rebecca Ferguson",
            ImageUrl = "/images/actors/Rebecca_Ferguson.jpg",
            BirthDate = new DateTime(1983, 10, 19),
            Biography = "Rebecca Louisa Ferguson Sundström is a Swedish actress. She began her acting career with the Swedish soap opera Nya tider (1999–2000) and went on to star in the slasher film Drowning Ghost (2004). She came to international prominence with her portrayal of Elizabeth Woodville in the British television miniseries The White Queen (2013), for which she was nominated for a Golden Globe for Best Actress in a Miniseries or Television Film."
        };
        JavierBardem = new Actor()
        {
            Id = 14,
            Name = "Javier Bardem",
            ImageUrl = "/images/actors/Javier_Bardem.jpg",
            BirthDate = new DateTime(1969, 3, 1),
            Biography = "Javier Ángel Encinas Bardem is a Spanish actor. Bardem won the Academy Award for Best Supporting Actor for his role as the psychopathic assassin Anton Chigurh in the 2007 Coen Brothers film"
        };
        AustinButler = new Actor()
        {
            Id = 15,
            Name = "Austin Butler",
            ImageUrl = "/images/actors/Austin_Butler.jpg",
            BirthDate = new DateTime(1991, 8, 17),
            Biography = "Austin Robert Butler is an American actor and singer. He is known for his roles as James Wilke Wilkerson in Switched at Birth, Jordan Gallagher on Ruby & The Rockits, Sebastian Kydd in The Carrie Diaries, Wil Ohmsford in The Shannara Chronicles, and Elvis Presley in the biographical musical drama film Elvis."
        };
    }

    private void SeedGenres()
    {
        Action = new Genre()
        {
            Id = 1,
            Name = "Action"
        };
        Science = new Genre()
        {
            Id = 2,
            Name = "Science"
        };
        Drama = new Genre()
        {
            Id = 3,
            Name = "Drama"
        };
        Thriller = new Genre()
        {
            Id = 4,
            Name = "Thriller"
        };
        Crime = new Genre()
        {
            Id = 5,
            Name = "Crime"
        };
        SciFi = new Genre()
        {
            Id = 6,
            Name = "Sci-Fi"
        };
        Mystery = new Genre()
        {
            Id = 7,
            Name = "Mystery"
        };
        Adventure = new Genre()
        {
            Id = 8,
            Name = "Adventure"
        };
    }

    private void SeedReviews()
    {
        Review1 = new Review()
        {
            Id = 1,
            UserId = CriticUser.Id,
            Content = "It is, simply put, a cerebral masterpiece from Christopher Nolan.",
            Rating = 10,
            MovieId = Inception.Id,
            PostedOn = new DateTime(2021, 7, 16)
        };
        Review2 = new Review()
        {
            Id = 2,
            UserId = CriticUser.Id,
            Content = "The famous masked vigilante has never looked or felt more intense.",
            Rating = 7,
            MovieId = TheDarkKnight.Id,
            PostedOn = new DateTime(2021, 7, 18)
        };
        Review3 = new Review()
        {
            Id = 3,
            UserId = GuestUser.Id,
            Content = "Mind-blowing, amazing, smart, thrilling. That's all",
            Rating = 10,
            MovieId = Inception.Id,
            PostedOn = new DateTime(2021, 7, 16)
        };
        Review4 = new Review()
        {
            Id = 4,
            UserId = GuestUser.Id,
            Content = "Revolutionized the superhero genre. Must see.",
            Rating = 8,
            MovieId = TheDarkKnight.Id,
            PostedOn = new DateTime(2021, 7, 18)
        };
        Review5 = new Review()
        {
            Id = 5,
            UserId = DwightBrown.Id,
            Content = "An epic and spectacular sci-fi allegory with mass appeal.",
            Rating = 8,
            MovieId = DunePartTwo.Id,
            PostedOn = new DateTime(2023, 10, 20)
        };
        Review6 = new Review()
        {
            Id = 6,
            UserId = KimberlyPierce.Id,
            Content = "The best movie of the year. A must-see.",
            Rating = 10,
            MovieId = DunePartTwo.Id,
            PostedOn = new DateTime(2023, 10, 20)
        };
        Review7 = new Review()
        {
            Id = 7,
            UserId = KimberlyPierce.Id,
            Content = "This film must be revisited, talked about, analyzed, and rewatched again and again. It will surely grow upon each viewing, but it proves instantly enthralling the first time.",
            Rating = 8,
            MovieId = Inception.Id,
            PostedOn = new DateTime(2023, 10, 20)
        };
        Review8 = new Review()
        {
            Id = 8,
            UserId = DwightBrown.Id,
            Content = "The Dark Knight is a film that is not only a great comic book movie, but a great movie in general. It's a film that transcends the superhero genre and is a film that will be remembered for years to come.",
            Rating = 9,
            MovieId = TheDarkKnight.Id,
            PostedOn = new DateTime(2023, 10, 20)
        };
        Review9 = new Review()
        {
            Id = 9,
            UserId = KimberlyPierce.Id,
            Content = "The Dark Knight is a film that is not only a great comic book movie, but a great movie in general. It's a film that transcends the superhero genre and is a film that will be remembered for years to come.",
            Rating = 8,
            MovieId = TheDarkKnight.Id,
            PostedOn = new DateTime(2023, 10, 20)
        };
        Review10 = new Review()
        {
            Id = 10,
            UserId = DwightBrown.Id,
            Content = "When you have such a great writer/director as Christopher Nolan making his own thing, you can only expect to be mindblown. And I was, but not in the good way. I was blown",
            Rating = 3,
            MovieId = Inception.Id,
            PostedOn = new DateTime(2023, 10, 20)
        };

    }
    private void SeedMovieGenres()
    {
        InceptionMovieGenres = new List<MovieGenre>()
        {
            new MovieGenre()
            {
                MovieId = Inception.Id,
                GenreId = SciFi.Id
            },
            new MovieGenre()
            {
                MovieId = Inception.Id,
                GenreId = Mystery.Id
            },
            new MovieGenre()
            {
                MovieId = Inception.Id,
                GenreId = Thriller.Id
            }
        };
        TheDarkKnightMovieGenres = new List<MovieGenre>()
        {
            new MovieGenre()
            {
                MovieId = TheDarkKnight.Id,
                GenreId = Action.Id
            },
            new MovieGenre()
            {
                MovieId = TheDarkKnight.Id,
                GenreId = Adventure.Id
            }
        };
        DunePartTwoMovieGenres = new List<MovieGenre>()
        {
            new MovieGenre()
            {
                MovieId = DunePartTwo.Id,
                GenreId = SciFi.Id
            },
            new MovieGenre()
            {
                MovieId = DunePartTwo.Id,
                GenreId = Adventure.Id
            }
        };
    }
    private void SeedMovieActors()
    {

        InceptionMovieActors = new List<MovieActor>()
        {
            new MovieActor()
            {
                MovieId = Inception.Id,
                ActorId = LeonardoDiCaprio.Id
            },
            new MovieActor()
            {
                MovieId = Inception.Id,
                ActorId = JosephGordonLevitt.Id
            },
            new MovieActor()
            {
                MovieId = Inception.Id,
                ActorId = ElliotPage.Id
            },
            new MovieActor()
            {
                MovieId = Inception.Id,
                ActorId = TomHardy.Id
            },
            new MovieActor()
            {
                MovieId = Inception.Id,
                ActorId = KenWatanabe.Id
            }
        };

        TheDarkKnightMovieActors = new List<MovieActor>()
        {
           new MovieActor()
           {
               MovieId = TheDarkKnight.Id,
               ActorId = ChristianBale.Id
           },
           new MovieActor()
           {
               MovieId = TheDarkKnight.Id,
               ActorId = HeathLedger.Id
           },
           new MovieActor()
           {
               MovieId = TheDarkKnight.Id,
               ActorId = MichaelCaine.Id
           },
           new MovieActor()
           {
               MovieId = TheDarkKnight.Id,
               ActorId = AaronEckhart.Id
           },
           new MovieActor()
           {
               MovieId = TheDarkKnight.Id,
               ActorId = MaggieGyllenhaal.Id
           }

        };

        DunePartTwoMovieActors = new List<MovieActor>()
        {
            new MovieActor()
            {
                MovieId = DunePartTwo.Id,
                ActorId = TimotheeChalamet.Id
            },
            new MovieActor()
            {
                MovieId = DunePartTwo.Id,
                ActorId = Zendaya.Id
            },
            new MovieActor()
            {
                MovieId = DunePartTwo.Id,
                ActorId = RebeccaFerguson.Id
            },
            new MovieActor()
            {
                MovieId = DunePartTwo.Id,
                ActorId = JavierBardem.Id
            },
            new MovieActor()
            {
                MovieId = DunePartTwo.Id,
                ActorId = AustinButler.Id
            }
        };
    }
}
