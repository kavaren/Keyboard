using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Keyboard.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Keyboard.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        //Constructor
        public MainWindowViewModel()
        {
            InitializeCommands();
        }

        #region Private methods
        private void InitializeCommands()
        {
            AddCharCommand = new DelegateCommand<string>(_AddChar);
            DeleteCharCommand = new DelegateCommand(_DeleteChar);
            ClearCommand = new DelegateCommand(_Clear);
            AddNumberCommand = new DelegateCommand(_AddNumber);
            JsonSerialize = new DelegateCommand(_JsonSerializeNow);
            JsonDeserialize = new DelegateCommand(_JsonDeserializeNow);
        }

        private void _AddChar(string key)
        {
            DisplayText += key;
        }

        private void _Clear()
        {
            DisplayText = "";
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

        private void _AddNumber()
        {
            if (DisplayText != "")
            {
                NumberList.Add(new NumberModel(DisplayText));
                _Clear();
            }
        }
        public async void _JsonSerializeNow()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Keyboard\\NumberList\\";
            string filePath = path + "NumberList.json";

            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };

            using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(createStream, NumberList, options);
        }

        public async void _JsonDeserializeNow()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Keyboard\\NumberList\\";
            string filePath = path + "NumberList.json";
            using FileStream openStream = File.OpenRead(filePath);
            NumberList = await JsonSerializer.DeserializeAsync<ObservableCollection<NumberModel>>(openStream);
        }
        #endregion

        #region private fields
        private string inputString = "";
        private string displayText = "";
        private char[] specialChars = { '*', '#' };
        private ObservableCollection<NumberModel> numberList = new();
        #endregion

        #region Public properties
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
        public ObservableCollection<NumberModel> NumberList { get => numberList; set => SetProperty(ref numberList, value); }

        public ICommand AddCharCommand { get; set; }
        public ICommand DeleteCharCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand AddNumberCommand { get; set; }
        public ICommand JsonSerialize { get; set; }
        public ICommand JsonDeserialize { get; set; }
        #endregion

       /* 
        private string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(specialChars) != -1;
            string formatted = str;

            if (hasNonNumbers || str.Length < 4 || str.Length > 10)
            {
            }
            else if (str.Length < 8)
            {
                formatted = string.Format("{0}-{1}",
                                          str.Substring(0, 3),
                                          str.Substring(3));
            }
            else
            {
                formatted = $"({str.Substring(0, 3)}) {str.Substring(3, 3)}-{str.Substring(6)}";
            }
            return formatted;
        }
       */
    }
}