namespace AxRPCClientGenerator.Data
{
    public class TimeoutHolder
    {
        public int Timeout { get; set; }
        public int Retry { get; set; }
        public int TimeoutRetry { get; set; } = 10;
    }
}