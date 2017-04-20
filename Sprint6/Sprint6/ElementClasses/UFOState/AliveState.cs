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
        private bool first = true;
        public ISprite BeamSprite { get; set; }
        private Vector2 newPos;
        public AliveState(MainCharacter mainCharacter)
        {
            BeamSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBeamSprite();
            this.mainCharacter = mainCharacter;
            beam = false;
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
            //mainCharacter.UFODie();
        }
        public void Collect()
        {
            Vector2 newbeamPos;
            newbeamPos.X = mainCharacter.position.X+14;
            newbeamPos.Y = Sprite.desRectangle.Top + 100;
            BeamSprite.Draw(newbeamPos);
        }
    }
}
