using System.Collections.Generic;

namespace CustomerPost.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                UserName = "mehmeterdem",
                EmailAddress = "mehmet@gmail.com",
                Password = "Password1",
                GivenName = "Mehmet",
                Surname = "Erdem",
                Role = "Administrator"
            },
            new UserModel()
            {
                UserName = "fiction",
                EmailAddress = "fiction@gmail.com",
                Password = "Password",
                GivenName = "Fiction",
                Surname = "Microsoft",
                Role = "Seller",
            }
        };
    }
}
