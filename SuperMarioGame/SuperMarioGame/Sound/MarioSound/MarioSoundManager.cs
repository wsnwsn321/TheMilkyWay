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

namespace SuperMarioGame.Sound.MarioSound
{
    public class MarioSoundManager 
    {
        public static MarioSoundManager instance = new MarioSoundManager();
        
        List<SoundEffect> soundEffects;
        SoundEffectInstance var;
        
        public const  string ONEUP = "1UP", BOWSERFALL = "boswerFall", BREAKBLOCK = "breakBlock", BUMP = "bump", COIN = "coin", FIREBALL = "fireBall",FIREWORKS ="fireWorks", FLAGPOLE = "flagPole", GAMEOVER = "gameOver",
                            JUMPSMALL = "jumpsmall", JUMPSUPER = "jumpSuper", KICK = "kick", MARIODIE = "marioDie", PAUSE = "pause", PIPE = "pipe", POWERUPAPPEARS = "powerAppears", STAGECLEAR = "stageClear",
                            STOMP = "stomp", VINE = "vine", WARNING = "warning", WORLDCLEAR = "worldClear",POWERUP="powerUp";
        private MarioSoundManager()
        {
            soundEffects = new List<SoundEffect>();

        }
        public void LoadSound(ContentManager content)
        {
        
            
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
            //#21
            soundEffects.Add(content.Load<SoundEffect>("Sound/Mario/smb_powerup"));
        }

        public void playSound(String order)
        {
            switch (order)
            {
                case ONEUP:
                    var = soundEffects[0].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case BOWSERFALL:
                    var = soundEffects[1].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case BREAKBLOCK:
                    var = soundEffects[2].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case BUMP:
                    var = soundEffects[3].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case COIN:
                    var = soundEffects[4].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case FIREBALL:
                    var = soundEffects[5].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case FIREWORKS:
                    var = soundEffects[6].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case FLAGPOLE:
                    var = soundEffects[7].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case GAMEOVER:
                    var = soundEffects[8].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case JUMPSMALL:
                    var = soundEffects[9].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case JUMPSUPER:
                    var = soundEffects[10].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case KICK:
                    var = soundEffects[11].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case MARIODIE:
                    var = soundEffects[12].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case PAUSE:
                    var = soundEffects[13].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case PIPE:
                    var = soundEffects[14].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case POWERUPAPPEARS:
                    var = soundEffects[15].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case STAGECLEAR:
                    var = soundEffects[16].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case STOMP:
                    var = soundEffects[17].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case VINE:
                    var = soundEffects[18].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case WARNING:
                    var = soundEffects[19].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case WORLDCLEAR:
                    var = soundEffects[20].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;
                case POWERUP:
                    var = soundEffects[21].CreateInstance();
                    var.IsLooped = false;
                    var.Play();
                    break;

            }
        }     
    }
}
