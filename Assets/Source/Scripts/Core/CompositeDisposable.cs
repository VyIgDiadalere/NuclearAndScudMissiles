using System;
using System.Collections.Generic;

namespace Source.Scripts.Core
{
    public class CompositeDisposable: IDisposable
    {
        private readonly List<IDisposable> _disposables =  new ();
        private bool _isDisposed = false;

        public void Add(IDisposable disposable)
        {
            if (_isDisposed)
            {
                disposable.Dispose();
            }
            else
            {
                _disposables.Add(disposable);
            }
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
            
            _isDisposed = true;
            _disposables.Clear();
        }
    }
}