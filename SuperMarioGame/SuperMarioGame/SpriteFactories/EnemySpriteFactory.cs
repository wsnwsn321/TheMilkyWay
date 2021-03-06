﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioGame.SpriteFactories
{
    public class EnemySpriteFactory
    {

        private Texture2D goombaSpritesheet;
        private Texture2D koopaSpritesheet;
        private Texture2D koopaFlipSheet;
        private Texture2D goombaFlipSheet;

        public SpriteBatch sb { get; set; }
        private static EnemySpriteFactory instance = new EnemySpriteFactory();

 
        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content, SpriteBatch sb)
        {
            goombaSpritesheet = content.Load<Texture2D>("Goomba/Goomba");
            koopaSpritesheet = content.Load<Texture2D>("Koopa/Koopa");
            koopaFlipSheet = content.Load<Texture2D>("Koopa/FlipKoopa");
            goombaFlipSheet = content.Load<Texture2D>("Goomba/FilpGoomba");

            this.sb = sb;
        }

        //create enemy sprites
        public Sprites.ISprite CreateGoombaSprite()
        {
            return new Sprites.GoombaSprite(goombaSpritesheet,sb);
        }


        public Sprites.ISprite CreateGoombaStompedSprite()
        {
            return new Sprites.GoombaStompedSprite(goombaSpritesheet,sb);
        }
        public Sprites.ISprite CreateKoopaMoveLeftSprite()
        {
            return new Sprites.KoopaLeftSprite(koopaSpritesheet,sb);
        }

        public Sprites.ISprite CreateKoopaStompedSprite()
        {
            return new Sprites.KoopaStompedSprite(koopaSpritesheet, sb);
        }

        public Sprites.ISprite CreateKoopaMoveRightSprite()
        {
            return new Sprites.KoopaRightSprite(koopaSpritesheet, sb);
        }
        public Sprites.ISprite CreateGoombaFlippedSprite()
        {
            return new Sprites.GoombaFlippedSprite(goombaFlipSheet, sb);
        }
        public Sprites.ISprite CreateKoopaFlippedSprite()
        {
            return new Sprites.KoopaFlippedSprite(koopaFlipSheet, sb);
        }
    }
}
