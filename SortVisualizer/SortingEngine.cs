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
            maxVal = maxVal_In;
            g = g_In;

            int[] referenceArray = new int[theArray.Length];
            
            Array.Copy(theArray, referenceArray, theArray.Length);
            Array.Sort(referenceArray);

            while (!theArray.SequenceEqual(referenceArray)) {

                for (int i = 0; i < theArray.Length - 1; i++) {

                    if (theArray[i] > theArray[i + 1]) {

                        (theArray[i], theArray[i + 1]) = (theArray[i + 1], theArray[i]);
                        
                        g.FillRectangle(blackBrush, i, 0, 1, maxVal);
                        g.FillRectangle(blackBrush, i + 1, 0, 1, maxVal);

                        g.FillRectangle(whiteBrush, i, maxVal - theArray[i], 1, maxVal);
                        g.FillRectangle(whiteBrush, i + 1, maxVal - theArray[i + 1], 1, maxVal);

                    }

                }

            }

        }
    
    }

}
