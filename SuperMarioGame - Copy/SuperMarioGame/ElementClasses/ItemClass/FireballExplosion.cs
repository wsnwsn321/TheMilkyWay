using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.VolecotyTest;
using System.Collections.Generic;
using System;
using Sprint6.ElementClasses.ElementInterfaces;

namespace Sprint6.ElementClasses.ItemClass
{
    public class FireballExplosion : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }

        public int gravity { get; set; }

  
 

        private int ExplosionCounter;
  


        public FireballExplosion(Vector2 pos)
        {
            position = pos;
            ExplosionCounter = 0;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateFireballExplosionSprite();
            isVisible = true;
            gravity = 0;
        }
        public void ItemChangeDirection()
        {
          
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
              if(ExplosionCounter<1)
            {
                ExplosionCounter++; 
            }
            else
            {
                isVisible = false;
            }    
        }

    }
}
