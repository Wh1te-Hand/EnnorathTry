using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _isExecuting;

        private bool IsExecuting
        {
            get
            { 
                return _isExecuting;
            }
            set
            { 
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object param)
        {
            return !IsExecuting&&base.CanExecute(param);
        }
        public override async void Execute(object param)
        {
            _isExecuting = true;

            try 
            {
                await ExecuteAsync(param);
            }
            finally 
            {
                _isExecuting = false;
            }            
        }
    
        public abstract Task ExecuteAsync(object param);
    }
}
