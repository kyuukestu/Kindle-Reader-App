using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using mobile_library.Models;

namespace mobile_library.Helpers
{
    public class AddChapterData
    {
        FirebaseClient client;

        public List<Chapter> Chapters { get; set; }

        public AddChapterData()
        {
            client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");



            Chapters = new List<Chapter>()
            {
                new Chapter
                {
                    ChapterID = 1,
                    ChapterName = "2 Example Name 1",
                    ChapterContent = "When all he could hear on a beautiful, quiet morning in Johto were the singing Pidgey and Spearow, Cobel knew he was going to get roped into something ridiculous; like walking into work to earn a promotion to manager only for the bank you're now managing be held up in an armed robbery that same day. The calm before the storm, as it was colloquially known.",
                    BookID = "2",
                },

                new Chapter
                {
                    ChapterID = 2,
                    ChapterName = "2 Example Name 2",
                    ChapterContent = "The private detective sat down at his desk to thumb through a couple fresh case files while his morning coffee brewed, liquid dripping into the carafe and rising with the sun. He realized he had two different cases to report on; both simple, adulterous infidelities, all Cobel needed to do was attach the appropriate photos, fill out his report form and send the bulk off to his clients.",
                    BookID = "2",
                },

                new Chapter
                {
                    ChapterID = 3,
                    ChapterName = "2 Example Name 3",
                    ChapterContent = "Through the tedium, Cobel listened to softly-blaring jazz music from a record in a far corner, piano, trumpet and quiet guitar strumming seeping into his mind.",
                    BookID = "2",
                },

                 new Chapter
                {
                    ChapterID = 4,
                    ChapterName = "2 Example Name 4",
                    ChapterContent = "When all he could hear on a beautiful, quiet morning in Johto were the singing Pidgey and Spearow, Cobel knew he was going to get roped into something ridiculous; like walking into work to earn a promotion to manager only for the bank you're now managing be held up in an armed robbery that same day. The calm before the storm, as it was colloquially known.",
                    BookID = "2",
                },

                  new Chapter
                {
                    ChapterID = 5,
                    ChapterName = "2 Example Name 5",
                    ChapterContent = "When all he could hear on a beautiful, quiet morning in Johto were the singing Pidgey and Spearow, Cobel knew he was going to get roped into something ridiculous; like walking into work to earn a promotion to manager only for the bank you're now managing be held up in an armed robbery that same day. The calm before the storm, as it was colloquially known.",
                    BookID = "2",
                },


                   new Chapter
                {
                    ChapterID = 6,
                    ChapterName = "2 Example Name 6",
                    ChapterContent = "When all he could hear on a beautiful, quiet morning in Johto were the singing Pidgey and Spearow, Cobel knew he was going to get roped into something ridiculous; like walking into work to earn a promotion to manager only for the bank you're now managing be held up in an armed robbery that same day. The calm before the storm, as it was colloquially known.",
                    BookID = "2",
                },
            };

        }

        public async Task AddChapterAsync()
        {
            try
            {
                foreach(var Chapter in Chapters)
                    {
                    await client.Child("Chapters").PostAsync(new Chapter()
                    {
                        ChapterID = Chapter.ChapterID,
                        ChapterName = Chapter.ChapterName,
                        ChapterContent = Chapter.ChapterContent,
                        BookID = Chapter.BookID,
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
 