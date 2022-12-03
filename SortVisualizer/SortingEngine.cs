using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer {

    public class BubbleSort : ISortEngine {
        
        private int[] theArray;
        private Graphics g;
        private int maxVal;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);

        public bool canRun { get; set; }

        public string Sort(int[] theArray_In, Graphics g_In, int maxVal_In, ref bool finishedSuccessfully) {

            var sw = new Stopwatch();

            sw.Start();

            theArray = theArray_In;
            maxVal = maxVal_In;
            g = g_In;
            canRun = true;
            finishedSuccessfully = false;

            int[] referenceArray = new int[theArray.Length];
            
            Array.Copy(theArray, referenceArray, theArray.Length);
            Array.Sort(referenceArray);

            while (!theArray.SequenceEqual(referenceArray)) {

                if (!canRun) {

                    finishedSuccessfully = false;
                    
                    sw.Stop();
                    
                    return sw.ElapsedMilliseconds.ToString();

                }

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

            sw.Stop();

            finishedSuccessfully = true;

            return sw.ElapsedMilliseconds.ToString();

        }
    
    }

    public class BogoSort : ISortEngine {
        
        private int[] theArray;
        private Graphics g;
        private int maxVal;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        public bool canRun { get; set; }

        public string Sort(int[] theArray_In, Graphics g_In, int maxVal_In, ref bool finishedSuccessfully) {

            var sw = new Stopwatch();

            sw.Start();

            theArray = theArray_In;
            maxVal = maxVal_In;
            g = g_In;
            finishedSuccessfully = false;

            int[] referenceArray = new int[theArray.Length];

            Array.Copy(theArray, referenceArray, theArray.Length);
            Array.Sort(referenceArray);

            while (!theArray.SequenceEqual(referenceArray)) {

                if (!canRun) {

                    finishedSuccessfully = false;

                    sw.Stop();

                    return sw.ElapsedMilliseconds.ToString();

                }

                var random = new Random();

                theArray = theArray.OrderBy(x => random.Next()).ToArray();

                g.FillRectangle(blackBrush, 0, 0, theArray.Length, maxVal);

                for (int i = 0; i < theArray.Length; i++) {

                    g.FillRectangle(whiteBrush, i, maxVal - theArray[i], 1, maxVal);

                }

            }

            sw.Stop();
            finishedSuccessfully = true;


            return sw.ElapsedMilliseconds.ToString();

        }

    }

}
