using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{

    public interface IModel<T>
    {
        T ID { get; }
    }
}
