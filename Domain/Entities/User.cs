using Core.Security.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseUser
    {
        public virtual ICollection<Task> Tasks {get; set;}
        public User() 
        {
            Tasks = new HashSet<Task>();
        }

        public static implicit operator bool(User? v)
        {
            throw new NotImplementedException();
        }
    }
}
