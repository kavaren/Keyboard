using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;

namespace Keyboard.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        //Constructor
        public MainWindowViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            AddCharCommand = new DelegateCommand<string>(_AddChar);

            DeleteCharCommand = new DelegateCommand(_DeleteChar);
        }

        private void _AddChar(string key)
        {
            DisplayText += key;
        }


        private void _DeleteChar()
        {
            try
            {
                DisplayText = DisplayText.Substring(0, DisplayText.Length - 1);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        private string inputString = "";
        private string displayText = "54";
        private char[] specialChars = { '*', '#' };

        // Public properties
        public string InputString
        {
            get => inputString;
            set => SetProperty(ref inputString, value);
        }

        public string DisplayText
        {
            get => displayText;
            set => SetProperty(ref displayText, value);
        }

        public ICommand AddCharCommand { get; set; }
        public ICommand DeleteCharCommand { get; set; }

        string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(specialChars) != -1;
            string formatted = str;

            if (hasNonNumbers || str.Length < 4 || str.Length > 10)
            {
            }
            else if (str.Length < 8)
            {
                formatted = String.Format("{0}-{1}",
                                          str.Substring(0, 3),
                                          str.Substring(3));
            }
            else
            {
                formatted = String.Format("({0}) {1}-{2}",
                                          str.Substring(0, 3),
                                          str.Substring(3, 3),
                                          str.Substring(6));
            }
            return formatted;
        }
    }
}
