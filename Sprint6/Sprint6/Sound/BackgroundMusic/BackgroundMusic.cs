using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Sprint6.Sound.BackgroundMusic
{
    public class BackgroundMusic
    {
        public static BackgroundMusic instanse = new BackgroundMusic();
        private int mash = 4;
        List<Song> BGM;
        Song var;
        public const int BACKGROUNGMUSIC1 = 1, BACKGROUNGMUSIC2 = 2, BACKGROUNGMUSIC3 = 3, BACKGROUNGMUSIC4 = 4, BACKGROUNGMUSIC5= 5;
        private int currentBGM;
        private BackgroundMusic()
        {
            BGM = new List<Song>();
     
        }
        public void LoadSound(ContentManager content)
        {
            //#1
            BGM.Add(content.Load<Song>("Sound/UFOGameLevelMusic/Level1"));
           
            //#2
            BGM.Add(content.Load<Song>("Sound/UFOGameLevelMusic/Level2"));
       
            //#3
            BGM.Add(content.Load<Song>("Sound/UFOGameLevelMusic/Level3"));
          
            //#4
            BGM.Add(content.Load<Song>("Sound/UFOGameLevelMusic/MainMenu"));
            
           

        }

        public void playSound(int order)
        {
          
            switch (order)
            {
                case BACKGROUNGMUSIC1:
                    var = BGM[0];
                    MediaPlayer.Play(var);
                    currentBGM = BACKGROUNGMUSIC1;
                    break;
                case BACKGROUNGMUSIC2:
                    var = BGM[1];
                    MediaPlayer.Play(var);
                    currentBGM = BACKGROUNGMUSIC2;
                    break;
                case BACKGROUNGMUSIC3:
                    var = BGM[2];
                    MediaPlayer.Play(var);
                    currentBGM = BACKGROUNGMUSIC3;
                    break;

                case BACKGROUNGMUSIC4:
                    var = BGM[3];
                    MediaPlayer.Play(var);
                    currentBGM = BACKGROUNGMUSIC4;
                    break;
                case BACKGROUNGMUSIC5:
                    var = BGM[4];
                    MediaPlayer.Play(var);
                    currentBGM = BACKGROUNGMUSIC5;
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
