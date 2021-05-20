using System;

namespace StopWatch
{
    public interface IChrono
    {
        void StartStop();
        void LapReset();
        TimeSpan Elapsed { get; }
    }
}