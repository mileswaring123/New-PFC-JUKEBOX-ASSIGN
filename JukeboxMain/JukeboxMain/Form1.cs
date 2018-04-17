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
            if (WhichList == 0)//if the list chosen is the first one
            {
                listSelected = 0;//sets the list selected 
                if (IsSongPlaying == true)//if a song is alread playing
                {
                    AddToPlaylist();//call the playlist function
                }
                else if (IsSongPlaying == false)//if a song isnt playing
                {
                    PresentlyPlaying_txt.Text = ListOne[SelectedIndex + 2];//add the song chosen to the presenetly playing text box
                    string FullTrackPath = TrackFileDirectory + PresentlyPlaying_txt.Text;//create the full path so the song can be played
                    WindowsMediaPlayer.URL = FullTrackPath;//give the media player the path
                    WindowsMediaPlayer.Ctlcontrols.play();//play the media player
                    IsSongPlaying = true;//enable song is playing
                    Timer.Enabled = false;//stop the timer
                }
            }
            if (WhichList == 1)//if the list chosen is the second one
            {
                listSelected = 1;//sets the list selected 
                if (IsSongPlaying == true)//if a song is alread playing
                {
                    AddToPlaylist();//call the playlist function
                }
                else if (IsSongPlaying == false)//if a song isnt playing
                {
                    PresentlyPlaying_txt.Text = ListOne[SelectedIndex + 2];//add the song chosen to the presenetly playing text box
                    string FullTrackPath = TrackFileDirectory + PresentlyPlaying_txt.Text;//create the full path so the song can be played
                    WindowsMediaPlayer.URL = FullTrackPath;//give the media player the path
                    WindowsMediaPlayer.Ctlcontrols.play();//play the media player
                    IsSongPlaying = true;//enable song is playing
                    Timer.Enabled = false;//stop the timer
                }
            }
            if (WhichList == 2)//if the list chosen is the thrid one
            {
                listSelected = 2;//sets the list selected 
                if (IsSongPlaying == true)//if a song is alread playing
                {
                    AddToPlaylist();//call the playlist function
                }
                else if (IsSongPlaying == false)//if a song isnt playing
                {
                    PresentlyPlaying_txt.Text = ListOne[SelectedIndex + 2];//add the song chosen to the presenetly playing text box
                    string FullTrackPath = TrackFileDirectory + PresentlyPlaying_txt.Text;//create the full path so the song can be played
                    WindowsMediaPlayer.URL = FullTrackPath;//give the media player the path
                    WindowsMediaPlayer.Ctlcontrols.play();//play the media player
                    IsSongPlaying = true;//enable song is playing
                    Timer.Enabled = false;//stop the timer
                }
            }
        }

        private void AddToPlaylist()
        {
            if(listSelected == 0) //if list 1 is selected
            {
                PlayList_Lst.Items.Add(ListOne[SelectedIndex + 2]);//add selected song to the playlist list box
            }
            if (listSelected == 1)//if list 2 is selected
            {
                PlayList_Lst.Items.Add(ListTwo[SelectedIndex + 2]);//add selected song to the playlist list box
            }
            if (listSelected == 2)//if list 3 is selected
            {
                PlayList_Lst.Items.Add(ListThree[SelectedIndex + 2]);//add selected song to the playlist list box
            }
        }

        private void WindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(WindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)//if the media player is stopped
            {
                IsSongPlaying = false;//song isnt playing
                Timer.Enabled = true;//enable the timer
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(WindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)//if the media player is stopped
            {
                Timer.Enabled = false;//stop the timer
                GoToNextTrack();//call function to move next track into the presently playing
                
            }
        }

        private void GoToNextTrack()
        {
            PresentlyPlaying_txt.Text = PlayList_Lst.Items[0].ToString();//put the next song into the presently playing text box
            PlayList_Lst.Items.RemoveAt(0);//remove the item in the list

            string FullPathTrack = TrackFileDirectory + PresentlyPlaying_txt.Text;//create a full path for the media player
            WindowsMediaPlayer.URL = FullPathTrack;//give the media player the path 
            WindowsMediaPlayer.Ctlcontrols.play();//play the media player
            IsSongPlaying = true;//enable song playing as true

        }

        private void setUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUp setUp = new SetUp();//creates a new set up page
            setUp.ShowDialog();//opens up the page
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();//creates a new about page
            about.ShowDialog();//opens up the page
        }
    }
}
