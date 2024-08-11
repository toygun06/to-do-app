using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Constants
{
    public class UserMessage
    {
        public static string UserNotAvailable
        {
            get 
            {
                return "Kullanıcı mevcut değil!";
            }
        }
        public static string DuplicateEmail
        {
            get
            {
                return "Bu email adresi zaten mevcut!";
            }
        }
    }
}
