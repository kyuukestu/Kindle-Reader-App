using System;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using mobile_library.Models;

namespace mobile_library.Services
{
    public class UserServices
    {
        FirebaseClient client;

        public UserServices()
        {
            client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");
        }


        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users") //Users may need to be changed to User, so it doesn't have the same name as the class in Models/
                .OnceAsync<Users>()).Where(u => u.Object.Username == uname).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string pword)
        {
            if( await IsUserExists(uname) == false)
            {
                await client.Child("Users")
                    .PostAsync(new Users()
                    {
                        Username = uname,
                        Password = pword
                    });

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string uname, string pword)
        {
            var user = (await client.Child("Users")
                .OnceAsync<Users>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == pword).FirstOrDefault();

            return (user != null);
        }
    }
}
