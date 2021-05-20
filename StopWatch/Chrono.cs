using System;

namespace StopWatch
{
    public class Chrono : IChrono
    {
        private readonly IClock _clock;
        private DateTime _start;
        private DateTime _stop;
        private bool _running;
        private TimeSpan? _lap;

        public Chrono(IClock clock)
        {
            _clock = clock;
            _stop = _start = clock.Now;
        }

        public void StartStop()
        {
            _lap = null;
            if (_running)
            {
                _stop = _clock.Now;
            }
            else
            {
                _start = _clock.Now;
            }

            _running = !_running;
        }

        public void LapReset()
        {
            if (_lap.HasValue) _lap = null;
            else _lap = _clock.Now - _start;
        }

        public TimeSpan Elapsed => _lap ?? _stop - _start;
    }
}