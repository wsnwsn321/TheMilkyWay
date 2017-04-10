using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


namespace SuperMarioGame.Sound.BackgroundMusic
{
    public class BackgroundMusic
    {
        public static BackgroundMusic instanse = new BackgroundMusic();
        List<SoundEffect> BGM;
        SoundEffectInstance var;
        public const string LEVEL1 = "Level1", LEVEL2 = "Level2", LEVELClEAR ="LevelClear";
        public BackgroundMusic()
        {
            BGM = new List<SoundEffect>();
        }
        public void LoadSound(ContentManager content)
        {
            //#1
             BGM.Add(content.Load<SoundEffect>("Sound/Map/Level-01"));
        }

        public void playSound(String order)
        {
          
            switch (order)
            {
                case LEVEL1:
                    var = BGM[0].CreateInstance();
                    var.Play();
                    var.IsLooped = true;
                    break;
                case LEVEL2:
                    break;
                case LEVELClEAR:
                    break;
            }
        }
    }
}
