using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter_AhorcadoMVP;

namespace View_AhorcadoMVP
{
    public class View : IView
    {
        private readonly Presenter _Presenter;

        public View()
        {
            _Presenter = new Presenter(this);
            Show_main_menu();
        }

        #region "View logic methods"

        private void Show_main_menu()
        {
            string optionString;
            bool exit = false;
            do
            {
                Console.Clear();
                Show_text("-== Bienvenido al ahorcado, Terrícola ==-");
                Show_text("¿Aceptás el desafío?");
                Show_text("");
                Show_text("1- Jugar");
                Show_text("X- Salir");

                optionString = Console.ReadLine();
                
                Run_a_main_menu_option(optionString, ref exit);

            } while (exit == false);
        }

        private void Run_a_main_menu_option(string optionString, ref bool exit)
        {
            switch (optionString)
            {
                case "1":
                    ShowGameStart();
                    exit = false;
                    break;
                case "x":
                case "X":
                    Environment.Exit(2);
                    break;
                default:
                    Show_text("La opción ingresada es inválida, por favor reintente.");
                    Console.ReadKey();
                    exit = false;
                    break;
            }
        }

        private void ShowGameStart()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Que comience el juego!");
            Console.WriteLine("");
            DrawHangman(_Presenter.GetBodyParts());
            Console.WriteLine("");
            Console.WriteLine("Ya elegí una palabra, de " + _Presenter.GetWord().Length + " letras");
            Console.WriteLine("");
            Console.WriteLine("La palabra es " + _Presenter.GetWord());
            Console.WriteLine("Tenés " + _Presenter.GetNumberOfGuesses() + " intentos");


            while (_Presenter.GetNumberOfGuesses()  > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("¿Qué letra elegís?");
                String letraElegida = Console.ReadLine().ToLower();

                if (letraElegida.Length == 1 && char.IsLetter(letraElegida[0]) && !_Presenter.GetLettersGuessed().Contains(letraElegida))
                {
                    Console.Clear();
                    _Presenter.CheckAddLetter(letraElegida);

                    DrawHangman(_Presenter.GetBodyParts());
                    Console.WriteLine("");
                    Console.WriteLine(_Presenter.DisplayPalabra());
                    Console.WriteLine("");
                    Console.WriteLine("Tenés " + _Presenter.GetNumberOfGuesses() + " intentos");
                    Console.WriteLine("");
                    _Presenter.AgregarUsada(letraElegida);
                    
                    Console.Write("Letras usadas: ");
                    Console.WriteLine("");

                    foreach (string l in _Presenter.GetLetrasUsadas())
                    {
                        Console.Write(l + " ");
                    }
                    if (_Presenter.YouWin())
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ME GANASTE!");
                        //bool ganasteAhorcado = true;
                        Console.WriteLine("");
                        Console.WriteLine("Presioná cualquier tecla para volver al menú principal");
                        Console.ReadKey();
                        Show_main_menu();
                    }
                }
                else
                {
                    if (letraElegida.Length != 1)
                    {
                        Console.WriteLine("Ingresaste más de una letra");
                    }
                    else if (_Presenter.GetLettersGuessed().Contains(letraElegida))
                    {
                        Console.WriteLine("Ya elegiste esa letra");
                    }
                    else
                    {
                        Console.WriteLine("Lo que tocaste no es una letra");
                    }
                    Console.WriteLine("Por favor ingresá un caracter válido");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Game over! La palabra era " + _Presenter.GetWord());
            _Presenter.YouLose();
            Console.WriteLine("Apretá cualquier tecla para volver al menú principal");
            Console.ReadKey();
            Show_main_menu();
        }

        static void DrawHangman(int bodyParts)
        {
            switch (bodyParts)
            {
                case 0:
                    Console.WriteLine(" _____   ");
                    Console.WriteLine("|     |  ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("=========");
                    break;
                case 1:
                    Console.WriteLine(" _____   ");
                    Console.WriteLine("|     |  ");
                    Console.WriteLine("|     O  ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("=========");
                    break;
                case 2:
                    Console.WriteLine(" _____   ");
                    Console.WriteLine("|     |  ");
                    Console.WriteLine("|     O  ");
                    Console.WriteLine("|     |  ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("=========");
                    break;
                case 3:
                    Console.WriteLine(" _____   ");
                    Console.WriteLine("|     |  ");
                    Console.WriteLine("|     O  ");
                    Console.WriteLine("|    /|  ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("=========");
                    break;
                case 4:
                    Console.WriteLine(" _____   ");
                    Console.WriteLine("|     |  ");
                    Console.WriteLine("|     O  ");
                    Console.WriteLine("|    /|\\ ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("=========");
                    break;
                case 5:
                    Console.WriteLine(" _____   ");
                    Console.WriteLine("|     |  ");
                    Console.WriteLine("|     O  ");
                    Console.WriteLine("|    /|\\ ");
                    Console.WriteLine("|    /   ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("=========");
                    break;
                case 6:
                    Console.WriteLine(" _____   ");
                    Console.WriteLine("|     |  ");
                    Console.WriteLine("|     O  ");
                    Console.WriteLine("|    /|\\ ");
                    Console.WriteLine("|    / \\ ");
                    Console.WriteLine("|        ");
                    Console.WriteLine("=========");
                    break;
            }
        }
        #endregion

        #region "IView interface methods"
        public void Show_text(string text)
        {
            Console.WriteLine(text);
        }
        
        #endregion
    }
}
