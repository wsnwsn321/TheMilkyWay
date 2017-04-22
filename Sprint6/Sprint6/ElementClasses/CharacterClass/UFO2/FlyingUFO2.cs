using Microsoft.Xna.Framework;
using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.Sprites;
using System;

namespace TheMilkyWay.ElementClasses

{
    public class FlyingUFO2 : IEnemy

    {
        public ISprite enemySprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public float gravity { get; set; }

        public FlyingUFO2(Vector2 pos)
        {

            position = pos;

            enemySprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateFlyingUFOSprite();
            isVisible = true;

        }

        public void Draw()
        {
            
          
            if (isVisible)
            {

                enemySprite.Draw(position);
            }

        }

        public void Update()
        {
            if (isVisible)
            {

            }

           position = new Vector2(position.X - 2, position.Y);
                
               
                
            enemySprite.Update();
        }
    }
}
