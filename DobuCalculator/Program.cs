namespace DobuCalCulator
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            CalculateUtil calculateUtil = new CalculateUtil();
            UserInterfaceUtil UiUtil = new UserInterfaceUtil();            
            BinomialData data = UiUtil.StartMakingBinomialDataSequince();

            //Result
            Console.Clear();
            Console.WriteLine(UiUtil.SetSelectString(data));

            //Show binomialResult            
            ResultData binomialResult = calculateUtil.GetBinomialDistribution(data);
            Console.Write($"{Environment.NewLine}Result : ");
            Console.Write(UiUtil.SetResultString(binomialResult));            
            
            if(data.successCount > 0)
            {
                //Show FailureResult
                ResultData binomialFailureResult = calculateUtil.GetBinomialFailureDistribution(data);
                Console.Write($"{Environment.NewLine}Fail   : ");
                Console.Write(UiUtil.SetResultString(binomialFailureResult));
                
                //Show DobuResult
                ResultData binomialDobuResult = calculateUtil.GetBinomialDobuDistribution(data);
                Console.Write($"{Environment.NewLine}Dobu   : ");
                Console.Write(UiUtil.SetResultString(binomialDobuResult));
            }

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Press any key to exit.");
            Console.ReadLine();
        }
    }
}