using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Snake
{
    public class Sounds
    {
        // Media player
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private string pathToMedia;

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        public void Play()
        {
            player.URL = pathToMedia + "gamesound.mp3";
            player.settings.volume = 5;
            player.controls.play();
            player.settings.setMode("loop", true); //loop mode

        }

        public void PlayEat()
        {
            player.URL = pathToMedia + "eatsound.mp3";
            player.settings.volume = 100;
            player.controls.play();
        }

        public void PlayEatBadFood()
        {
            player.URL = pathToMedia + "badfoodsound.mp3";
            player.settings.volume = 100;
            player.controls.play();
        }

        public void PlayEatSpecialFood()
        {
            player.URL = pathToMedia + "specialfoodsound.mp3";
            player.settings.volume = 100;
            player.controls.play();
        }

        public void PlayGameOver()
        {
            player.URL = pathToMedia + "gameoversound.mp3";
            player.settings.volume = 100;
            player.controls.play();
        }

        public void Stop(string sound)
        {
            player.URL = pathToMedia + sound;
            player.controls.stop();
        }
    }
}
