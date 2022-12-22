using System.Numerics;

namespace DobuCalCulator
{
    public readonly struct InputData
    {
        public readonly string trials { get; }
        public readonly string probability { get; }
        public readonly string success { get; }

        public InputData(string trials, string probability, string success)
        {
            this.trials = trials;
            this.probability = probability;
            this.success = success;
        }
    }

    public readonly struct BinomialData
    {
        public readonly int trialCount { get; }
        public readonly double probability { get; }
        public readonly int successCount { get; }

        public BinomialData(int trialCount, double probability, int successCount)
        {
            this.trialCount = trialCount;
            this.probability = probability;
            this.successCount = successCount;
        }
    }

    public readonly struct ResultData
    {
        public readonly BigInteger result { get; }
        public readonly int decimalPoint { get; }

        public ResultData(BigInteger result, int decimalPoint, int correctedCount)
        {
            this.decimalPoint = decimalPoint - (MetaData.CALCULATE_PRECISION * correctedCount);
            BigInteger temp = result;
            // if decimalPoint is negative, multiply 10 to result by the number of times
            for(int i = 0; i < - this.decimalPoint; i++)
            {
                temp *= 10;
            }
            this.result = temp;
        }
    }

}