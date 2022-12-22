namespace DobuCalCulator
{
    public class DataUtil
    {
        public DataUtil()
        {

        }

        public BinomialData MakeBinomialData(InputData data)
        {                    
            int trials = -1;
            double probability = 0;
            int success = 0;

            try{
                trials = GetT<int>(data.trials, 1, int.MaxValue);
                probability = GetT<double>(data.probability, 0, 100);
                success = GetT<int>(data.success, 0, trials);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Input value is not supported type.");
            }

            if (trials < success)
            {
                throw new Exception("Number of trials must be greater than or equal to number of successes.");
            }
            
            return new BinomialData(trials, probability, success);
        }


        T GetT<T>(string input, T min, T max) where T : struct, IComparable<T>
        {
            T result = default(T);
            
            try{
                result = ConvertType<T>(input);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Input value is not supported type.");
            }
            
            var resultCompareToMin = result.CompareTo(min);
            var maxCompareToResult = max.CompareTo(result);

            if(result.CompareTo(min) < 0 || max.CompareTo(result) < 0)
            {
                throw new Exception("Input value is out of range.");
            }
            return result;
        }

        T ConvertType <T>(string input) where T : struct
        {
            T result = default(T);
            // convert input to T : int, double ...
            if (typeof(T) == typeof(int))
            {
                try{
                    result = (T)Convert.ChangeType(int.Parse(input), typeof(T));
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception("convert to int failed.");
                }
            }
            else if (typeof(T) == typeof(double))
            {
                try{
                    result = (T)Convert.ChangeType(double.Parse(input), typeof(T));
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception("convert to double failed.");
                }
            }
            else
            {
                throw new Exception("Not supported type. Please use int or double.");
            }
            return result;
        }
    }
}