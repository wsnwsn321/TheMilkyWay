﻿using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses
{
    class DeadState : IState
    {
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public ISprite BeamSprite { get; set; }
        public bool beam { get; set; }

        public DeadState(MainCharacter mainCharacter)
        {
            BeamSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBeamSprite();
            this.mainCharacter = mainCharacter;
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

        public void Attack()
        {
        }
        public void Collect()
        {

        }
    }
}