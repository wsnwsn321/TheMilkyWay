using Microsoft.Xna.Framework;
using System.IO;
using Sprint6.ElementClasses;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.LevelLoading
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
                        case "OVERWORLD":
                            break;
                        case "UNDERWORLD":
                            break;
                        case "StarryNight":
                            for (int i = 0; i < 100; i++)
                            {
                                level.background = new StarryNight(new Vector2(x, y));
                                level.backgroundElements.Add(new StarryNight(new Vector2(x + GameConstants.ScreenWidth*i, y)));
                            }                            
                            break;
                        case "Silo":
                            level.envElements.Add(new Silo(new Vector2(x,y)));
                            break;
                        case "Grass":
                            level.envElements.Add(new Grass(new Vector2(x,y+3)));
                            break;
                        case "Barn":
                            level.envElements.Add(new Barn(new Vector2(x, y)));
                            break;
                        case "Cow":
                            level.itemElements.Add(new CowCharacter(new Vector2(x, y)));
                            break;
                        case "BadCow":
                            level.itemElements.Add(new BadCowCharacter(new Vector2(x, y)));
                            break;
                        case "UFO2":
                            level.enemyElements.Add(new FlyingUFO2(new Vector2(x, y)));
                            break;
                        case "Disk":
                            level.itemElements.Add(new Disk(new Vector2(x, y)));
                            break;
                        case "0":
                            break;
                    }
                    x += GameConstants.SquareWidth;
                }
                width = x;
                y += GameConstants.SquareWidth;
            }
            height = y;
        }
    }
}
