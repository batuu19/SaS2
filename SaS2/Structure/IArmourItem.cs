using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Structure
{
    public interface IArmourItem : IItem
    {
        int SpecialChance { get; set; }
        int ArmourValue { get; set; }
    }
}
