using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint6.HUDElements
{
    public class BeamMeter
    {
        private int BeamPercent;
        private Rectangle BeamMeterBackground;
        private Rectangle BeamMeterBar;
        private Game1 myGame;
        private Texture2D pixel;

        private static int HUD_BEAM_METER_X = 20;
        private static int HUD_BEAM_METER_Y = 50;
        private static int HUD_BEAM_METER_HEIGHT = 10;

        private static int HUD_BEAM_METER_BACK_X = HUD_BEAM_METER_X - 5;
        private static int HUD_BEAM_METER_BACK_Y = HUD_BEAM_METER_Y - 5;
        private static int HUD_BEAM_METER_BACK_WIDTH = GameConstants.BEAM_PERCENT_MAX * 3 + 10;
        private static int HUD_BEAM_METER_BACK_HEIGHT = HUD_BEAM_METER_HEIGHT + 10;

        public BeamMeter(Game1 game)
        {

            myGame = game;
            HUD_BEAM_METER_X = GameConstants.Eleven - myGame.GraphicsDevice.Viewport.X;
            BeamPercent = GameConstants.BEAM_PERCENT_MAX;
            pixel = new Texture2D(myGame.GraphicsDevice, 1, 1);
            Color[] colorData = {
                        Color.White,
                    };
            pixel.SetData<Color>(colorData);
            BeamMeterBar = new Rectangle();
            BeamMeterBackground = new Rectangle(HUD_BEAM_METER_BACK_X, HUD_BEAM_METER_BACK_Y, HUD_BEAM_METER_BACK_WIDTH, HUD_BEAM_METER_BACK_HEIGHT);
        }

        public void Display()
        {
            HUD_BEAM_METER_X = GameConstants.Ten - myGame.GraphicsDevice.Viewport.X;
            HUD_BEAM_METER_BACK_X = HUD_BEAM_METER_X - 5;
            BeamMeterBackground.X = HUD_BEAM_METER_BACK_X;
            BeamMeterBar = new Rectangle(HUD_BEAM_METER_X, HUD_BEAM_METER_Y, BeamPercent * 3, HUD_BEAM_METER_HEIGHT);
            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(pixel, BeamMeterBackground, Color.Gray);
            myGame.spriteBatch.Draw(pixel, BeamMeterBar, Color.Green);

            myGame.spriteBatch.End();
        }

        public int GetBeamPercent()
        {
            return BeamPercent;
        }

        public void SetBeamPercent(int newBeamPercent)
        {
            BeamPercent = newBeamPercent;
        }

        public void DecrementBeamPercent()
        {
            if (BeamPercent > 0)
            {
                BeamPercent--;
            }
        }

        public void IncrementBeamPercent()
        {
            BeamPercent++;
        }

        public void DecreaseBeamPercentBy(int amount)
        {
            BeamPercent -= amount;
        }

        public void IncreaseBeamPercentBy(int amount)
        {
            BeamPercent += amount;
        }

    }
}
