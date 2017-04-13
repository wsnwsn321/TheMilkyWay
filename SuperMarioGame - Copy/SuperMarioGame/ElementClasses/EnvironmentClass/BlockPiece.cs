using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.EnvironmentClass
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
        private int FiftyFive = 55;
        private int Eleven = 11;
        private int Twenty= 20;
        private int Three = 3;
        private int Seven = 7;
        public BlockPiece(Vector2 pos, int piece)
        {
            onTop = true;
            gravity = 0;
            position = pos;
            this.piece = piece;
            if (piece == GameConstants.BlockPieceOne)
            {
                itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateBlockPiece1Sprite();
            }
            else if (piece == GameConstants.BlockPieceTwo)
            {
                itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateBlockPiece2Sprite();
            }
            else if (piece == GameConstants.BlockPieceThree)
            {
                itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateBlockPiece3Sprite();
            }
            else if (piece == GameConstants.BlockPieceFour)
            {
                itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateBlockPiece4Sprite();
            }
            
            isVisible = true;
        }

        public void Draw()
        {
            if (isVisible)
            {
                if (piece == GameConstants.BlockPieceOne)
                {
                    if (jumpCount < Twenty)
                    {
                        position = new Vector2(position.X-1, position.Y - Seven);
                        itemSprite.Draw(position);
                    }
                    else
                    {
                        position = new Vector2(position.X-1, position.Y +Three);
                        itemSprite.Draw(position);
                    }
                    if (jumpCount == FiftyFive)
                    {
                        jumpCount = 0;
                        isVisible = false;
                    }
                    jumpCount++;
                }
                else if (piece == GameConstants.BlockPieceThree)
                {
                    if (jumpCount < Twenty)
                    {
                        position = new Vector2(position.X + 1, position.Y - Seven);
                        itemSprite.Draw(position);
                    }
                    else
                    {
                        position = new Vector2(position.X + 1, position.Y +Three);
                        itemSprite.Draw(position);
                    }
                    if (jumpCount == FiftyFive)
                    {
                        jumpCount = 0;
                        isVisible = false;
                    }
                    jumpCount++;
                }

                else if (piece == GameConstants.BlockPieceTwo)
                {
                    if (jumpCount < FiftyFive)
                    {
                        position = new Vector2(position.X - 1, position.Y +Three);
                        itemSprite.Draw(position);
                    }
                   
                    if (jumpCount == FiftyFive)
                    {
                        jumpCount = 0;
                        isVisible = false;
                    }
                    jumpCount++;
                }

                else if (piece == GameConstants.BlockPieceFour)
                {
                    if (jumpCount < FiftyFive)
                    {
                        position = new Vector2(position.X + 1, position.Y +Three);
                        itemSprite.Draw(position);
                    }

                    if (jumpCount == FiftyFive)
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
            bumpCount = Eleven;
        }

        public void Update()
        {
            itemSprite.Update();
        }
    }
}
