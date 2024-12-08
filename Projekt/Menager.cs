using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohjang
{
    public class Menager
    {
        Plansza Game;
        Form1 OknoGry;
        Timer Timer;
        DateTime dateTime;
        int gameEnd = 0;
        int h=0,m=0,s=0;
        public Menager(Form1 Okno)
        {
            Game = new Plansza();
            OknoGry = Okno;
            Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Tick += timer_Tick;
            dateTime = DateTime.Now;
            
        }

        public void init()
        {
            Game.init(OknoGry);
            Timer.Start();
        }

       private void timer_Tick(object sender, EventArgs e)
       {
            OknoGry.Label_change("STONES", "Kamienie: " + Game.stones.ToString());
            s++;
            if (s == 60)
            {
                s = 0;
                m++;
                if (m == 60)
                {
                    m = 0;
                    h++;
                }
            }
            OknoGry.Label_change("CZAS", $"Czas: {h:D2}:{m:D2}:{s:D2}");
            if (Game.stones == 0 && gameEnd == 0)
            {
               gameEnd = 1;
               OknoGry.end();
            }
        }

        public void HandleMenuSelection(string optionName)
        {
            switch (optionName)
            {
                case "zapisz":
                    SaveGame();
                    break;

                case "wczytaj":
                    LoadGame();
                    break;

                case "nowa":
                    NewGame();
                    break;
                case "cofnij":
                    Game.Undo();
                    Game.Undo();
                    break;
                case "wymieszaj":
                    Game.ShuffleThreeDimArray();
                    break;

                default:
                    break;
            }
        }

        private void SaveGame()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Pliki gry (*.game)|*.game";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Game.SaveGameState(saveFileDialog.FileName);
                }
            }
        }

        private void LoadGame()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Pliki gry (*.game)|*.game";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Game.LoadGameState(openFileDialog.FileName, OknoGry);
                }
            }
        }

        private void timerReset()
        {
            h = 0;
            m = 0;
            s = 0;
        }


        private void NewGame()
        {
            Game.Clear(OknoGry);
            Game.init(OknoGry);
            timerReset();
            gameEnd = 0;
        }
    }
}