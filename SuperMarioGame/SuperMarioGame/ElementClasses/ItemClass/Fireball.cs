using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using SuperMarioGame.VolecotyTest;
using System.Collections.Generic;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class Fireball : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool hDirection { get; set; }
        public bool vDirection { get; set; }
        public int gravity { get; set; }
      
        public bool onTop { get; set; }
        private TwoVolecity volecity;
        private float reset;
        private int jumpCounter;
        public Fireball(Vector2 pos)
        {
            position = pos;
            jumpCounter = 0;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateFireballSprite();
            isVisible = true;
            hDirection = false;
            vDirection = false;
            volecity = new TwoVolecity(3, 6);
            reset = volecity.vv;
            gravity = 0;
            onTop = false;
        }
        public void ItemChangeDirection()
        {
            vDirection = !vDirection;
            volecity.vv = reset;
            jumpCounter++;
        }

        public void Draw()
        {
            if (isVisible)
            {
                itemSprite.Draw(position);
            }
        }

        public void Update()
        {
            if(jumpCounter <= 4)
            {
                position = Volecity.getNewPosition(volecity, vDirection, hDirection, true, position);
                if (volecity.vv < 0)
                {
                    ItemChangeDirection();
                    volecity.vv = reset;
                }

                System.Console.WriteLine(volecity.vv);
                itemSprite.Update();
            }else
            {
                isVisible = false;
            }
       
         

            
         
            

         
            
            
           
            //if (increment)
            //{
            //    jumpCounter++;
            //}
            //else
            //{
            //    jumpCounter--;
            //}

            //if (jumpCounter == 8 || jumpCounter == -1)
            //{
            //    increment = !increment;
            //}

            //if (hDirection)
            //{
            //    position = new Vector2(position.X + 5, position.Y - jumpCounter);
            //}
            //else
            //{
            //    position = new Vector2(position.X - 5, position.Y - jumpCounter);
            //}
        }
    }
}
