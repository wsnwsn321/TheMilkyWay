using Microsoft.Xna.Framework;

namespace SuperMarioGame.Camera
{
    public class Camera
    {

        private Vector2 position;
        private int height;
        private int width;

        public Camera (Rectangle window)
        {
            position = new Vector2(window.X, window.Y);
            width = window.Width;
            height = window.Height;
        }

        public void MoveRight(int distance)
        {
            position = new Vector2(position.X + distance, position.Y);
        }

        public void InitialShift(int gameHeight)
        {
            position = new Vector2(position.X, gameHeight - position.Y);
        }

    }
}
