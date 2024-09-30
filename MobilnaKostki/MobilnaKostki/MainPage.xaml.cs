using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobilnaKostki
{
    public partial class MainPage : ContentPage
    {
        public static List<Image> listaKosci;
        public static List<int> wylosowaneLiczby = new List<int>();
        public static int liczbaPunktowJedenLos = 0;
        public static int liczbaPunktowWszystkie = 0;
        public MainPage()
        {
            InitializeComponent();
            listaKosci = new List<Image>()
            {
                kostka1, kostka2, kostka3, kostka4, kostka5
            };
        }
        public void losujLiczbyDoKostek()
        {
            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                int wylosowanaLiczba = random.Next(1, 7);
                wylosowaneLiczby.Add(wylosowanaLiczba);
                listaKosci[i-1].Source = "liczba" + wylosowanaLiczba + ".png";
            }
            liczbaPunktowJedenLos = liczPunkty();
            wynikLoss.Text = "Wynik tego losowania: " + liczbaPunktowJedenLos;
            wynikGry.Text = "Wynik gry: " + liczbaPunktowWszystkie;
        }

        public int liczPunkty()
        {
            for (int j = 1; j <= 6; j++)
            {
                int liczPowtorki = 0;
                int wynik = 0;

                for (int i = 0; i < 5; i++)
                {
                    if (wylosowaneLiczby[i] == j)
                    {
                        liczPowtorki++;
                        wynik += j;
                    }
                }

                if (liczPowtorki >= 2)
                {
                    liczbaPunktowJedenLos += wynik;
                    liczbaPunktowWszystkie += wynik;
                }
            }

            return liczbaPunktowJedenLos;
        }

        private void rzutKosciButton_Clicked(object sender, EventArgs e)
        {
            liczbaPunktowJedenLos = 0;
            wylosowaneLiczby.Clear();
            losujLiczbyDoKostek();
        }

        private void resetujWynikButton_Clicked(object sender, EventArgs e)
        {
            liczbaPunktowWszystkie = 0;
            liczbaPunktowJedenLos = 0;
            wynikLoss.Text = "Wynik tego losowania: " + liczbaPunktowJedenLos;
            wynikGry.Text = "Wynik gry: " + liczbaPunktowWszystkie;
            for (int i = 1; i <= 5; i++)
            {
                listaKosci[i - 1].Source = "pytajnik.png";
            }
        }
    }
}
