using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace JukeboxMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string MediaFileDirectory = Directory.GetCurrentDirectory() + "\\Media\\";

        int NoOfLists;

        string[] ListOne = new string[20];
        string[] ListTwo = new string[20];
        string[] ListThree = new string[20];

        ListBox[] DisplayListBox = new ListBox[3];


        private void Form1_Load(object sender, EventArgs e)
        {


            ReadTextFile();

            hScrollBar.Maximum = NoOfLists - 1;

            DisplayListBox[0] = new ListBox();
            DisplayListBox[0].Items.Add(ListOne[1]);
            DisplayListBox[0].Items.Add(ListOne[2]);

            DisplayListBox[1] = new ListBox();
            DisplayListBox[1].Items.Add(ListTwo[1]);
            DisplayListBox[1].Items.Add(ListTwo[2]);

            DisplayListBox[2] = new ListBox();
            DisplayListBox[2].Items.Add(ListThree[1]);
            DisplayListBox[2].Items.Add(ListThree[2]);
            DisplayListBox[2].Items.Add(ListThree[3]);
            


        }


        private void ReadTextFile()
        {
            StreamReader myInputStream = File.OpenText(MediaFileDirectory + "Media.txt");
            string LineOfText;
            LineOfText = myInputStream.ReadLine();
            if (int.TryParse(LineOfText, out NoOfLists))
            {
                NoOfLists = Convert.ToInt32(LineOfText);
                MessageBox.Show(NoOfLists.ToString());
            }


            //List One Data Entry//
            int Counter = 0;
            ListOne[Counter] = myInputStream.ReadLine();
            Counter++;
            ListOne[Counter] = myInputStream.ReadLine();
            Counter++;
            for (int index = 0; index < Convert.ToInt32(ListOne[0]); index++)
            {
                ListOne[Counter] = myInputStream.ReadLine();
                Counter++;
            }
            //List Two Data Entry//
            Counter = 0;
            ListTwo[Counter] = myInputStream.ReadLine();
            Counter++;
            ListTwo[Counter] = myInputStream.ReadLine();
            Counter++;
            for (int index = 0; index < Convert.ToInt32(ListTwo[0]); index++)
            {
                ListTwo[Counter] = myInputStream.ReadLine();
                Counter++;
            }
            //List Two Data Entry//
            Counter = 0;
            ListThree[Counter] = myInputStream.ReadLine();
            Counter++;
            ListThree[Counter] = myInputStream.ReadLine();
            Counter++;
            for (int index = 0; index < Convert.ToInt32(ListThree[0]); index++)
            {
                ListThree[Counter] = myInputStream.ReadLine();
                Counter++;
            }


        }

        private void hScrollBar_ValueChanged(object sender, EventArgs e)
        {
            int WhichList = hScrollBar.Value;
            MessageBox.Show(WhichList.ToString());
            
        }
    }
}
