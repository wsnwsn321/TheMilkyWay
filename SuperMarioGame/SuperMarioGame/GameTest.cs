using Microsoft.Xna.Framework;

namespace SuperMarioGame
{
    public class GameTest : Game1
    {

        public GameTest()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            int testTimer = 0;
            TestCase.TestBlockCollision.Instance.RunTests();
            while(testTimer < 2000)
            {
                testTimer++;
            }
            Exit();
            // No idea if base.Update is necessary
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }


    }
}
