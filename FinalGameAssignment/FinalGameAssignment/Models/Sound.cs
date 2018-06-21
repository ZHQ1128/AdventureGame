using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.Models
{
    class Sound
    {
        public static void StopMusic()  // 要不要把weapon shieldlist合并
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.Stop();
        }

        //public static Dictionary<string, string> SoundLib(User user)
        //{
        //    var dictionary = new Dictionary <string, String>();
        //    dictionary.Add(user.Weapon.Name, $"C:\\Users\\zhang\\source\\repos\\FinalGameAssignment\\{user.Weapon.Name}.wav");
        //    //dictionary.Add("Axe", @"C:\Users\zhang\source\repos\FinalGameAssignment\Axe.wav");
        //    //dictionary.Add("Mace", @"C:\Users\zhang\source\repos\FinalGameAssignment\Mace.wav");
        //    //dictionary.Add("Stick", @"C:\Users\zhang\source\repos\FinalGameAssignment\Stick.wav");
        //    return dictionary;
        //}
        public static void WeaponAtkSnd(User user)  // 要不要把weapon shieldlist合并
        {
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer();
            player2.SoundLocation = Environment.CurrentDirectory + $"\\{user.Weapon.Name}.wav";
            player2.Play();
        }
        public static void BattleMusic()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = Environment.CurrentDirectory + @"\battle-music.wav";
                player.PlayLooping();
        }

        public static void StoreMusic() 
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Marimba-tune-loop-Store.wav";
            player.PlayLooping();
        }
        public static void TavernMusic() 
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Cheerful-marimba-music-melody-loop-Tavern.wav";
            player.PlayLooping();
        }

        public static void ForestMusic()  
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Forest.wav";
            player.PlayLooping();
        }
        public static void FinalBattle() 
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Battle_Theme_Boss.wav";
            player.PlayLooping();
        }
        public static void CantRunAway()  
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Monster Growl-Can't run away.wav";
            player.Play();
        }
        public static void BattleFail()  
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\BattleFail.wav";
            player.Play();
        }
        public static void BattleWin()  
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\BattleWin.wav";
            player.Play();
        }
    }
}
