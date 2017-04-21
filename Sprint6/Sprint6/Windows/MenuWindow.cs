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
        private Rectangle borderRect;
        private Texture2D pixel;
        public bool isVisible { get; set; }

        private Vector2 menuItem1;

        public MenuWindow(Game1 game)
        {
            mygame = game;
            isVisible = false;
            pixel = new Texture2D(mygame.GraphicsDevice, 1, 1);
            Color[] colorData = {
                Color.White,
            };
            pixel.SetData<Color>(colorData);
            windowRect = new Rectangle(25,GameConstants.ScreenHeight-175,400,150);
            borderRect = new Rectangle(20,GameConstants.ScreenHeight-180,410,160);
            menuItem1.X = (windowRect.X + windowRect.Width / 2)+8;
            menuItem1.Y = windowRect.Y + 10 + windowRect.Height / 2;
        }

        public void Display()
        {
            String inst = "How to Play:\n-Repeatedly press space bar in order to keep\n the UFO in the sky, and try to avoid all obstacles\n" +
                          "-Try to collect all of the cows using the beam ('b')\n" +
                          "-Do NOT collect toxic green cows\n instead blow them up with bombs ('n')\n";

            Vector2 FontOrigin1 = mygame.font.MeasureString(inst) / GameConstants.Two;
            if (isVisible)
            {
                mygame.spriteBatch.Begin();
                mygame.spriteBatch.Draw(pixel, borderRect, Color.White);
                mygame.spriteBatch.Draw(pixel, windowRect, Color.Gray);
                mygame.spriteBatch.DrawString(mygame.font, inst, menuItem1, Color.White,
                    0, FontOrigin1, 1f, SpriteEffects.None, 1f);
                mygame.spriteBatch.End();
            }
        }
    }
}
