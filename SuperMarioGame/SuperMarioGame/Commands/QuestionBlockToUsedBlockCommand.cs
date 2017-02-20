namespace SuperMarioGame.Commands
{
    public class QuestionBlockToUsedBlockCommand : ICommand
    {

        private Game1 myGame;

        public QuestionBlockToUsedBlockCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.envElements[1] = new ElementClasses.EnvironmentClass.UsedBlock(myGame.envElements[1].position);
        }
    }
}
