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

namespace SuperMarioGame.Sound.MarioSound
{
    public class MarioSoundManager 
    {
        public static MarioSoundManager instance = new MarioSoundManager();
        
        List<SoundEffect> soundEffects;
        
        public const  string ONEUP = "1UP", BOWSERFALL = "boswerFall", BREAKBLOCK = "breakBlock", BUMP = "bump", COIN = "coin", FIREBALL = "fireBall",FIREWORKS ="fireWorks", FLAGPOLE = "flagPole", GAMEOVER = "gameOver",
                            JUMPSMALL = "jumpsmall", JUMPSUPER = "jumpSuper", KICK = "kick", MARIODIE = "marioDie", PAUSE = "pause", PIPE = "pipe", POWERUPAPPEARS = "powerAppears", STAGECLEAR = "stageClear",
                            STOMP = "stomp", VINE = "vine", WARNING = "warning", WORLDCLEAR = "worldClear";
        public MarioSoundManager()
        {
            soundEffects = new List<SoundEffect>();

        }
        public void LoadSound(ContentManager content)
        {
            SoundEffect.MasterVolume =1.0f;
            //#0
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_1-up"));
            //#1
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_bowserfall"));
            //#2
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_breakblock"));
            //#3
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_bump"));
            //#4
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_coin"));
            //#5
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_fireball"));
            //#6
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_fireworks"));
            //#7
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_flagpole"));
            //#8
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_gameover"));
            //#9
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_jumpsmall"));
            //#10
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_jump-super"));
            //#11
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_kick"));
            //#12
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_mariodie"));
            //#13
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_pause"));
            //#14
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_pipe"));
            //#15
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_powerup_appears"));
            //#16
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_stage_clear"));
            //#17
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_stomp"));
            //#18
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_vine"));
            //#19
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_warning"));
            //#20
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_world_clear"));
            
        }

        public void playSound(String order)
        {
            switch (order)
            {
                case ONEUP:
                    soundEffects[0].Play();
                    
                    break;
                case BOWSERFALL:
                    soundEffects[1].Play();
                    break;
                case BREAKBLOCK:
                    soundEffects[2].Play();
                    break;
                case BUMP:
                    soundEffects[3].Play();
                    break;
                case COIN:
                    soundEffects[4].Play();
                    break;
                case FIREBALL:
                    soundEffects[5].Play();
                    break;
                case FIREWORKS:
                    soundEffects[6].Play();
                    break;
                case FLAGPOLE:
                    soundEffects[7].Play();
                    break;
                case GAMEOVER:
                    soundEffects[8].Play();
                    break;
                case JUMPSMALL:
                   
                    soundEffects[9].Play();
                    break;
                case JUMPSUPER:
                    soundEffects[10].Play();
                    break;
                case KICK:
                    soundEffects[11].Play();
                    break;
                case MARIODIE:
                    soundEffects[12].Play();
                    break;
                case PAUSE:
                    soundEffects[13].Play();
                    break;
                case PIPE:
                    soundEffects[14].Play();
                    break;
                case POWERUPAPPEARS:
                    soundEffects[15].Play();
                    break;
                case STAGECLEAR:
                    soundEffects[16].Play();
                    break;
                case STOMP:
                    soundEffects[17].Play();
                    break;
                case VINE:
                    soundEffects[18].Play();
                    break;
                case WARNING:
                    soundEffects[19].Play();
                    break;
                case WORLDCLEAR:
                    soundEffects[20].Play();
                    break;

            }
                
        }
      

    }
}
