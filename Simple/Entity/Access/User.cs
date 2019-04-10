using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Entity.Access
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }

        public object GetJWTPayload()
        {
            return new {
                Name,
                Email
            };
        }
    }
}
