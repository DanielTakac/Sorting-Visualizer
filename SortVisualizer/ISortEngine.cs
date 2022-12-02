using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer {
    
    internal interface ISortEngine {

        string Sort(int[] theArray, Graphics g, int maxVal, ref bool finishedSuccessfully);

        public bool canRun { get; set; }

    }
    
}
