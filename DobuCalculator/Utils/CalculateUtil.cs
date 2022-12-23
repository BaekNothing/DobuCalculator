using System.Numerics;

namespace DobuCalCulator
{   
    public class CalculateUtil
    {
        public ResultData GetBinomialDobuDistribution(in BinomialData data)
        {
            int trialCount = data.trialCount;
            double probability = data.probability;
            int successCount = 0;

            return GetBinomialDistribution(new BinomialData(trialCount, probability, successCount));
        }

        public ResultData GetBinomialFailureDistribution(in BinomialData data)
        {
            int trialCount = data.trialCount;
            double probability = data.probability;
            int failureCount = data.successCount - 1;

            if(failureCount < 0)
            {
                return new ResultData(0, 0, 0);
            }

            ResultData result = new ResultData(0, 0, 0);
            for(int i = 0; i <= failureCount; i++)
            {
                try{
                    result = SumResult(result, GetBinomialDistribution(new BinomialData(trialCount, probability, i)));
                }catch(Exception e)
                {
                    Console.Write($"{Environment.NewLine}fail when get failurdistribution while sum result : {e.Message}");
                    return new ResultData(0, 0, 0);
                }
            }
            return result;            
        }

        ResultData SumResult(in ResultData result1, in ResultData result2)
        {
            BigInteger result = 0;
            int decimalPoint = 0;

            try
            {
                if(result1.decimalPoint == result2.decimalPoint)
                {
                    result = result1.result + result2.result;
                    decimalPoint = result1.decimalPoint;
                }
                else if(result1.decimalPoint > result2.decimalPoint)
                {
                    result = result1.result + result2.result * (BigInteger)Math.Pow(10, result1.decimalPoint - result2.decimalPoint);
                    decimalPoint = result1.decimalPoint;
                }
                else
                {
                    result = result1.result * (BigInteger)Math.Pow(10, result2.decimalPoint - result1.decimalPoint) + result2.result;
                    decimalPoint = result2.decimalPoint;
                }
            }catch(Exception e)
            {
                Console.Write($"{Environment.NewLine}fail when try sum results, {e.Message}");
                throw e;
            }

            return new ResultData(result, decimalPoint, 0);
        }

        public ResultData GetBinomialDistribution(in BinomialData data)
        {
            BigInteger result = 0;
         
            int trialCount = data.trialCount;
            double probability = data.probability / 100;
            int successCount = data.successCount;

            int decimalPoint = 0;
            int decimalCorrectedCount = 0;

            BigInteger upper = GetPositiveFactorial(trialCount);
            BigInteger lower = GetPositiveFactorial(successCount) * GetPositiveFactorial(trialCount - successCount);

            // MULTIPLY 10^FACTORIAL_PRECISION TO GET MORE ACCURACY
            upper *= (BigInteger)Math.Pow(10, MetaData.CALCULATE_PRECISION);
            decimalPoint += MetaData.CALCULATE_PRECISION;
            decimalCorrectedCount++;

            result = upper / lower;
            
            result = 
                GetPositiveFactorial(trialCount)
                / (GetPositiveFactorial(successCount) * GetPositiveFactorial(trialCount - successCount));

            double pow = Math.Pow(probability, successCount) * Math.Pow((1 - probability), trialCount - successCount);
            if(pow > 0)
            {
                while(pow < 1) 
                {
                    pow *= 10;
                    decimalPoint++;
                }
                pow *= Math.Pow(10, MetaData.CALCULATE_PRECISION);
                decimalPoint += MetaData.CALCULATE_PRECISION;
                decimalCorrectedCount++;
            }
            else
            {
                pow = 0;
            }

            return new ResultData(result * (BigInteger)pow, decimalPoint, decimalCorrectedCount);
        }

        BigInteger GetPositiveFactorial(int inputNumber)
        {
            if(inputNumber < 0)
                throw new Exception("Input number must be positive");

            BigInteger result = 1;
            for (int i = 1; i <= inputNumber; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}