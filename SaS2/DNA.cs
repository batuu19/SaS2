using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2
{
    public class DNA
    {
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Vitality { get; set; }
        public int Charisma { get; set; }
        public int Stamina { get; set; }
        public int Magicka { get; set; }

        public DNA() { }
        public DNA(int initValue)
        {
            Strength = initValue;
            Speed = initValue;
            Attack = initValue;
            Defence = initValue;
            Vitality = initValue;
            Charisma = initValue;
            Stamina = initValue;
            Magicka = initValue;
        }

        public int this[int key]
        {
            get
            {
                switch (key)
                {
                    case 0:
                        return Strength;
                    case 1:
                        return Speed;
                    case 2:
                        return Attack;
                    case 3:
                        return Defence;
                    case 4:
                        return Vitality;
                    case 5:
                        return Charisma;
                    case 6:
                        return Stamina;
                    case 7:
                        return Magicka;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (key)
                {
                    case 0:
                         Strength = value;
                        break;
                    case 1:
                         Speed = value;
                        break;
                    case 2:
                         Attack = value;
                        break;
                    case 3:
                         Defence = value;
                        break;
                    case 4:
                         Vitality = value;
                        break;
                    case 5:
                         Charisma = value;
                        break;
                    case 6:
                         Stamina = value;
                        break;
                    case 7:
                         Magicka = value;
                        break;
                }
            }
        }
    }
}
