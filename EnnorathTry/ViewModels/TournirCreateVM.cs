using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnnorathTry.ViewModels
{
    public class TournirCreateVM: VMBase
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

        private DateTime _startDate;
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
            }
        }

        private DateTime _dateFinish;
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
            }
        }

        public ICommand Create { get; }

        public ICommand Cancel { get; }

        public TournirCreateVM()
        { 
        
        }
    }
}