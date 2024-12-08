using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mohjang
{
    [Serializable]
    public class KlocekState
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        public bool WasVisible { get; set; }
        public int Flaga { get; set; }
        public Point Location { get; set; }
    }

}
