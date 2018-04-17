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




        private void Form1_Load(object sender, EventArgs e)
        {
            ReadTextFile();
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

            MessageBox.Show(ListOne[0]);
            MessageBox.Show(ListOne[1]);
            MessageBox.Show(ListOne[2]);
            MessageBox.Show(ListTwo[0]);
            MessageBox.Show(ListTwo[1]);
            MessageBox.Show(ListTwo[2]);
            MessageBox.Show(ListThree[0]);
            MessageBox.Show(ListThree[1]);
            MessageBox.Show(ListThree[2]);
            MessageBox.Show(ListThree[3]);
        }
    }
}
