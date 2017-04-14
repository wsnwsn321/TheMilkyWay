using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses
{
    class FlyingState : IState
    {


        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public FlyingState(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
        }
        //** update the position
        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(Vector2 position)
        {
            Sprite.Draw(position);
        }

        public void Die()
        {
            mainCharacter.state = new DeadState( mainCharacter);
            mainCharacter.UFODie();
        }
    }
}
