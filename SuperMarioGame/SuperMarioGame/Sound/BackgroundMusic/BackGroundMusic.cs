using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace SuperMarioGame.Sound.BackgroundMusic
{
    public class BackgroundMusic
    {
        public static BackgroundMusic instanse = new BackgroundMusic();
        
        List<Song> BGM;
        Song var;
        public const string LEVEL1 = "Level1", LEVEL2 = "Level2", LEVELClEAR ="LevelClear", STARMAN ="Starman";
        private string currentBGM;
        private BackgroundMusic()
        {
            BGM = new List<Song>();
        }
        public void LoadSound(ContentManager content)
        {
            //#1
             BGM.Add(content.Load<Song>("Sound/Map/Level-01"));
            //#2
            BGM.Add(content.Load<Song>("Sound/Map/Level-02"));
            //#3
            BGM.Add(content.Load<Song>("Sound/Map/Starman"));

        }

        public void playSound(String order)
        {
          
            switch (order)
            {
                case LEVEL1:
                    var = BGM[0];
                    MediaPlayer.Play(var);
                    currentBGM = LEVEL1;
                    break;
                case LEVEL2:
                    var = BGM[1];
                    MediaPlayer.Play(var);
                    currentBGM = LEVEL2;
                    break;
                case STARMAN:
                    var = BGM[2];
                    MediaPlayer.Play(var);
                    break;
                
                    
            }
        }

        public void resetBGM()
        {
            playSound(currentBGM);
        }
    }
}
