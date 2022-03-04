using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_PROJ
{
    public record UserEntity(Guid UserID,
        string Name,
        string Surname,
        string? Photo)
    {

    }
}
