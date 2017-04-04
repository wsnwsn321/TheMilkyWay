using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class BlockPiece : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public int gravity { get; set; }
        public bool onTop { get; set; }
        public bool isVisible { get; set; }
        public bool isBumped { get; set; }
        public int bumpCount { get; set; }
        private int piece;
        private int jumpCount=0;
        public BlockPiece(Vector2 pos, int piece)
        {
            onTop = true;
            gravity = 0;
            position = pos;
            this.piece = piece;
            if (piece == 1)
            {
                itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateBlockPiece1Sprite();
            }
            else if (piece == 2)
            {
                itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateBlockPiece2Sprite();
            }
            else if (piece == 3)
            {
                itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateBlockPiece3Sprite();
            }
            else if (piece == 4)
            {
                itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateBlockPiece4Sprite();
            }
            
            isVisible = true;
        }

        public void Draw()
        {
            if (isVisible)
            {
                if (piece == 1)
                {
                    if (jumpCount < 20)
                    {
                        position = new Vector2(position.X-1, position.Y - 7);
                        itemSprite.Draw(position);
                    }
                    else
                    {
                        position = new Vector2(position.X-1, position.Y + 3);
                        itemSprite.Draw(position);
                    }
                    if (jumpCount == 55)
                    {
                        jumpCount = 0;
                        isVisible = false;
                    }
                    jumpCount++;
                }
                else if (piece == 3)
                {
                    if (jumpCount < 20)
                    {
                        position = new Vector2(position.X + 1, position.Y - 7);
                        itemSprite.Draw(position);
                    }
                    else
                    {
                        position = new Vector2(position.X + 1, position.Y + 3);
                        itemSprite.Draw(position);
                    }
                    if (jumpCount == 55)
                    {
                        jumpCount = 0;
                        isVisible = false;
                    }
                    jumpCount++;
                }

                else if (piece == 2)
                {
                    if (jumpCount < 55)
                    {
                        position = new Vector2(position.X - 1, position.Y + 3);
                        itemSprite.Draw(position);
                    }
                   
                    if (jumpCount == 55)
                    {
                        jumpCount = 0;
                        isVisible = false;
                    }
                    jumpCount++;
                }

                else if (piece == 4)
                {
                    if (jumpCount < 55)
                    {
                        position = new Vector2(position.X + 1, position.Y + 3);
                        itemSprite.Draw(position);
                    }

                    if (jumpCount == 55)
                    {
                        jumpCount = 0;
                        isVisible = false;
                    }
                    jumpCount++;
                }
                
            }
            
        }

        public void ItemChangeDirection()
        {

        }
        public void Bump()
        {
            isBumped = true;
            bumpCount = 11;
        }

        public void Update()
        {
            itemSprite.Update();
        }
    }
}
