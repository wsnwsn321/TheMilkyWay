﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sound.MarioSound;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.Commands
{
    class MainCharAttackCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;
        int  TwentyFive = 25;
        private bool bomb;
        private int count;
        private bool playing = true;
        public MainCharAttackCommand(Game1 game, bool bomb)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
            this.bomb = bomb;
            count = 0;
          
        }

        public void Execute()
        {
            if (!bomb)
            {
                if (playing && !myGame.level.mainCharacter.beamMeter.isAlmostZero())
                {
                    UFOSoundManager.instance.playSound(UFOSoundManager.LASER);
                    count = 0;
                    playing = false;
                }

                if(count > 40) { 
                    playing = true;
                }else
                {
                    count++;
                }
                
            }else
            {
                UFOSoundManager.instance.playSound(UFOSoundManager.EXP);
            }
            if (!mainCharacter.bombItem.isVisible)
            {
                myGame.level.mainCharacter.Attack(bomb);
            }
        }
    }
}