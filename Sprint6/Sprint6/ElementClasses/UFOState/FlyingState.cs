using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses
{
    class FlyingState : IState
    {
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public bool beam = false;
        public ISprite BeamSprite { get; set; }
        public FlyingState(MainCharacter mainCharacter)
        {
            BeamSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBeamSprite();
            this.mainCharacter = mainCharacter;
        }
        //** update the position
        public void Update()
        {
            Sprite.Update();
            if (beam)
            {
                BeamSprite.Update();
            }
        }

        public void Draw(Vector2 position)
        {
            Sprite.Draw(position);
            if (beam)
            {
                Collect();
            }
        }

        public void Die()
        {
            mainCharacter.state = new DeadState( mainCharacter);
            mainCharacter.UFODie();
        }
        public void Collect()
        {   Vector2 newPos;
            newPos.X = mainCharacter.position.X+14;
            newPos.Y = Sprite.desRectangle.Top + 100;
            BeamSprite.Draw(newPos);
        }
    }
}
