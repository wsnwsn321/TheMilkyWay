﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.SpriteFactories
{
    class ItemSpriteFactory
    {

        private Texture2D mushroomSpritesheet;
        private Texture2D coinSpritesheet;
        private Texture2D flowerSpritesheet;
        private Texture2D starSpritesheet;
        // More private Texture2Ds follow
        // ...

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

        public void LoadAllTextures(ContentManager content)
        {
            //load sprite sheets here**************************************
            //one example is below

            mushroomSpritesheet = content.Load<Texture2D>("Item/Mushroom");
            flowerSpritesheet = content.Load<Texture2D>("Item/Flower");
            starSpritesheet = content.Load<Texture2D>("Item/Star");
            coinSpritesheet = content.Load<Texture2D>("Item/Coin");

        }

        //methods for creating sprites below*************************************************
        //one example is below

        //public ISprite CreateMushroomSprite()
        //{
        //    return new MushroomSprite(mushroomSpritesheet, Game1.Instance.level.isAboveGround);
        //}

        public Sprites.ISprite CreateFlowerSprite()
        {
            return new Sprites.FlowerSprite(flowerSpritesheet); 
        }

        public Sprites.ISprite CreateStarSprite()
        {
            return new Sprites.StarSprite(starSpritesheet);
        }

        public Sprites.ISprite CreateGreenMushroomSprite()
        {
            return new Sprites.GreenMushroomSprite(mushroomSpritesheet);
        }

        public Sprites.ISprite CreateRedMushroomSprite()
        {
            return new Sprites.RedMushroomSprite(mushroomSpritesheet);
        }

        public Sprites.ISprite CreateCoinSprite()
        {
            return new Sprites.CoinSprite(coinSpritesheet);
        }

    }
}
