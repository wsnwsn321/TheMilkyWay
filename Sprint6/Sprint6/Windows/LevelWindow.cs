using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint6.HUDElements
{
    public class LevelWindow : IWindow
    {
        private Game1 mygame;
        public Rectangle windowRect { get; set; }
        private Rectangle borderRect;
        private Texture2D pixel;

        private Vector2 menuItem1;

        public LevelWindow(Game1 game)
        {
            mygame = game;
            pixel = new Texture2D(mygame.GraphicsDevice, 1, 1);
            Color[] colorData = {
                Color.White,
            };
            pixel.SetData<Color>(colorData);
            windowRect = new Rectangle((GameConstants.ScreenWidth/2)-200,(GameConstants.ScreenHeight/2)-75,400,150);
            borderRect = new Rectangle((GameConstants.ScreenWidth/2)-205,(GameConstants.ScreenHeight/2)-80, 410,160);
            menuItem1.X = (windowRect.X + windowRect.Width / 2)+8;
            menuItem1.Y = windowRect.Y + windowRect.Height / 2;
        }

        public void Display()
        {
            String inst = "Press 'r' to begin!\n\nPress 'q' to quit to the main menu";

            Vector2 FontOrigin1 = mygame.font.MeasureString(inst) / GameConstants.Two;

            mygame.spriteBatch.Begin();
            mygame.spriteBatch.Draw(pixel, borderRect, Color.White);
            mygame.spriteBatch.Draw(pixel, windowRect, Color.Gray);
            mygame.spriteBatch.DrawString(mygame.font, inst, menuItem1, Color.White,
                0, FontOrigin1, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }
    }
}
