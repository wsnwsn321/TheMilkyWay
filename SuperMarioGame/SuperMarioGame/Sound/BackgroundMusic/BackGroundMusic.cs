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
    public class BackGroundMusic
    {
        public static BackGroundMusic instanse = new BackGroundMusic();
        List<SoundEffect> bgm;
        SoundEffectInstance var;

        public BackGroundMusic()
        {

        }
    }
}
