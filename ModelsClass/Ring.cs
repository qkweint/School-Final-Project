using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClass
{
    public class Ring
    {
        public int ringID { get; set; }
        public string metal { get; set; }
        public int gemID { get; set; }

        public Ring(int ringID, string metal, int gemID)
        {
            this.ringID = ringID;
            this.metal = metal;
            this.gemID = gemID;
        }
        public Ring() { }
    }
}
