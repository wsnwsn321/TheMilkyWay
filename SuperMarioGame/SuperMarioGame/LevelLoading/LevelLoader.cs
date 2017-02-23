using SuperMarioGame.ElementClasses.EnvironmentClass;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.IO;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.ElementClasses.CharacterClass.Enemies;
using System;

namespace SuperMarioGame.LevelLoading
{
    public class LevelLoader
    {
        private int x, y;
        private Level level;

        public LevelLoader(Level level)
        {
            this.level = level;
        }

        public void LoadLevel()
        {
            x = 0;
            y = 0;
            ReadLevelFile();
        }

        private void ReadLevelFile()
        {
            StreamReader stream = new StreamReader(@"LevelLoading\LevelFiles\gumbo.csv");
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
                        case "GroundBlock":
                            level.envElements.Add(new GroundBlock(new Vector2(x, y)));
                            break;
                        case "HiddenBlock":
                            level.envElements.Add(new HiddenBlock(new Vector2(x, y)));
                            break;
                        case "QuestionBlock":
                            level.envElements.Add(new QuestionBlock(new Vector2(x, y)));
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
                            level.enemyElements.Add(new Goomba(new Vector2(x, y)));
                            break;
                        case "Koopa":
                            level.enemyElements.Add(new Koopa(new Vector2(x, y + 21)));
                            break;
                        case "Pipe":
                            level.envElements.Add(new Pipe(new Vector2(x + 2, y + 4)));
                            break;
                        default:
                            break;
                    }
                    x += 32;
                }
                y += 32;
            }

        }
    }
}
