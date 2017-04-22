using Microsoft.Xna.Framework;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;

namespace TheMilkyWay.ElementClasses
{
    class DeadState : IState
    {
        public ISprite Sprite { get; set; }
        public ISprite BeamSprite { get;  set; }
        public ISprite BombSprite { get; set; }
        public bool beam { get; set; }
        public DeadState()
        {
            BeamSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBeamSprite();
            BombSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateLivingCowSprite();
            Sprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateDeadUFOSprite();
            beam = false;
        }

        public void Draw(Vector2 position)
        {

            Sprite.Draw(position);
        }
        public void Update()
        {
            Sprite.Update();
        }
        public void Die()
        {
        }

        public void Collect()
        {

        }
    }
}
