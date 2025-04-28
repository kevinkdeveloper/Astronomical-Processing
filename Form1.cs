using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astronomical_Processing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataGeneration();

            DisplayNeutrinoData();
        }

        static int max = 24;
        int[] neutrinoData = new int[max];

        private void DataGeneration()
        {
            Random random = new Random();
            for (int i = 0; i < max; i++)
            {
                neutrinoData[i] = random.Next(10, 91); // Rnage from 10 to 90
            }
        }

        private void DisplayNeutrinoData()
        {
            NeutrinoDataListBox.Items.Clear();
            for (int i = 0; i < max; i++)
            {
                NeutrinoDataListBox.Items.Add(neutrinoData[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp = 0;
            for (int outer = 0; outer < max; outer++)
            {
                for (int inner = 0; inner < max - 1; inner++)
                {
                    if (neutrinoData[inner] > neutrinoData[inner + 1])
                    {
                        // Swap the elements
                        temp = neutrinoData[inner];
                        neutrinoData[inner] = neutrinoData[inner + 1];
                        neutrinoData[inner + 1] = temp;
                    }
                    ShowArray();
                }
            }
        }
        private void ShowArray()
        {
            NeutrinoDataListBox.Items.Clear();
            for (int i = 0; i < max; i++)
            {
                NeutrinoDataListBox.Items.Add(neutrinoData[i]);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e); // Sort the array first
            MessageBox.Show("Array sorted. Now searching for the value...");

            int mid;
            int low = 0;
            int high = max;
            int target;

            if (!(Int32.TryParse(txtSearch.Text, out target)))
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }

            // Binary Search
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (neutrinoData[mid] == target)
                {
                    MessageBox.Show($"Found {target} at index {mid}.");
                    return;
                }
                else if (neutrinoData[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Edit values at specified index
            int index;
            if (!Int32.TryParse(txtEditIndex.Text, out index))
            {
                MessageBox.Show("Please enter a valid index.");
                return;
            }
            else
            {
                neutrinoData[index] = Int32.Parse(txtEditValue.Text);
                // Show message of edited value
                MessageBox.Show($"Index:{index}, changed to:{txtEditValue.Text}.");
                ShowArray();
            } 
        }
    }
}
