using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using mobile_library.Models;
using static System.Net.Mime.MediaTypeNames;
using Xamarin.Forms;


namespace mobile_library.Helpers
{
    public class AddGenreData
    {

        public List<Genre> Genres { get; set; }

        FirebaseClient client;

        public AddGenreData() 
        {
            client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");
            Genres = new List<Genre>()
            {
                new Genre ()
                {
                    GenreID = "Act",
                    GenreName = "Action",
                    GenreImage = "ActionImage",
                    GenreImageUrl = "Action_Icon.png" 
                },

                new Genre ()
                {
                    GenreID = "Adv",
                    GenreName = "Adventure",
                    GenreImage = "AdventureImage",
                    GenreImageUrl = "Adventure_Icon.png"
                },

                new Genre ()
                {
                    GenreID = "Com",
                    GenreName = "Comedy",
                    GenreImage = "ComdeyImage",
                    GenreImageUrl = "Comedy_Icon.png"
                },

                new Genre ()
                {
                    GenreID = "Fan",
                    GenreName = "Fantasy",
                    GenreImage = "FantasyImage",
                    GenreImageUrl = "Fantasy_Icon.png"
                },

                new Genre ()
                {
                    GenreID = "His",
                    GenreName = "History",
                    GenreImage = "HistoryImage",
                    GenreImageUrl = "History_Icon.png"
                },

                new Genre ()
                {
                    GenreID = "Mys",
                    GenreName = "Mystery",
                    GenreImage = "MysteryImage",
                    GenreImageUrl = "Mystery_Icon.png"
                },

                new Genre ()
                {
                    GenreID = "Rom",
                    GenreName = "Romance",
                    GenreImage = "RomanceImage",
                    GenreImageUrl = "Romance_2_Icon.png"
                },

                new Genre ()
                {
                    GenreID = "Sci-Fi",
                    GenreName = "ScienceFiction",
                    GenreImage = "ScienceFictionImage",
                    GenreImageUrl = "Science_Fiction_Icon.png"
                }

            };
        }

        public async Task AddGenreAsync()
        {
            try
            {
                foreach (var Genre in Genres)
                {
                    await client.Child("Genres").PostAsync(new Genre()
                    {
                        GenreID = Genre.GenreID,
                        GenreName = Genre.GenreName,
                        GenreImage = Genre.GenreImage,
                        GenreImageUrl = Genre.GenreImageUrl
                    });
                       
                }
            }
            catch (Exception ex)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}
