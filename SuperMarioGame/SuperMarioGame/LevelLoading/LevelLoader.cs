using SuperMarioGame.ElementClasses.EnvironmentClass;
using Microsoft.Xna.Framework;
using System.IO;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.ElementClasses.CharacterClass.Enemies;
using SuperMarioGame.ElementClasses.BackgroundClass;

namespace SuperMarioGame.LevelLoading
{
    public class LevelLoader
    {
        private int x, y;
        public int height { get; set; }
        public int width { get; set; }
        private Level level;

        public LevelLoader(Level level)
        {
            this.level = level;
        }

        public void LoadLevel(string levelToLoad)
        {
            x = 0;
            y = 0;
            ReadLevelFile(levelToLoad);
        }
        private void ReadLevelFile(string levelToLoad)
        {
            StreamReader stream = new StreamReader(levelToLoad);
            string line;
            while((line = stream.ReadLine()) != null)
            {
                x = 0;
                string[] str = line.Split(',');
                foreach (string obj in str)
                {
                    switch (obj)
                    {
                        case "BrickBlock":
                            level.envElements.Add(new BrickBlock(new Vector2(x, y)));
                            break;
                        case "BrickBlockC":
                            level.envElements.Add(new BrickBlockC(new Vector2(x, y)));
                            break;
                        case "BrickBlockCC":
                            level.envElements.Add(new BrickBlockCC(new Vector2(x, y)));
                            break;
                        case "BrickBlockS":
                            level.envElements.Add(new BrickBlockS(new Vector2(x, y)));
                            break;
                        case "GroundBlock":
                            level.envElements.Add(new GroundBlock(new Vector2(x, y)));
                            break;
                        case "HiddenBlock":
                            level.envElements.Add(new HiddenBlock(new Vector2(x, y)));
                            break;
                        case "QuestionBlockM":
                            level.envElements.Add(new QuestionBlockM(new Vector2(x, y)));
                            break;
                        case "QuestionBlockC":
                            level.envElements.Add(new QuestionBlockC(new Vector2(x, y)));
                            break;
                        case "StageBlock":
                            level.envElements.Add(new StageBlock(new Vector2(x, y)));
                            break;
                        case "UsedBlock":
                            level.envElements.Add(new UsedBlock(new Vector2(x, y)));
                            break;
                        case "Coin":
                            level.itemElements.Add(new Coin(new Vector2(x, y)));
                            break;
                        case "Flower":
                            level.itemElements.Add(new Flower(new Vector2(x, y)));
                            break;
                        case "GreenMushroom":
                            level.itemElements.Add(new GreenMushroom(new Vector2(x, y)));
                            break;
                        case "RedMushroom":
                            level.itemElements.Add(new RedMushroom(new Vector2(x, y)));
                            break;
                        case "Star":
                            level.itemElements.Add(new Star(new Vector2(x, y)));
                            break;
                        case "Goomba":
                            level.enemyElements.Add(new Goomba(new Vector2(x, y-10)));
                            break;
                        case "Koopa":
                            level.enemyElements.Add(new Koopa(new Vector2(x, y + 21)));
                            break;
                        case "Pipe1":                            
                            level.envElements.Add(new Pipe(new Vector2(x + 2, y + 4),1,false));
                            break;
                        case "Pipe2":
                            level.envElements.Add(new Pipe(new Vector2(x + 2, y - 15),2,false));
                            break;
                        case "Pipe3":
                            level.envElements.Add(new Pipe(new Vector2(x + 2, y - 35),3,false));
                            break;
                        case "Pipe1S":
                            level.envElements.Add(new Pipe(new Vector2(x + 2, y + 4), 1, true));
                            break;
                        case "Pipe2S":
                            level.envElements.Add(new Pipe(new Vector2(x + 2, y - 15), 2, true));
                            break;
                        case "Pipe3S":
                            level.envElements.Add(new Pipe(new Vector2(x + 2, y - 35), 3, true));
                            break;
                        case "BigCloud":
                            level.backgroundElements.Add(new BigCloud(new Vector2(x, y + 14)));
                            break;
                        case "SmallCloud":
                            level.backgroundElements.Add(new SmallCloud(new Vector2(x, y + 18)));
                            break;
                        case "BigMountain":
                            level.backgroundElements.Add(new BigMountain(new Vector2(x, y)));
                            break;
                        case "SmallMountain":
                            level.backgroundElements.Add(new SmallMountain(new Vector2(x, y)));
                            break;
                        case "BigBrush":
                            level.backgroundElements.Add(new BigBrush(new Vector2(x, y)));
                            break;
                        case "SmallBrush":
                            level.backgroundElements.Add(new SmallBrush(new Vector2(x, y)));
                            break;
                        case "Castle":
                            level.backgroundElements.Add(new Castle(new Vector2(x, y+2)));
                            break;
                        case "Flagpole":
                            level.backgroundElements.Add(new Flagpole(new Vector2(x, y)));
                            break;
                        case "Flag":
                            level.backgroundElements.Add(new Flag(new Vector2(x+15, y+27)));
                            break;
                        default:
                            break;
                    }
                    x += 32;
                }
                width = x;
                y += 32;
            }
            height = y;
        }
    }
}
