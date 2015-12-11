using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC_Team10_Modules
{
    public class OutDataDTO
    {
        public DateTime _time { get; set; }
        public float _heartBeat { get; set; }
        public string _emotion { get; set; }
        public string _sentiment { get; set; }
    }
}
