namespace SuperMarioGame.CollisionHandler
{
    class MarioItemHandler
    {
        private static MarioItemHandler instance = new MarioItemHandler();


        public static MarioItemHandler Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioItemHandler()
        {
        }
    }
}
