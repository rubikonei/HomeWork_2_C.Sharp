using System;

namespace SmartHouse
{
    public class HomeCinema : MultimediaDevice
    {
        public FilmList film;

        public HomeCinema(string name, bool state, FilmList film)
        {
            this.name = name;
            this.state = state;
            this.film = film;
            if (state == true)
            {
                Power = 0.3;
            }
        }

        public override void On()
        {
            state = true;
            Power = 0.3;
            film = (FilmList)1;
        }

        public override void Off()
        {
            state = false;
            Power = 0;
            film = (FilmList)1;
        }

        public override void Next()
        {
            if ((int)film < Enum.GetValues(typeof(FilmList)).Length && state == true)
            {
                film++;
            }
            if ((int)film == Enum.GetValues(typeof(FilmList)).Length && state == true)
            {
                film = (FilmList)1;
            }
        }

        public override void Previous()
        {
            if ((int)film > 1 && state == true)
            {
                film--;
            }
            if ((int)film == 1 && state == true)
            {
                film = (FilmList)Enum.GetValues(typeof(FilmList)).Length;
            }
        }

        public override void Set(int f)
        {
            if (state == true && f >= 1 && f <= 6)
            {
                film = (FilmList)f;
            }
        }

        public override string ToString()
        {
            string film;
            if (this.film == FilmList.ForrestGump)
            {
                film = "Форрест Гамп";
            }
            else if (this.film == FilmList.Interstellar)
            {
                film = "Интерстеллар";
            }
            else if (this.film == FilmList.Intouchables)
            {
                film = "1+1";
            }
            else if (this.film == FilmList.SchindlersList)
            {
                film = "Список Шиндлера";
            }
            else if (this.film == FilmList.TheGreenMile)
            {
                film = "Зеленая миля";
            }
            else
            {
                film = "Побег из Шоушенка";
            }
            return base.ToString() + ", фильм: " + film;
        }
    }
}