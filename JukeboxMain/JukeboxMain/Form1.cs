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


        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader myInputStream = File.OpenText(MediaFileDirectory + "Media.txt");
            string LineOfText;
            int LineCounter = 0;
            while((LineOfText = myInputStream.ReadLine()) != null)
            { 
                //MessageBox.Show(LineOfText);
            }
        }
    }
}
