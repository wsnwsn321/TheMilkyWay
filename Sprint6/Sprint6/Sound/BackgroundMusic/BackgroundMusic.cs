﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Sprint6.Sound.BackgroundMusic
{
    public class BackgroundMusic
    {
        public static BackgroundMusic instanse = new BackgroundMusic();
        private int mash = 3;
        public List<Song> BGM;
        Song var;
        public const int MainMenu = 0, LevelOne = 1, LevelTwo = 2, LevelThree = 3;
        private int currentBGM;
        private BackgroundMusic()
        {
            BGM = new List<Song>();
        }
        public void LoadSound(ContentManager content)
        {

            //#0
            BGM.Add(content.Load<Song>("Sound/UFOGameLevelMusic/MainMenu"));

            //#1
            BGM.Add(content.Load<Song>("Sound/UFOGameLevelMusic/Level1"));
           
            //#2
            BGM.Add(content.Load<Song>("Sound/UFOGameLevelMusic/Level2"));
       
            //#3
            BGM.Add(content.Load<Song>("Sound/UFOGameLevelMusic/Level3"));
            
           

        }

        public void playSound(int order)
        {

            currentBGM = order;
            switch (order)
            {
                case MainMenu:
                    var = BGM[0];
                    MediaPlayer.Play(var);
                    break;
                case LevelOne:
                    var = BGM[1];
                    MediaPlayer.Play(var);
                    break;
                case LevelTwo:
                    var = BGM[2];
                    MediaPlayer.Play(var);
                    break;
                case LevelThree:
                    var = BGM[3];
                    MediaPlayer.Play(var);
                    break;
            }
        }

        public void resetBGM()
        {
            playSound(currentBGM);
        }

        public void mashPlay()
        {
          
            System.Random randonNumber = new System.Random();
            int r = randonNumber.Next(1, mash);
            while(r == currentBGM)
            {
                r = randonNumber.Next(1, mash);
            }
            playSound(r);
        }
    }
}
