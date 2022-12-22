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
            ResultData binomialResult = calculateUtil.GetBinomialDistribution(data);
            ResultData binomialFailureResult = calculateUtil.GetBinomialFailureDistribution(data);
            ResultData binomialDobuResult = calculateUtil.GetBinomialDobuDistribution(data);

            Console.Clear();
            Console.WriteLine(UiUtil.SetSelectString(data));
            Console.Write($"{Environment.NewLine}Result : ");
            Console.Write(UiUtil.SetResultString(binomialResult));            
            Console.Write($"{Environment.NewLine}Fail   : ");
            Console.Write(UiUtil.SetResultString(binomialFailureResult));
            Console.Write($"{Environment.NewLine}Dobu   : ");
            Console.Write(UiUtil.SetResultString(binomialDobuResult));

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Press any key to exit.");
            Console.ReadLine();
        }
    }
}