using EnnorathTry.Commands;
using EnnorathTry.Models;
using EnnorathTry.Services;
using EnnorathTry.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnnorathTry.ViewModels
{
    public class TournirCreateVM: VMBase,INotifyDataErrorInfo
    {
        private string _tournirName;
        public string TournirName
        {
            get
            { 
                return _tournirName;
            }
            set
            {
                _tournirName = value;
                OnPropertyChanged(nameof(TournirName));
            }
        }

        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private string _count;
        public string Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        private DateTime _startDate=new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime DateStart 
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(DateStart));

                ClearErrors(nameof(DateStart));
                ClearErrors(nameof(DateFinish));
                if (DateFinish < DateStart)
                {
                    AddError("The start date can not be after the finish date.", nameof(DateStart));
                    AddError("The end date can not be before the start date.", nameof(DateFinish));
                }
            }
        }

        private DateTime _dateFinish = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);

        public DateTime DateFinish
        {
            get
            {
                return _dateFinish;
            }
            set
            {
                _dateFinish = value;
                OnPropertyChanged(nameof(DateFinish));

                ClearErrors(nameof(DateStart));
                ClearErrors(nameof(DateFinish));
                if (DateFinish < DateStart)
                {
                    AddError("The start date can not be after the finish date.", nameof(DateStart));
                    AddError("The end date can not be before the start date.",nameof(DateFinish));
                }
            }
        }

        private void AddError(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrorDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorDictionary.Add(propertyName,new List<string>());
            }

            _propertyNameToErrorDictionary[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorDictionary.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        public ICommand Create { get; }
        public ICommand Cancel { get; }
        public ICommand GoToList { get; }

        private readonly Dictionary<string, List<string>> _propertyNameToErrorDictionary;
        public bool HasErrors => _propertyNameToErrorDictionary.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public TournirCreateVM(TournamentStore tourStore,  NavigationService tournirListNavService)
        {
            Create = new AddTournamentCommand(this, tourStore, tournirListNavService);
            Cancel = new CancelCommand();   
            GoToList = new NavigateCommand(tournirListNavService);
            _propertyNameToErrorDictionary = new Dictionary<string, List<string>>();
        }
      
        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyNameToErrorDictionary.GetValueOrDefault(propertyName, new List<string>());
        }
    }
}