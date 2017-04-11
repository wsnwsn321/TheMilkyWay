using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using SuperMarioGame.VolecotyTest;
using System.Collections.Generic;
using System;
using SuperMarioGame.ElementClasses.ElementInterfaces;

namespace SuperMarioGame.ElementClasses.ItemClass
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
            gravity = -3;
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
              if(ExplosionCounter< 2)
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
