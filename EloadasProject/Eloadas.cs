using System;

namespace EloadasProject
{
    public class Eloadas
    {

        private bool[,] foglalasok;

        public Eloadas(int sorok, int helyek) //sorok és helyek 1-10 között
        {
            if (sorok < 1 || sorok >= 11 || helyek < 1 || helyek >= 11)
            {
                throw new ArgumentException("A sorok számának és helyek számának 0-nál nagyobbnak kell lenniük.");
            }

            foglalasok = new bool[sorok, helyek];
        }

        public bool Lefoglal()
        {
            for (int i = 0; i < foglalasok.GetLength(0); i++)
            {
                for (int j = 0; j < foglalasok.GetLength(1); j++)
                {
                    if (!foglalasok[i, j])
                    {
                        foglalasok[i, j] = true;
                        return true; // Sikeres foglalás!
                    }
                }
            }
            return false; // Sikertelen foglalás => nincs szabad hely!
        }

        public int SzabadHelyek()
        {
            
            int szabadHely = 0;
            
            for (int i = 0; i < foglalasok.GetLength(0); i++)
            {
                for (int j = 0; j < foglalasok.GetLength(1); j++)
                {
                    if (!foglalasok[i, j])
                    {
                        szabadHely++;
                    }
                }
            }
            return szabadHely;
            
        }

        public bool Megtelt()
        {
            foreach (bool hely in foglalasok)
            {
                if (!hely)
                {
                    return false;
                }
            }
            return true;

        }


        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorSzam <= 0 || sorSzam > foglalasok.GetLength(0) || helySzam <= 0 || helySzam > foglalasok.GetLength(1))
            {
                throw new ArgumentException("Érvénytelen a sorszám vagy a helyszáma!");
            }

            return foglalasok[sorSzam - 1, helySzam - 1];
        }
    }
}