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
            int maxValue = panel1.Height;

            theArray = new int[numEntries];

            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, numEntries, maxValue);

            Random rand = new Random();

            for (int i = 0; i < numEntries; i++) {

                theArray[i] = rand.Next(0, maxValue);

            }

            for (int i = 0; i < numEntries; i++) {

                g.FillRectangle(new SolidBrush(Color.White), i, maxValue - theArray[i], 1, maxValue);

            }

        }

    }
    
}
