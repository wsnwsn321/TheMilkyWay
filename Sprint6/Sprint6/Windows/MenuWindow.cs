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
    public class MenuWindow : IWindow
    {
        private Game1 mygame;
        public Rectangle windowRect { get; set; }
        private Texture2D pixel;
        public bool isVisible { get; set; }

        private Vector2 menuItem1;

        public MenuWindow(Game1 game)
        {
            mygame = game;
            pixel = new Texture2D(mygame.GraphicsDevice, 1, 1);
            Color[] colorData = {
                Color.White,
            };
            pixel.SetData<Color>(colorData);
            windowRect = new Rectangle(25,25,25,25);
            menuItem1.X = windowRect.Width / GameConstants.Two;
            menuItem1.Y = windowRect.Height / GameConstants.Two;
        }

        public void Display()
        {
            String inst = "Use the arrow keys to navigate\nHit enter to select your choice";

            Vector2 FontOrigin1 = mygame.font.MeasureString(inst) / GameConstants.Two;

            if (isVisible)
            {
                mygame.spriteBatch.Begin();
                mygame.spriteBatch.Draw(pixel, windowRect, Color.Black);
                mygame.spriteBatch.DrawString(mygame.font, inst, menuItem1, Color.White,
                    0, FontOrigin1, 2f, SpriteEffects.None, 1f);
                mygame.spriteBatch.End();
            }
        }
    }
}
