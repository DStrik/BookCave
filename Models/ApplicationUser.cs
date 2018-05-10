using System;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Models
{
    public class ApplicationUser : IdentityUser
    {
        public static object User { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FavBookId { get; set; }

        internal static object FindById(object p)
        {
            throw new NotImplementedException();
        }
    }
}