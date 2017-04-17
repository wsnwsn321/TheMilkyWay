using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses
{
    class DeadState : IState
    {
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public ISprite BeamSprite { get; set; }

        public DeadState(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
            Sprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateDeadUFOSprite();


        }
        public void Idle()
        {
            Sprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateDeadUFOSprite();

        }

        public void Jump()
        {
            Sprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateDeadUFOSprite();
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

        public void Attack()
        {
        }
        public void Collect()
        {

        }
    }
}
