namespace DobuCalCulator
{
    public readonly struct DataBundle
    {
        public readonly double probability;
        public readonly int roof; // 천장
        public DataBundle(double probability, int roof)
        {
            this.probability = probability;
            this.roof = roof;
        }
    }

    public static class DataStore
    {
        public readonly static Dictionary<string, DataBundle> data = 
        new Dictionary<string, DataBundle>()
        {
            {"UmaMusume", new DataBundle(0.75, 200)}
        };
    }
}