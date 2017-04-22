using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;

namespace TheMilkyWay.SpriteFactories
{
    class ItemSpriteFactory
    {
        private Texture2D musicDiskSpritesheet;



        public SpriteBatch sb { set; get; }
        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content,SpriteBatch sb)
        {
            //load sprite sheets here**************************************
            //one example is below

            //UFO
            musicDiskSpritesheet = content.Load<Texture2D>("UFOGameObjects/Disk");

            this.sb = sb;
        }

        //create item sprites
        public ISprite CreateDiskSprite()
        {
            return new DiskSprite(musicDiskSpritesheet, sb);
        }

    }
}
