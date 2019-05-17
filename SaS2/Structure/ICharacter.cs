using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Structure
{
    public interface ICharacter
    {
        DNA DNA { get; set; }
        Equipment Equipment { get; set; }
    }
}
