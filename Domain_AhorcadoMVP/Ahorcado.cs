using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
//using System.Windows.Extensions, Version=4.0.1.0, Culture=neutral, PublicKeyToken = cc7b13ffcd2ddd51;

namespace Domain_AhorcadoMVP
{
    public class Ahorcado
    {
        private static string[] palabras = { "nave", "alien", "planeta", "estrella", "galaxia", "satelite", "cosmonauta", "astronauta", "exploracion", "orbita", "supernova", "telescopio", "cometa", "meteorito", "constelacion", "eclipse", "cosmos", "espacio", "gravedad", "luna", "marte", "nebulosa", "sistema", "nuclear", "tierra", "cohete", "mision" };

        private static Random random = new Random();

        private static int randomNumber = random.Next(palabras.Length);
        private static String randomWord = palabras[randomNumber];

        private int numberOfGuesses = 6;
        private int bodyParts = 0;

        private String[] letrasAdivinadas = new String[randomWord.Length];

        List<string> letrasUsadas = new List<string>();

        //SoundPlayer sound = new SoundPlayer("festeja.mp3");

        //System.Windows.Extensions.SoundPlayer audio1 = new System.Windows.Extensions.SoundPlayer;

        //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\mywavfile.wav");

        //public System.Media.SoundPlayer Player { get => player; set => player = value; }

        //player.Play();

        public Ahorcado()
        {
            int randomNumber = random.Next(palabras.Length);
            String randomWord = palabras[randomNumber];
            String[] letrasAdivinadas = new String[randomWord.Length];
            int numberOfGuesses = 6;
            int bodyParts = 0;
        }

        public int BodyParts() { return bodyParts; }

        public String RandomWord()
        {
            return randomWord;
        }

        public int GetNumberOfGuesses()
        {
            return numberOfGuesses;
        }

        public void DecreaseNumberOfGuesses()
        {
            numberOfGuesses = numberOfGuesses - 1;
        }

        public void IncreaseBodyParts()
        {
            bodyParts++;
        }

        public bool CheckLetter(String letter)
        {
            if (letter.Length == 1 && char.IsLetter(letter[0]))
            {
                if (randomWord.Contains(letter))
                {
                    return true;
                }
            }
            return false;
        }

        public String[] GetLettersGuessed()
        {
            return letrasAdivinadas;
        }

        public void AgregarUsada(String letra)
        {
            letrasUsadas.Add(letra);
        }

        public List<String> LetrasUsadas()
        {
            return letrasUsadas;
        }

        public void AciertaLetra(String letra)
        {
            letrasAdivinadas[randomWord.IndexOf(letra)] = letra;
        }

        public string DisplayPalabrAdivinar()
        {
            string word = "";

            for (int i = 0; i < randomWord.Length; i++)
            {
                if (Array.IndexOf(letrasAdivinadas, randomWord[i].ToString()) != -1)
                {
                    word += randomWord[i];
                }
                else
                {
                    word += "_";
                }
            }
            return word;
        }

        public bool YouWin()
        {
            if (DisplayPalabrAdivinar() == randomWord)
            {
                // set all attributes to default
                randomNumber = random.Next(palabras.Length);
                randomWord = palabras[randomNumber];
                numberOfGuesses = 6;
                bodyParts = 0;
                letrasAdivinadas = new String[randomWord.Length];
                letrasUsadas = new List<string>();
                
                //PLAY SOUND

                return true;
            }
            return false;
        }

        public void YouLose()
        {
            // set all attributes to default
            randomNumber = random.Next(palabras.Length);
            randomWord = palabras[randomNumber];
            numberOfGuesses = 6;
            bodyParts = 0;
            letrasAdivinadas = new String[randomWord.Length];
            letrasUsadas = new List<string>();

            //PLAY SOUND
        }
    }
}
