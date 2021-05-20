using System;

namespace StopWatch
{
    public interface IClock
    {
        public DateTime Now { get; }
    }
}