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

namespace TheMilkyWay.Sound.MarioSound
{
    public class UFOSoundManager 
    {
        public static UFOSoundManager instance = new UFOSoundManager();
        
        List<SoundEffect> soundEffects;
        SoundEffectInstance var;
        
        public const  string COW ="C", LASER ="LASER", EXP ="EXP", PAUSE ="PAUSE";
        private UFOSoundManager()
        {
            soundEffects = new List<SoundEffect>();

        }
        public void LoadSound(ContentManager content)
        {
        
            
            //#0
            soundEffects.Add(content.Load<SoundEffect>("Sound/UFOGameSoundEffect/Cow"));
            //#1
            soundEffects.Add(content.Load<SoundEffect>("Sound/UFOGameSoundEffect/Laser"));
            //#2
            soundEffects.Add(content.Load<SoundEffect>("Sound/UFOGameSoundEffect/EXP"));
            //#3
            soundEffects.Add(content.Load<SoundEffect>("SOund/MainCharacter/smb_pause"));
     
      
        }

        public void playSound(String order)
        {
            switch (order)
            {
                case COW:
                    var = soundEffects[0].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case LASER:
                    var = soundEffects[1].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case EXP:
                    var = soundEffects[2].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case PAUSE:
                    var = soundEffects[2].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;

            }
        }     
    }
}
