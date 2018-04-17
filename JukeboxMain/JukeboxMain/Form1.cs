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
        string MediaFileDirectory = Directory.GetCurrentDirectory() + "\\Media\\"; //Storing the media folder directory into a global variable
        string TrackFileDirectory = Directory.GetCurrentDirectory() + "\\Tracks\\"; //Storing the media folder directory into a global variable
        int NoOfLists; //global variable that stores the amount of playlists that are in the text file

        int SelectedIndex; //global variable to keep track of the song chosen by the user
        int listSelected; //gloabl variable to keep track of the list the song relates too 

        bool IsSongPlaying = false; //bool variable to see if the song is playing or not

        string[] ListOne = new string[20]; //string array to hold the information from the first group of info
        string[] ListTwo = new string[20];//string array to hold the information from the second group of info
        string[] ListThree = new string[20];//string array to hold the information from the thrid group of info

        string[] Playlist = new string[20];//string array to keep track of all the songs in the playlst

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadTextFile(); //calls the function to read the text file
            hScrollBar.Maximum = NoOfLists - 1; // sets the size of the scroll bar
            DisplayInitialList();//calls the function to output the text file data

        }

        private void ReadTextFile()
        {
            StreamReader myInputStream = File.OpenText(MediaFileDirectory + "Media.txt"); //opens up the text file document
            string LineOfText;//variable to store a line of text in 
            LineOfText = myInputStream.ReadLine();//reads a line of text into the variable
            if (int.TryParse(LineOfText, out NoOfLists))
            {
                NoOfLists = Convert.ToInt32(LineOfText);//stores the amount of lists into a variable
            }


            //List One Data Entry//
            int Counter = 0; //initiate a counter var
            ListOne[Counter] = myInputStream.ReadLine();//reads a line of the text file
            Counter++;//increment the counter
            ListOne[Counter] = myInputStream.ReadLine();//reads a line of the text file
            Counter++;//increment the counter
            for (int index = 0; index < Convert.ToInt32(ListOne[0]); index++)//for loop to go through the first list
            {
                ListOne[Counter] = myInputStream.ReadLine();//reads a line of the text file
                Counter++;//increment the counter
            }
            //List Two Data Entry//
            Counter = 0;//initiate a counter var
            ListTwo[Counter] = myInputStream.ReadLine();//reads a line of the text file
            Counter++;//increment the counter
            ListTwo[Counter] = myInputStream.ReadLine();//reads a line of the text file
            Counter++;//increment the counter
            for (int index = 0; index < Convert.ToInt32(ListTwo[0]); index++)//for loop to go through the second list
            {
                ListTwo[Counter] = myInputStream.ReadLine();//reads a line of the text file
                Counter++;//increment the counter
            }
            //List Two Data Entry//
            Counter = 0;//initiate a counter var
            ListThree[Counter] = myInputStream.ReadLine();//reads a line of the text file
            Counter++;//increment the counter
            ListThree[Counter] = myInputStream.ReadLine();//reads a line of the text file
            Counter++;//increment the counter
            for (int index = 0; index < Convert.ToInt32(ListThree[0]); index++)//for loop to go through the thrid list
            {
                ListThree[Counter] = myInputStream.ReadLine();//reads a line of the text file
                Counter++;//increment the counter
            }


        }

        private void hScrollBar_ValueChanged(object sender, EventArgs e)
        {
            int WhichList = hScrollBar.Value;//sets the value of the scroll bar to local var
            Genrelist_Lst.Items.Clear();//clears the current list
            if (WhichList == 0)//if the list chosen is the first one
            {
                DisplayInitialList();//call function to display info
            }
            if (WhichList == 1)//if the list chosen is the second one
            {
                GenreTitle_txt.Text = ListTwo[1];//inputs the genre title to the text box
                int repeat = Convert.ToInt32(ListTwo[0]);//works out how many songs are in the group 
                int select_Song = 2;//var to find the right location in the array
                for (int index = 0; index < repeat; index++)//for loop to go through the loop
                {
                    Genrelist_Lst.Items.Add(ListTwo[select_Song]);//display each bit of data in the list box
                    select_Song++;//increment the variable
                }
            }
            if (WhichList == 2)//if the list chosen is the third one
            {
                GenreTitle_txt.Text = ListThree[1];//inputs the genre title to the text box
                int repeat = Convert.ToInt32(ListThree[0]);//works out how many songs are in the group 
                int select_Song = 2;//var to find the right location in the array
                for (int index = 0; index < repeat; index++)//for loop to go through the loop
                {
                    Genrelist_Lst.Items.Add(ListThree[select_Song]);//display each bit of data in the list box
                    select_Song++;//increment the variable
                }

            }

        }
        private void DisplayInitialList()
        {
            GenreTitle_txt.Text = ListOne[1];//inputs the genre title to the text box
            int repeat = Convert.ToInt32(ListOne[0]);//works out how many songs are in the group
            int select_Song = 2;//var to find the right location in the array
            for (int index = 0; index < repeat; index++)//for loop to go through the loop
            {
                Genrelist_Lst.Items.Add(ListOne[select_Song]);//display each bit of data in the list box
                select_Song++;//increment the variable
            }

        }

        private void Genrelist_Lst_DoubleClick(object sender, EventArgs e)
        {
            SelectedIndex = Genrelist_Lst.SelectedIndex;//gets the index of the song selected by the user
            int WhichList = hScrollBar.Value;//finds out which list the user has selected from 
            if (WhichList == 0)//if the list chosen is the second one
            {
                listSelected = 0;
                if (IsSongPlaying == true)
                {
                    AddToPlaylist();
                }
                else if (IsSongPlaying == false)
                {
                    PresentlyPlaying_txt.Text = ListOne[SelectedIndex + 2];
                    string FullTrackPath = TrackFileDirectory + PresentlyPlaying_txt.Text;
                    WindowsMediaPlayer.URL = FullTrackPath;
                    WindowsMediaPlayer.Ctlcontrols.play();
                    IsSongPlaying = true;
                    Timer.Enabled = false;
                }
            }
            if (WhichList == 1)
            {
                listSelected = 1;
                if (IsSongPlaying == true)
                {
                    AddToPlaylist();
                }
                else if (IsSongPlaying == false)
                {
                    PresentlyPlaying_txt.Text = ListOne[SelectedIndex + 2];
                    string FullTrackPath = TrackFileDirectory + PresentlyPlaying_txt.Text;
                    WindowsMediaPlayer.URL = FullTrackPath;
                    WindowsMediaPlayer.Ctlcontrols.play();
                    IsSongPlaying = true;
                    Timer.Enabled = false;
                }
            }
            if (WhichList == 2)
            {
                listSelected = 2;
                if (IsSongPlaying == true)
                {
                    AddToPlaylist();
                }
                else if (IsSongPlaying == false)
                {
                    PresentlyPlaying_txt.Text = ListOne[SelectedIndex + 2];
                    string FullTrackPath = TrackFileDirectory + PresentlyPlaying_txt.Text;
                    WindowsMediaPlayer.URL = FullTrackPath;
                    WindowsMediaPlayer.Ctlcontrols.play();
                    IsSongPlaying = true;
                    Timer.Enabled = false;
                }
            }
        }

        private void AddToPlaylist()
        {
            if(listSelected == 0)
            {

                PlayList_Lst.Items.Add(ListOne[SelectedIndex + 2]);
            }
            if (listSelected == 1)
            {

                PlayList_Lst.Items.Add(ListTwo[SelectedIndex + 2]);
            }
            if (listSelected == 2)
            {

                PlayList_Lst.Items.Add(ListThree[SelectedIndex + 2]);
            }

        }

        private void WindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(WindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                IsSongPlaying = false;
                Timer.Enabled = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(WindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                Timer.Enabled = false;
                GoToNextTrack();
                
            }
        }

        private void GoToNextTrack()
        {
            PresentlyPlaying_txt.Text = PlayList_Lst.Items[0].ToString();
            PlayList_Lst.Items.RemoveAt(0);

            string FullPathTrack = TrackFileDirectory + PresentlyPlaying_txt.Text;
            WindowsMediaPlayer.URL = FullPathTrack;
            WindowsMediaPlayer.Ctlcontrols.play();
            IsSongPlaying = true;

        }
    }
}
