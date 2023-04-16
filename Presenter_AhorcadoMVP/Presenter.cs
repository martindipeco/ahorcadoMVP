using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Domain_AhorcadoMVP;

namespace Presenter_AhorcadoMVP
{
    public class Presenter
    {
        private readonly Ahorcado _ahorcado;
        private readonly IView _view;

        public Presenter(IView view)
        {
            _ahorcado = new Ahorcado();
            _view = view;
        }

        #region "Use Cases"

        public int GetBodyParts()
        {
            return _ahorcado.BodyParts();
        }

        public String GetWord()
        {
            return _ahorcado.RandomWord();
        }

        public int GetNumberOfGuesses()
        {
            return _ahorcado.GetNumberOfGuesses();
        }

        public void CheckAddLetter(String letra)
        {
            if (!_ahorcado.CheckLetter(letra))
            {
                _ahorcado.IncreaseBodyParts();
                _ahorcado.DecreaseNumberOfGuesses();
                _view.Show_text("Esa letra no está");
                //PLAY SOUND
            }
            else
            {
                _ahorcado.AciertaLetra(letra);
                _view.Show_text("Acertaste la letra");
                //PLAY SOUND
            }
        }

        public void AgregarUsada(String letra)
        {
            _ahorcado.AgregarUsada(letra);
        }

        public List<string> GetLetrasUsadas()
        {
            return _ahorcado.LetrasUsadas();
        }

        public String[] GetLettersGuessed()
        {
            return _ahorcado.GetLettersGuessed();
        }

        public string DisplayPalabra()
        {
            return _ahorcado.DisplayPalabrAdivinar();
        }

        public bool YouWin()
        {
            if (_ahorcado.YouWin())
            {
                return true;
            }
            return false;
        }

        public void YouLose()
        {
            _ahorcado.YouLose();
        }

        #endregion
    }
}
