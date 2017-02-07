using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.StateClass
{
    class CrouchMarioState : IMarioState
    {
        // 1 : small mario 
        // 2 : big mario 
        // 3 : fire mario
        private int marioState;
   
        // true: left
        // false: right
        private Boolean direction;
        private Vector2 position;
        private Mario mario;
        private SpriteBatch sp;
        private Sprites.ISprite marioSprite;
        public LeftMarioState( Mario mario, int marioState, Vector2 position, SpriteBatch sp)
        {
            this.mario = mario;
            this.marioState = marioState;
            this.position = position;
            this.sp = sp;
        }

        public void Crouch()
        {
            if (direction)
            {
                switch (marioState)
                {
                    case 1:
                        marioSprite = new SpriteFactories.MarioSpriteFactory();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }else
            {
                switch (marioState)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
           
           
        }

        public void Draw()
        {

        }
        public void ChangeForm(int form)
        {

        }

        public void Idle()
        {
         
        }

        public void Jump()
        {
            
        }

        public void Run()
        {
           
        }

        public void Update()
        {
          
        }
    }
}
