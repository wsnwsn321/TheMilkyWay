
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace SuperMarioGame.CollisionHandler
{
    class MarioBlockHandler
    {
        public static void BlockHandler(Mario mario, IBlock block, int CollisionSide)
        {
            Vector2 newPosition;
            
            switch (CollisionSide){
                case 1:
                    newPosition.X = mario.state.marioSprite.desRectangle.X;
                    newPosition.Y = block.blockSprite.desRectangle.Y - mario.state.marioSprite.desRectangle.Height;
                    mario.position = newPosition;

                    break;
                case 2:
                    newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                    newPosition.Y = mario.state.marioSprite.desRectangle.Y;
                    mario.position = newPosition;
                    break;
                case 3:
                    newPosition.X = mario.state.marioSprite.desRectangle.X;
                    newPosition.Y = block.blockSprite.desRectangle.Y + block.blockSprite.desRectangle.Height;
                    mario.position = newPosition;
                    break;
                case 4:
                    newPosition.X = block.blockSprite.desRectangle.X - mario.state.marioSprite.desRectangle.Width;
                    newPosition.Y = mario.state.marioSprite.desRectangle.Y;
                    mario.position = newPosition;
                    break;
            }
        }
    }
}
