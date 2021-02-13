using System;

namespace Principia.Mocking
{
    public abstract class CallableMock
    {
        protected int _count;
        protected object _mutex;
        protected Exception _exn;

        protected CallableMock()
        {
            _count = 0;
            _mutex = new object();
            _exn = null;
        }

        public void ResetInvokes()
        { 
            lock (_mutex) _count = 0; 
        }
        
        public void ClearThrowException()
        {
            _exn = null;
        }

        public void ThrowsException(Exception exn)
        {
            _exn = exn;
        }

        public void ThrowsException<T>() where T : Exception, new()
        {
            _exn = new T();
        }

        public void VerifyInvoked(Func<int, TimesResult> times)
        {
            var result = times(_count);
            if (result.IsError)
                throw new Exception(result.Message);
        }

        protected void Exec()
        {
            lock (_mutex)
                _count++;

            if (_exn != null)
                throw _exn;
        }
    }
}
