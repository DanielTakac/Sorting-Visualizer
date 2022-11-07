namespace SortVisualizer {
    
    public partial class Form1 : Form {

        int[] theArray;
        Graphics g;

        public Form1() {
        
            InitializeComponent();
        
        }

        private void btnReset_Click(object sender, EventArgs e) {

            g = panel1.CreateGraphics();

            int numEntries = panel1.Width;
            int maxVal = panel1.Height;

            theArray = new int[numEntries];

            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, numEntries, maxVal);

            Random rand = new Random();

            for (int i = 0; i < numEntries; i++) {

                theArray[i] = rand.Next(0, maxVal);

            }

            for (int i = 0; i < numEntries; i++) {

                g.FillRectangle(new SolidBrush(Color.White), i, maxVal - theArray[i], 1, maxVal);

            }

        }

        private void btnStart_Click(object sender, EventArgs e) {

            ISortEngine bubbleSort = new BubbleSort();
            
            bubbleSort.DoWork(theArray, g, panel1.Height);

        }
        
    }
    
}
