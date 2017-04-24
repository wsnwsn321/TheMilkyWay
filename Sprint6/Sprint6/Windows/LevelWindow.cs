using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMilkyWay.HUDElements
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
            windowRect = new Rectangle(25, GameConstants.ScreenHeight - 190, 250, 150);
            borderRect = new Rectangle(20, GameConstants.ScreenHeight - 195, 260, 160);
            menuItem1.X = (windowRect.X + windowRect.Width / 2)+5;
            menuItem1.Y = windowRect.Y + windowRect.Height / 2;
        }

        public void Display()
        {
            String inst = "Press 'r' to restart the current level\n\nPress 'q' to quit to the main menu";

            Vector2 FontOrigin1 = mygame.font.MeasureString(inst) / GameConstants.Two;

            mygame.spriteBatch.Begin();
            mygame.spriteBatch.Draw(pixel, borderRect, Color.White);
            mygame.spriteBatch.Draw(pixel, windowRect, Color.Gray);
            mygame.spriteBatch.DrawString(mygame.font, inst, menuItem1, Color.White,
                0, FontOrigin1, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }
    }
}
