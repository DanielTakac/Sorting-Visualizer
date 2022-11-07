using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer {

    public class BubbleSort : ISortEngine {

        private bool _sorted = false;
        private int[] theArray;
        private Graphics g;
        private int maxVal;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        
        public void DoWork(int[] theArray_In, Graphics g_In, int maxVal_In) {

            theArray = theArray_In;
            g = g_In;
            maxVal = maxVal_In;

            SortingAlgorithms.BubbleSort(theArray);
    
        }
    
    }

}
