namespace SuperMarioGame.CollisionHandler
{
    class MarioBlockHandler
    {
        private static MarioBlockHandler instance = new MarioBlockHandler();


        public static MarioBlockHandler Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioBlockHandler()
        {
        }
    }
}
