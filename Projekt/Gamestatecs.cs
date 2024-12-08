using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mohjang
{
    [Serializable]
    public class GameState
    {
        public int Stones { get; set; }
        public KlocekState[] KlockiStates { get; set; }
    }
}
