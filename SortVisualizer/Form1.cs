namespace SortVisualizer {

    public partial class Form1 : Form {

        int[] theArray;
        
        Graphics g;

        Thread sortingThread;

        public Form1() {

            InitializeComponent();

        }

        private void btnReset_Click(object sender, EventArgs e) {

            if (sortingThread != null) sortingThread.Interrupt();
            
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

        void StartBubbleSort() {

            ISortEngine bubbleSort = new BubbleSort();

            bubbleSort.Sort(theArray, g, panel1.Height);

        }

        private void btnStart_Click(object sender, EventArgs e) {

            sortingThread = new Thread(StartBubbleSort);

            sortingThread.Start();

        }

        private void Form1_Load(object sender, EventArgs e) {





        }

    }
    
}
