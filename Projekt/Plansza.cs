using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace mohjang
{
    [Serializable]
    internal class Plansza
    {
        public Klocek[] klocki = new Klocek[144];
        private static Stack<KlocekState> history = new Stack<KlocekState>();
        public int width;
        public int height;

        public int stones { get; set; }
        public Klocek[][][] layout = new Klocek[][][]
        {
            new Klocek[][] {
                new Klocek[9],
                new Klocek[9],
                new Klocek[7],
                new Klocek[9],
                new Klocek[9],
                new Klocek[7],
                new Klocek[9],
                new Klocek[9],
                new Klocek[7],
                new Klocek[9],
                new Klocek[9],
            },
            new Klocek[][] {
                new Klocek[0],
                new Klocek[6],
                new Klocek[5],
                new Klocek[6],
                new Klocek[0],
                new Klocek[6],
                new Klocek[0],
                new Klocek[6],
                new Klocek[5],
                new Klocek[6],
                new Klocek[0],
            },
            new Klocek[][] {
                new Klocek[0],
                new Klocek[0],
                new Klocek[4],
                new Klocek[0],
                new Klocek[0],
                new Klocek[3],
                new Klocek[0],
                new Klocek[0],
                new Klocek[0],
                new Klocek[4],
                new Klocek[0],
                
            }
        };

        Klocek selectedFirst = null;

        public void init(Form gra)
        {
            stones = klocki.Length;
            int amountOfSet = klocki.Length / 4;
            for (int i = 0; i < klocki.Length / 4; i++)
            {
                klocki[i] = new Klocek();
                klocki[i].id = i;
                klocki[i].text_klocek();
                gra.Controls.Add(klocki[i]);
                klocki[i + amountOfSet] = new Klocek();
                klocki[i + amountOfSet].id = i;
                klocki[i + amountOfSet].text_klocek();
                gra.Controls.Add(klocki[i + amountOfSet]);
                klocki[i + amountOfSet*2] = new Klocek();
                klocki[i + amountOfSet*2].id = i;
                klocki[i + amountOfSet*2].text_klocek();
                gra.Controls.Add(klocki[i + amountOfSet*2]);
                klocki[i + amountOfSet*3] = new Klocek();
                klocki[i + amountOfSet*3].id = i;
                klocki[i + amountOfSet*3].text_klocek();
                gra.Controls.Add(klocki[i + amountOfSet*3]);
            }
            width = gra.Width;
            height = gra.Width;
            Shuffle(klocki);
            layouts(klocki);
            readyToClick();
        }
        #region Menu Options
        public void SaveGameState(string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    var gameState = new GameState
                    {
                        Stones = this.stones,
                        KlockiStates = klocki.Select(k => new KlocekState
                        {
                            Id = k.id,
                            Level = k.Level,
                            Col = k.Col,
                            Row = k.Row,
                            WasVisible = k.Visible,
                            Flaga = k.Flaga,
                            Location = k.Location
                        }).ToArray()
                    };
                    formatter.Serialize(stream, gameState);
                }
                MessageBox.Show("Stan gry zapisany pomyślnie.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisywania stanu gry: {ex.Message}");
            }
        }

        public void LoadGameState(string filePath, Form1 gra)
        {
            try
            {
                Clear(gra);
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    var gameState = (GameState)formatter.Deserialize(stream);

                    this.stones = gameState.Stones;
                    var klockiStates = gameState.KlockiStates;

                    foreach (var klockiState in klockiStates)
                    {
                        var klocek = new Klocek()
                        {
                            id = klockiState.Id,
                            Level = klockiState.Level,
                            Col = klockiState.Col,
                            Row = klockiState.Row,
                            Visible = klockiState.WasVisible,
                            Flaga = klockiState.Flaga,
                            Location = klockiState.Location
                        };

                        gra.Controls.Add(klocek);
                    }
                    klocki = gra.Controls.OfType<Klocek>().ToArray();
                    layouts(klocki);
                    readyToClick();
                }
                MessageBox.Show("Stan gry wczytany pomyślnie.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wczytywania stanu gry: {ex.Message}");
            }
        }


        public void ShuffleThreeDimArray()
        {
            List<int> visibleIds = new List<int>();

            foreach (var klocek in klocki)
            {
                if (klocek.Visible)
                {
                    visibleIds.Add(klocek.id);
                }
            }

            int[] shuffledIds = Shuffle(visibleIds.ToArray());

            int index = 0;

            foreach (var klocek in klocki)
            {
                if (klocek.Visible)
                {
                    klocek.id = shuffledIds[index];
                    klocek.Refresh();
                    index++;
                }
            }

            readyToClick();
        }
        static T[] Shuffle<T>(T[] array)
        {
            Random random = new Random();
            int n = array.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;
        }

        public void Undo()
        {
            if (history.Count > 0)
            {
                var lastState = history.Pop();
                foreach (var item in klocki)
                {
                    if(lastState.Location == item.Location) { item.Visible = true; break; }
                }
                stones++;
            }
        }



        #endregion

        #region Events
        private void Klocek_MouseClicked(object sender, Klocek clickedKlocek)
        {
            if (selectedFirst == null)
            {
                selectedFirst = clickedKlocek;
                clickedKlocek.SelectKlocek(true);
            }
            else if (selectedFirst == clickedKlocek)
            {
                selectedFirst.SelectKlocek(false);
                selectedFirst = null;
            }
            else
            {
                if (selectedFirst != null && selectedFirst != clickedKlocek && isSameId(selectedFirst, clickedKlocek))
                {
                    SaveState(selectedFirst);
                    SaveState(clickedKlocek);
                    RemoveKlocki(selectedFirst, clickedKlocek);
                    selectedFirst = null;
                    stones -= 2;
                    readyToClick();
                }
                else
                {
                    selectedFirst.SelectKlocek(false);
                    clickedKlocek.SelectKlocek(true);
                    selectedFirst = clickedKlocek;
                }
            }
        }

        private void btnEnter(object sender, Klocek clickedKlocek)
        {
            clickedKlocek.BackColor = Color.FromArgb(70,Color.Red);
        }

        private void btnLeave(object sender, Klocek clickedKlocek)
        {
            clickedKlocek.BackColor = Color.Maroon;
        }


        


        #endregion

        #region Logic
        bool isSameId(Klocek a, Klocek b)
        {
            return a.id == b.id;
        }

        private void RemoveKlocki(Klocek first, Klocek second)
        {
            first.Visible = false;
            second.Visible = false;
        }

        void layouts(Klocek[] blocks)
        {
            int index = 0;

            for (int level = 0; level < layout.Length; level++)
            {
                for (int col = 0; col < layout[level].Length; col++)
                {
                    for (int row = 0; row < layout[level][col].Length; row++)
                    {
                        if (index < blocks.Length)
                        {
                            layout[level][col][row] = blocks[index];
                            blocks[index].Location = new Point(col * (blocks[index].Width) + level * 7 + 50, row * blocks[index].Height + level * 7 + 50 );
                            blocks[index].BringToFront();
                            index++;
                        }
                    }
                }
            }
        }

        void readyToClick()
        {
            for (int level = 0; level < layout.Length; level++)
            {
                for (int col = 0; col < layout[level].Length; col++)
                {
                    for (int row = 0; row < layout[level][col].Length; row++)
                    {
                        Klocek actualStone = layout[level][col][row];

                        if (actualStone.ReadyToClick || !actualStone.Visible)
                        {
                            continue;
                        }

                        bool readyU = true, readyL = true, readyR = true;

                        if (level + 1 < layout.Length && col < layout[level + 1].Length && row < layout[level + 1][col].Length)
                        {
                            if (layout[level + 1][col][row].Visible)
                            {
                                readyU = false;
                                actualStone.Flaga = 1;
                            }
                        }

                        if (col - 1 < 0 || col + 1 >= layout[level].Length)
                        {
                            if (readyL)
                            {
                                addMouseClick(actualStone);
                            }
                            continue;
                        }

                        if (col - 1 >= 0 && row < layout[level][col - 1].Length)
                        {
                            if (layout[level][col - 1][row].Visible)
                            {
                                readyL = false;
                                actualStone.Flaga = 2;
                            }
                        }

                        if (col + 1 < layout[level].Length && row < layout[level][col + 1].Length)
                        {
                            if (layout[level][col + 1][row].Visible)
                            {
                                readyR = false;
                                actualStone.Flaga = 2;
                            }
                        }

                        if (readyU && (readyL || readyR))
                        {
                            addMouseClick(actualStone);
                        }
                    }
                }
            }
        }

        void addMouseClick(Klocek klocek)
        {
            klocek.mouseClicked += Klocek_MouseClicked;
            klocek.btnLeave += btnLeave;
            klocek.btnEnter += btnEnter;
            klocek.ReadyToClick = true;
        }

        private void SaveState(Klocek klocek)
        {
            history.Push(new KlocekState
            {
                Level = klocek.Level,
                Col = klocek.Col,
                Row = klocek.Row,
                Location = klocek.Location,
                WasVisible = klocek.Visible,
                Flaga = klocek.Flaga
            });
        }

        public void Clear(Form gra)
        {
            stones = 144;
            for(int i = 0; i < klocki.Length;  i++)
            {
                gra.Controls.Remove(klocki[i]);
                klocki[i] = null;
            }
        }
    }

    #endregion
}
