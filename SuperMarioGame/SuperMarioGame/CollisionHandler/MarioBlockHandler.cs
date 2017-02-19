
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.CollisionHandler
{
    class MarioBlockHandler
    {

        public static void BlockHandler(Mario mario, IBlock brickBlock, int CollisionSide)
        {
            Vector2 newPosition;
            switch (CollisionSide){
                case 1:
                    newPosition = brickBlock.position;
                    newPosition.X = mario.position.X;
                    newPosition.Y -= mario.state.marioSprite.desRectangle.Height;
                    mario.position = newPosition;
                    break;
                case 2:
                    newPosition = brickBlock.position;
                    newPosition.Y = mario.position.Y;
                    newPosition.X += mario.state.marioSprite.desRectangle.Width;
                    mario.position = newPosition;
                    break;
                case 3:
                    newPosition = brickBlock.position;
                    newPosition.X = mario.position.X;
                    newPosition.Y += mario.state.marioSprite.desRectangle.Height;
                    mario.position = newPosition;
                    break;
                case 4:
                    newPosition = brickBlock.position;
                    newPosition.Y = mario.position.Y;
                    newPosition.X -= mario.state.marioSprite.desRectangle.Width;
                    mario.position = newPosition;
                    break;
            }
        }
    }
}
