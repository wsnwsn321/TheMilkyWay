using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using SuperMarioGame.VolecotyTest;
using System.Collections.Generic;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class FireballExplosion : ElementInterfaces.IItem

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
        private int Ten = 10;
        private int FOURHEIGHT = 480;


        public FireballExplosion(Vector2 pos)
        {
            position = pos;
            jumpCounter = 0;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateFireballExplosionSprite();
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
            }else
            {
                itemSprite.Draw(position);
            }
        }

        public void Update()
        {
            if(jumpCounter <= Ten && isVisible &&  position.Y > 0 && position.Y < FOURHEIGHT)
            {
                position = Volecity.getNewPosition(volecity, vDirection, hDirection, true, position);
                if (volecity.vv <= 0)
                {
                    ItemChangeDirection();
                    volecity.vv = reset;
                }
                itemSprite.Update();                
            }else 
            {
                isVisible = false;
            }              
        }

        public void fireBallExplosion()
        {
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateFireballExplosionSprite();
            Draw();
        }
    }
}
