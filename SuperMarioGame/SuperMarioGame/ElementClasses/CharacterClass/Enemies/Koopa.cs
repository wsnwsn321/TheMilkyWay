using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using System;

namespace SuperMarioGame.ElementClasses.CharacterClass.Enemies
{
    public class Koopa : ElementInterfaces.IEnemy

    {
        public ISprite enemySprite { get; set; }
        public Vector2 position { get; set; }

        public Koopa(Vector2 pos)
        {
            position = pos;
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaSprite();
        }

        public void Draw()
        {
            enemySprite.Draw(position);
        }

        public void Update()
        {
            enemySprite.Update();
        }

        public void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public void BeStomped()
        {
            throw new NotImplementedException();
        }

        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void EnemyIdle()
        {
            throw new NotImplementedException();
        }
    }
}
