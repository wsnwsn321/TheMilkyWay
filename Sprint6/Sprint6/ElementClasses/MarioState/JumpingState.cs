using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses
{
    class JumpingState : IState
    {

  
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public ISprite beamSprite { get; set; }
        public JumpingState(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
            
        }

        public void Jump()
        {

        }

        public void Draw(Vector2 position)
        {
            Sprite.Draw(new Vector2(position.X, position.Y));
        }

        public void Update()
        {
            Sprite.Update();
        }

        public void Die()
        {
            mainCharacter.state = new DeadState( mainCharacter);
            mainCharacter.UFODie();
        }

        public void Attack()
        {

        }
        public void Collect()
        {
            Vector2 newPos;
            newPos.X = mainCharacter.position.X;
            newPos.Y =  Sprite.desRectangle.Top+100;
            beamSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBeamSprite();
            beamSprite.Draw(newPos);
        }
    }
}
