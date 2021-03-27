namespace Keyboard.Models
{
    /// <summary>
    /// Futureproof Model Class 
    /// </summary>
    public class NumberModel
    {
        private string _number;

        public NumberModel(string number)
        {
            _number = number;
        }

        public string Number { get => _number; set => _number = value; }

    }
}