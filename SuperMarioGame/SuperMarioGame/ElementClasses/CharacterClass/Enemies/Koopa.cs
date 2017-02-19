using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
