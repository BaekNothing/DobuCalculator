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
            
            //Show FailureResult
            try
            {
                ResultData binomialFailureResult = calculateUtil.GetBinomialFailureDistribution(data);
                Console.Write($"{Environment.NewLine}Fail   : ");
                Console.Write(UiUtil.SetResultString(binomialFailureResult));
            }catch(Exception e){ 
                Console.Write($"{Environment.NewLine}Fail   : -% [Calculate fail : {e.Message}]");
            }
            
            //Show DobuResult
            ResultData binomialDobuResult = calculateUtil.GetBinomialDobuDistribution(data);
            Console.Write($"{Environment.NewLine}Dobu   : ");
            Console.Write(UiUtil.SetResultString(binomialDobuResult));

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Press any key to exit.");
            Console.ReadLine();
        }
    }
}