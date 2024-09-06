using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SumaAppMvvm
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _firstNumber;
        private string _secondNumber;
        private string _result;

        public string FirstNumber
        {
            get => _firstNumber;
            set
            {
                _firstNumber = value;
                OnPropertyChanged(nameof(FirstNumber));
            }
        }

        public string SecondNumber
        {
            get => _secondNumber;
            set
            {
                _secondNumber = value;
                OnPropertyChanged(nameof(SecondNumber));
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand SumarCommand { get; }
        public ICommand LimpiarCommand { get; }


#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        public MainPageViewModel()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.


        {
            SumarCommand = new Command(ExecuteSumarCommand);
            LimpiarCommand = new Command(ExecuteLimpiarCommand);
        }

        private void ExecuteSumarCommand()
        {
            if (string.IsNullOrWhiteSpace(FirstNumber) || string.IsNullOrWhiteSpace(SecondNumber))
            {
                Result = "Por favor ingrese ambos números.";
                return;
            }

            if (double.TryParse(FirstNumber, out double num1) && double.TryParse(SecondNumber, out double num2))
            {
                Result = $"Resultado: {num1 + num2}";
            }
            else
            {
                Result = "Ingrese valores válidos.";
            }
        }

        private void ExecuteLimpiarCommand()
        {
            FirstNumber = string.Empty;
            SecondNumber = string.Empty;
            Result = string.Empty;
        }

#pragma warning disable CS8612 // La nulabilidad de los tipos de referencia del tipo no coincide con el miembro implementado de forma implícita
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS8612 // La nulabilidad de los tipos de referencia del tipo no coincide con el miembro implementado de forma implícita

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
