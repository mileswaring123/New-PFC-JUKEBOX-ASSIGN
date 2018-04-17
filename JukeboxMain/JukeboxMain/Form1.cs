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


        

        private void Form1_Load(object sender, EventArgs e)
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

            int test = 0;
            while(test < 10)
            {
                MessageBox.Show(ListOne[test]);
                test++;
            }
            
            //while ((LineOfText = myInputStream.ReadLine()) != null)
            //{
           // }
            
        }
    }
}
