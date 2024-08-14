using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tasks.Constants
{
    public static class TaskMessages
    {
        public static string TaskNotFound
        { 
            get
            {
                return "Böyle bir görev bulunamadı!";
            }
        }

        public static string DeleteWasSuccess
        {
            get
            {
                return "Silme işlemi başarılı!";
            }
        }

        public static string TaskNotFoundOfUser
        {
            get
            {
                return "Bu kullanıcıya ait görev bulunamadı!";
            }
        }
    }
}
