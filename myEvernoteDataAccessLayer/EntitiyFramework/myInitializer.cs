using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEvernotEntities;

namespace myEvernoteDataAccessLayer.EntityFramework
{
    public class myInitializer : CreateDatabaseIfNotExists<databaseContext>
    {
        protected override void Seed(databaseContext context)
        {   //Adding Admin User
            evernoteUser admin = new evernoteUser()
            {
                name = "Büşranur",
                surname = "Yiğit",
                eMail = "busranuryigit11@gmail.com",
                activeGuid = Guid.NewGuid(),
                isAdmin = true,
                ısActive = true,
                userName = "busranuryigit",
                profileImageFileName="userNoy.png",
                password = "123456",
                createdOn = DateTime.Now,
                modifiedOn = DateTime.Now.AddMinutes(5),
                modifiedUserName = "busranuryigit"
            };

            // Adding Standart USer
            evernoteUser standartUser = new evernoteUser()
            {
                name = "Nur",
                surname = "Yiğit",
                eMail = "nuryigit11@gmail.com",
                activeGuid = Guid.NewGuid(),
                isAdmin = false,
                ısActive = true,
                userName = "nuryigit",
                profileImageFileName = "userNoy.png",
                password = "654321",
                createdOn = DateTime.Now.AddHours(1),
                modifiedOn = DateTime.Now.AddMinutes(75),
                modifiedUserName = "nuryigit"
            };

            context.evernoteUsers.Add(admin);
            context.evernoteUsers.Add(standartUser);


            for (int a = 0; a < 25; a++)
            {
                evernoteUser user = new evernoteUser()
                {
                    name = FakeData.NameData.GetFirstName(),
                    surname = FakeData.NameData.GetSurname(),
                    eMail = FakeData.NetworkData.GetEmail(),
                    activeGuid = Guid.NewGuid(),
                    isAdmin = false,
                    ısActive = true,
                    userName = $"user{a}",
                    profileImageFileName = "userNoy.png",
                    password = "123",
                    createdOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    modifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    modifiedUserName = $"user{a}"
                };
                context.evernoteUsers.Add(user);
            }
            context.SaveChanges();


            List<evernoteUser> userlist = context.evernoteUsers.ToList();

            // Adding Fake Categories
            for (int i = 0; i < 8; i++)
            {
                category cat = new category()
                {
                    title = FakeData.PlaceData.GetStreetName(),
                    description = FakeData.PlaceData.GetAddress(),
                    createdOn = DateTime.Now,
                    modifiedOn = DateTime.Now,
                    modifiedUserName = "busranuryigit",
                };
                context.Catagories.Add(cat);
                //   Adding Fake Notes
                for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
                {
                    evernoteUser noteOwner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];
                    note not = new note()
                    {
                        title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        Category = cat,
                        likeCount = FakeData.NumberData.GetNumber(1, 9),
                        isDraft = false,
                        owner = noteOwner,
                        createdOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        modifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        modifiedUserName = noteOwner.userName,


                    };
                    cat.Notes.Add(not);

                    //  Addin Fake Comments

                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        evernoteUser commentOwner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];
                        comment com = new comment()
                        {
                            text = FakeData.TextData.GetSentence(),
                            Notes = not,
                            Owner = commentOwner,
                            createdOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            modifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            modifiedUserName = commentOwner.userName,

                        };
                        not.Comments.Add(com);
                    }
                    //Adding Fake Likes


                    for (int l = 0; l < not.likeCount; l++)
                    {
                        liked like = new liked()
                        {
                            userLiked = userlist[l]

                        };
                        not.Likes.Add(like);
                    }


                }

            }

            context.SaveChanges();
        }
    }
}
