using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses
{
    class JumpingState : IState
    {

  
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public ISprite BeamSprite { get; set; }
        public ISprite BombSprite { get; set; }
        private int bombSpeed;

        public bool beam { get; set; }
        public bool bomb { get; set; }
        private Vector2 newPos;
        private bool first = true;

        public JumpingState(MainCharacter mainCharacter)
        {
            BeamSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBeamSprite();
            BombSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBombSprite();
            this.mainCharacter = mainCharacter;
            bombSpeed = 0;
            beam = false;
            bomb = false;
        }

        public void Jump()
        {

        }

        public void Draw(Vector2 position)
        {
            Sprite.Draw(new Vector2(position.X, position.Y));
            if (beam)
            {
                Collect();
            }
            else if (bomb)
            {
                Drop();
            }
        }

        public void Update()
        {
            Sprite.Update();
            if (beam)
            {
                BeamSprite.Update();
            }
            else if (bomb)
            {
                BombSprite.Update();
                if (newPos.Y > 480 - 80)
                {
                    bomb = false;
                    bombSpeed = 0;
                    first = true;
                }
            }
        }

        public void Die()
        {
            mainCharacter.state = new DeadState( mainCharacter);
            //mainCharacter.UFODie();
        }

        public void Collect()
        {
            Vector2 newPos;
            newPos.X = mainCharacter.position.X + 14;
            newPos.Y =  Sprite.desRectangle.Top+100;
            BeamSprite.Draw(newPos);
        }
        public void Drop()
        {
            bombSpeed += 1;
            newPos.X = mainCharacter.position.X + 14;
            if (first)
            {
                newPos.Y = mainCharacter.position.Y + bombSpeed;
                first = false;
            }
            else
            {
                newPos.Y += bombSpeed;
            }
            BombSprite.Draw(newPos);
        }
    }
}
