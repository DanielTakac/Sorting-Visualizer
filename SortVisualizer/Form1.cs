using System;
using System.Runtime.CompilerServices;

namespace SortVisualizer {

    public partial class Form1 : Form {

        int[] theArray;
        
        Graphics g;

        Thread sortingThread;

        string sortingTime = string.Empty;

        public Form1() {

            InitializeComponent();

            sortingTimeLabel.Text = string.Empty;

            PopulateDropdown();

        }

        private void PopulateDropdown() {

            List<string> classList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISortEngine).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name).ToList();

            foreach (string entry in classList) comboBox1.Items.Add(entry);

            comboBox1.SelectedIndex = 0;

        }

        private void btnReset_Click(object sender, EventArgs e) {

            if (sortingThread != null) sortingThread.Interrupt();

            Reset();

        }

        void StartBubbleSort() {

            ISortEngine bubbleSort = new BubbleSort();

            sortingTime = bubbleSort.Sort(theArray, g, panel1.Height);

            this.sortingTimeLabel.Invoke((MethodInvoker)delegate {
                sortingTimeLabel.Text = $"Finished in {sortingTime} ms";
            });

        }

        private void btnStart_Click(object sender, EventArgs e) {

            sortingThread = new Thread(StartBubbleSort);

            sortingThread.Start();

        }

        private void Reset() {

            g = panel1.CreateGraphics();

            int numEntries = panel1.Width;
            int maxVal = panel1.Height;

            theArray = new int[numEntries];

            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, numEntries, maxVal);

            for (int i = 0; i < numEntries; i++) {

                theArray[i] = maxVal - i;

            }

            // Suffle the array

            Random rand = new Random();

            theArray = theArray.OrderBy(x => rand.Next()).ToArray();

            for (int i = 0; i < numEntries; i++) {

                g.FillRectangle(new SolidBrush(Color.White), i, maxVal - theArray[i], 1, maxVal);

            }

            sortingTime = string.Empty;

            sortingTimeLabel.Text = string.Empty;

        }

        private void Form1_Shown(object sender, EventArgs e) {

            Reset();

        }

    }
    
}
