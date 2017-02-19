namespace SuperMarioGame.CollisionHandler
{
    class MarioEnemyHandler
    {
        private static MarioEnemyHandler instance = new MarioEnemyHandler();


        public static MarioEnemyHandler Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioEnemyHandler()
        {
        }
    }
}
