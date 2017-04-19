using Microsoft.Xna.Framework;
using Sprint6.SpriteFactories;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses
{
    class FlyingState : IState
    {
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public bool beam { get; set; }
        public bool bomb { get; set; }
        private bool first = true;
        private int bombSpeed;
        public ISprite BeamSprite { get; set; }
        public ISprite BombSprite { get; set; }
        private Vector2 newPos;
        public FlyingState(MainCharacter mainCharacter)
        {
            BeamSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBeamSprite();
            BombSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBombSprite();
            this.mainCharacter = mainCharacter;
            bombSpeed = 0;
            beam = false;
            bomb = false;
        }
        //** update the position
        public void Update()
        {
            Sprite.Update();
            if (beam)
            {
                BeamSprite.Update();
            }
            else if (bomb && BombSprite.canMove)
            {
                BombSprite.Update();
                bombSpeed = 6;
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
            }
            else if (bomb && !BombSprite.canMove)
            {
                BombSprite.Update();

                //BombSprite = CharacterSpriteFactory.Instance.CreateBombSprite();
                bombSpeed = 0;
                first = true;
            }
        }

        public void Draw(Vector2 position)
        {
            Sprite.Draw(position);
            if (beam)
            {
                Collect();
            }
            else if (bomb)
            {
                Drop();
            }
        }

        public void Die()
        {
            mainCharacter.state = new DeadState( mainCharacter);
            //mainCharacter.UFODie();
        }
        public void Collect()
        {
            Vector2 newbeamPos;
            newbeamPos.X = mainCharacter.position.X+14;
            newbeamPos.Y = Sprite.desRectangle.Top + 100;
            BeamSprite.Draw(newbeamPos);
        }
        public void Drop()
        {
            BombSprite.Draw(newPos);
        }
    }
}
