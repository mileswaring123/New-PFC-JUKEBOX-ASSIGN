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
        string TrackFileDirectory = Directory.GetCurrentDirectory() + "\\Tracks\\";
        int NoOfLists;

        int SelectedIndex;

        bool IsSongPlaying = false;

        string[] ListOne = new string[20];
        string[] ListTwo = new string[20];
        string[] ListThree = new string[20];

        string[] Playlist = new string[20];

        ListBox[] DisplayListBox = new ListBox[3];


        private void Form1_Load(object sender, EventArgs e)
        {


            ReadTextFile();
            ConfigureListBoxes();
            hScrollBar.Maximum = NoOfLists - 1;


            DisplayInitialList();

        }

        private void ConfigureListBoxes()
        {
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
            Genrelist_Lst.Items.Clear();
            if (WhichList == 0)
            {
                DisplayInitialList();
            }
            if (WhichList == 1)
            {
                GenreTitle_txt.Text = ListTwo[1];
                int repeat = Convert.ToInt32(ListTwo[0]);
                int select_Song = 2;
                for (int index = 0; index < repeat; index++)
                {
                    Genrelist_Lst.Items.Add(ListTwo[select_Song]);
                    select_Song++;
                }
            }
            if (WhichList == 2)
            {
                GenreTitle_txt.Text = ListThree[1];
                int repeat = Convert.ToInt32(ListThree[0]);
                int select_Song = 2;
                for(int index = 0; index < repeat; index++)
                {
                    Genrelist_Lst.Items.Add(ListThree[select_Song]);
                    select_Song++;
                }

            }

        }
        private void DisplayInitialList()
        {
            GenreTitle_txt.Text = ListOne[1];
            int repeat = Convert.ToInt32(ListOne[0]);
            int select_Song = 2;
            for (int index = 0; index < repeat; index++)
            {
                Genrelist_Lst.Items.Add(ListOne[select_Song]);
                select_Song++;
            }

        }

        private void Genrelist_Lst_DoubleClick(object sender, EventArgs e)
        {
            SelectedIndex = Genrelist_Lst.SelectedIndex;
            int WhichList = hScrollBar.Value;
            if (WhichList == 0)
            {
                PresentlyPlaying_txt.Text = ListOne[SelectedIndex + 2];
                
                PlaySong();
            }
            if (WhichList == 1)
            {
                PresentlyPlaying_txt.Text = ListTwo[SelectedIndex + 2];
                
                PlaySong();
            }
            if (WhichList == 2)
            {
                PresentlyPlaying_txt.Text = ListThree[SelectedIndex + 2];
                
                PlaySong();
            }
        }

        private void PlaySong()
        {
            string FullTrackPath = TrackFileDirectory + PresentlyPlaying_txt.Text;
            MessageBox.Show(FullTrackPath);
            WindowsMediaPlayer.URL = FullTrackPath;
            WindowsMediaPlayer.Ctlcontrols.play();
        }
    }
}
