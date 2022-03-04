using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_PROJ
{
    internal class UserEntity
    {
        public Guid UserID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Photo { get; private set; }
    }
}
