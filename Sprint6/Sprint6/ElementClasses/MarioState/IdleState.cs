﻿using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class IdleState : IState
    {


        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public IdleState(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
        }

        public void Idle()
        {

          
        }


        public void ChangeForm(int form)
        {
            mainCharacter.marioState = form;
            mainCharacter.state = new IdleState( mainCharacter);
            mainCharacter.MarioIdle();
        }



        public void Jump()
        {
            mainCharacter.state = new JumpingState( mainCharacter);
            mainCharacter.MainCharJump();
        }

        //** update the position
        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(Vector2 position)
        {
            Sprite.Draw(position);
        }

        public void Die()
        {
            mainCharacter.state = new DeadState( mainCharacter);
            mainCharacter.UFODie();
        }

        public void Attack()
        {

        }
    }
}
