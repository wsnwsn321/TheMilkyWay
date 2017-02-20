using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.CharacterClass.Enemies
{
    public class Goomba : ElementInterfaces.IEnemy

    {
        public ISprite enemySprite { get; set; }
        public Vector2 position { get; set; }

        public Goomba(Vector2 pos)
        {
            position = pos;
            enemySprite = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaSprite();
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
