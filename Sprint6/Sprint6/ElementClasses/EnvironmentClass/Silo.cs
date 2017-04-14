using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sprites.UFOSprite;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses

{
    public class Silo : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool isBroken { get; set; }
        public bool isBumped { get; set; }
        private int Three = 3;
        private int Five = 5;
        private int Eleven = 11;
        public Silo(Vector2 pos)
        {
                position = pos;

                blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateSiloSprite();

         

            isVisible = true;
            isBroken = false;
            isBumped = false;

        }

        public void Draw()
        {
            if (isVisible)
            {

                blockSprite.Draw(position);
            }

        }

        public void Update()
        {
            if (isVisible)
            {

            }

            blockSprite.Update();
        }
    }
}
