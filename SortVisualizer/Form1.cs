using System;
using System.Runtime.CompilerServices;

namespace SortVisualizer {

    public partial class Form1 : Form {

        int[] theArray;
        
        Graphics g;

        Thread sortingThread;

        ISortEngine sort;

        string sortingTime = string.Empty;

        string sortingAlgorithm = string.Empty;

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

            if (sort != null) sort.canRun = false;

            Reset();

        }

        void StartSort() {

            if (sort != null) return;

            bool finishedSuccessfully = false;

            sort = (ISortEngine)Activator.CreateInstance(Type.GetType("SortVisualizer." + sortingAlgorithm));

            sortingTime = sort.Sort(theArray, g, panel1.Height, ref finishedSuccessfully);

            sort = null;

            sortingTimeLabel.Invoke((MethodInvoker)delegate {
                
                if (finishedSuccessfully) {

                    sortingTimeLabel.Text = $"Finished in {sortingTime} ms";

                } else {

                    sortingTimeLabel.Text = string.Empty;

                }

            });

        }

        private void btnStart_Click(object sender, EventArgs e) {

            sortingThread = new Thread(StartSort);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

            if (comboBox1.SelectedItem.ToString() == null) return;
            
            sortingAlgorithm = comboBox1.SelectedItem.ToString();

        }
    }
    
}
