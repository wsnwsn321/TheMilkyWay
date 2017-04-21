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
            windowRect = new Rectangle(25,GameConstants.ScreenHeight-175,255,155);
            borderRect = new Rectangle(20,GameConstants.ScreenHeight-180,265,165);
            menuItem1.X = windowRect.X + windowRect.Width / 2;
            menuItem1.Y = windowRect.Y + 10 + windowRect.Height / 2;
        }

        public void Display()
        {
            String inst = "How to Play:\nRepeatedly press space bar in\norder to keep the UFO in the sky,\n and try to avoid all obstacles" +
                          "\nTry to collect all of the cows in the level\n using the beam ('b')" +
                          "\nDo NOT collect toxic green cows\n instead blow them up with bombs ('n')\n";

            Vector2 FontOrigin1 = mygame.font.MeasureString(inst) / GameConstants.Two;
            if (isVisible)
            {
                mygame.spriteBatch.Begin();
                mygame.spriteBatch.Draw(pixel, borderRect, Color.White);
                mygame.spriteBatch.Draw(pixel, windowRect, Color.Gray);
                mygame.spriteBatch.DrawString(mygame.font, inst, menuItem1, Color.White,
                    0, FontOrigin1, 0.9f, SpriteEffects.None, 1f);
                mygame.spriteBatch.End();
            }
        }
    }
}
