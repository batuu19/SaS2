using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Structure
{
    public interface IItem
    {
        string Name { get; set; }
        int RequiredLevel { get; set; }
        int Price { get; set; }
    }
}
