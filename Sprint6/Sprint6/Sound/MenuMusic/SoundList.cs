using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TheMilkyWay.Sound.MenuMusic
{
    public class SoundList
    {

        private int maxMusic = 6;
        private int currentAdd = -1;
        public static SoundList instance = new SoundList();
        public List<int> musicList = new List<int>();
        public void addMusic()
        {
            if(currentAdd < maxMusic && currentAdd >= musicList.Count -1)
            {
                currentAdd++;
                Console.WriteLine(currentAdd);
                musicList.Add(currentAdd);
               
            }
          
        } 

        public void loadMusicList()
        {
            if (File.Exists(@"C:\UFO\MusicList.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines("MusicList.txt");
                currentAdd = lines.Length;
                for (int i = 0; i < lines.Length; i++)
                {
                    musicList.Add(Int32.Parse(lines[i]));
                }
            }
        }
        public void writeMusicList()
        {
            StreamWriter write;
            if (File.Exists(@"C:\UFO\MusicList.txt"))
            {
                write = new StreamWriter(@"C:\UFO\MusicList.txt");
            }else
            {
                Directory.CreateDirectory(@"C:\\UFO");
                write = new StreamWriter(@"C:\UFO\MusicList.txt");
            }

            for (int i = 0; i < musicList.Count; i++)
            {
                write.WriteLine(musicList[i]);
            }
            Console.WriteLine("Success");
            write.Close();
        }

        public List<int> getMusicList()
        {
            return musicList;
        }

        public void reset()
        {
            currentAdd = -1;
        }
        
    }
}
