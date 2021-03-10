namespace Keyboard.Models
{
    public class PhoneNumber
    {
        private string _number = "";

        public PhoneNumber() { }

        public PhoneNumber(string number) : base()
        {
            _number = number;
        }

        public string Number { get => _number; set => _number = value; }

    }
}
