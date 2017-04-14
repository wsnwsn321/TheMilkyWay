using Microsoft.Xna.Framework;
using System.IO;

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
                            level.backgroundColor = Color.CornflowerBlue;        
                            break;
                        case "UNDERWORLD":
                            level.backgroundColor = Color.TransparentBlack;
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
