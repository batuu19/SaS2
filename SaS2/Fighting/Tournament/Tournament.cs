using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting.Tournament
{
    class Tournament : IContinuable
    {
        public TournamentInfo Info { get; set; }

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Finish()
        {
            throw new NotImplementedException();
        }

        public bool NextMove()
        {
            throw new NotImplementedException();
        }
    }
}
