using SuperMarioGame.ElementClasses.EnvironmentClass;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.IO;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.ElementClasses.CharacterClass.Enemies;
using System;
using SuperMarioGame.ElementClasses.BackgroundClass;

namespace SuperMarioGame.LevelLoading
{
    public class LevelLoader
    {
        private int x, y, height, width;
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

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }
        private void ReadLevelFile()
        {
            StreamReader stream = new StreamReader(@"LevelLoading\LevelFiles\Level1-1Full.csv");
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
                            level.enemyElements.Add(new Goomba(new Vector2(x, y)));
                            break;
                        case "Koopa":
                            level.enemyElements.Add(new Koopa(new Vector2(x, y + 21)));
                            break;
                        case "Pipe":
                            level.envElements.Add(new Pipe(new Vector2(x + 2, y + 4)));
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
