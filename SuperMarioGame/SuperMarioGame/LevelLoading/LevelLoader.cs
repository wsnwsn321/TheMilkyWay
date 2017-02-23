using System.Diagnostics;
using System.IO;

namespace SuperMarioGame.LevelLoading
{
    public class LevelLoader
    {
        private static LevelLoader instance = new LevelLoader();

        private int x, y;

        public static LevelLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public void Load()
        {
            x = 0;
            y = 0;
            ReadLevelFile();
        }

        private void ReadLevelFile()
        {
            StreamReader stream = new StreamReader("Levels/Level1-1.csv");
            string line;
            while((line = stream.ReadLine()) != null)
            {
                string[] str = line.Split(new char[2] { ',', ' ' } );
                foreach (string obj in str)
                {
                    switch (obj)
                    {
                        case ("BrickBlock"):
                            
                            break;
                        case ("GroundBlock"):

                            break;
                        case ("HiddenBlock"):

                            break;
                        case ("QuestionBlock"):

                            break;
                        case ("StageBlock"):

                            break;
                        case ("UsedBlock"):

                            break;
                        case ("Coin"):
                            Debug.WriteLine("We found the coin boyz");
                            break;
                        case ("Flower"):

                            break;
                        case ("GreenMushroom"):

                            break;
                        case ("RedMushroom"):

                            break;
                        case ("Star"):

                            break;
                        case ("Goomba"):

                            break;
                        case ("Koopa"):

                            break;
                        case ("Pipe"):

                            break;
                        default:
                            break;
                    }
                    x += 32;
                }
                y += 32;
            }

        }

        private void InitializeObjects() 
        {

        }


    }
}
