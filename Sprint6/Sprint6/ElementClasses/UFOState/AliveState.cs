using Microsoft.Xna.Framework;
using Sprint6.SpriteFactories;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses
{
    class AliveState : IState
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
        public AliveState(MainCharacter mainCharacter)
        {
            BeamSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBeamSprite();
            BombSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBombSprite();
            this.mainCharacter = mainCharacter;
            bombSpeed = 6;
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
            if (bomb && BombSprite.canMove)
            {
                BombSprite.Update();
                newPos.X = mainCharacter.position.X + 14;
                if (first)
                {
                    BombSprite = CharacterSpriteFactory.Instance.CreateBombSprite();
                    newPos.Y = mainCharacter.position.Y + bombSpeed;
                    first = false;
                }
                else
                {
                    newPos.Y += bombSpeed;
                }
            }
            if (!BombSprite.canMove)
            {
                BombSprite.canMove = true;
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
            if (bomb)
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
