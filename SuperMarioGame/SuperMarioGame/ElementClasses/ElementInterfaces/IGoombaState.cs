namespace SuperMarioGame.ElementClasses.ElementInterfaces
{
    public interface IGoombaState
    {
        void ChangeDirection();
        void BeStomped();
        void BeFilpped();
        void Update();
        void Draw();
    }
}
