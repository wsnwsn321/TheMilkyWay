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
                            level.background = new StarryNight(new Vector2(x,y));
                            break;
                        case "Silo":
                            level.envElements.Add(new Silo(new Vector2(x,y)));
                            break;
                        case "Cow":
                            level.itemElements.Add(new CowCharacter(new Vector2(x, y)));
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
