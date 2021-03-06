﻿using Microsoft.Xna.Framework;
using TheMilkyWay.SpriteFactories;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;

namespace TheMilkyWay.ElementClasses
{
    class AliveState : IState
    {
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public bool beam { get; set; }
        public ISprite BeamSprite { get; set; }
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
            mainCharacter.state = new DeadState();
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
