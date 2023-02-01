using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using mobile_library.Models;

namespace mobile_library.Services
{
    public class GenreDataServices
    {
        FirebaseClient client;

        public GenreDataServices()
        {
            client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Genre>> GetGenreAsync()
        {
            var genres = (await client.Child("Genres")
                .OnceAsync<Genre>())
                .Select(c => new Genre
                {
                    GenreID = c.Object.GenreID,
                    GenreName = c.Object.GenreName,
                    GenreImage = c.Object.GenreImage,
                    GenreImageUrl = c.Object.GenreImageUrl
                }).ToList();
            return genres;
        }
    }
}
