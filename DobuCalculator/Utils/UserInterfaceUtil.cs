using System.Text;

namespace DobuCalCulator
{
    public class UserInterfaceUtil
    {
        DataUtil DataUtil = new DataUtil();

        public UserInterfaceUtil()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public BinomialData StartMakingBinomialDataSequince()
        {
            return ChooseSequince(0);
        }

        BinomialData ChooseSequince(int selectType)
        {   
            SetChooseSequinceMessage(0);
            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch(ch)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine(
                            $"Escape Pressed.. {Environment.NewLine} Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.UpArrow:
                        selectType = selectType <= 0 ? 0 : selectType - 1;
                        SetChooseSequinceMessage(selectType);
                        break;
                    case ConsoleKey.DownArrow:
                        selectType = selectType >= UiMessages.MENU.Length - 1 ? UiMessages.MENU.Length - 1 : selectType + 1;
                        SetChooseSequinceMessage(selectType);
                        break;
                    case ConsoleKey.Enter:
                        if(selectType == 0)
                        {
                            return MakeBinomialDataFromInput();
                        }
                        else if(selectType == 1)
                        {
                            return MakeBinomialDataFromSelectableDataset();
                        }
                        break;
                    default:
                        SetChooseSequinceMessage(selectType);
                        break;
                }
            }
        }

        void SetChooseSequinceMessage(int selectType)
        {
            Console.Clear();
            Console.WriteLine(UiMessages.INTRO);
            for(int i = 0; i < UiMessages.MENU.Length; i++)
            {
                if(i == selectType)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"{i + 1}. {UiMessages.MENU[i]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public BinomialData MakeBinomialDataFromInput()
        {
            BinomialData? nullableData = null;
            while(nullableData == null)
            {
                try{
                    nullableData = DataUtil.MakeBinomialData(new InputData
                    (
                        GetInput(UiMessages.INPUT[0]),
                        GetInput(UiMessages.INPUT[1]),
                        GetInput(UiMessages.INPUT[2]))
                    );
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    nullableData = null;
                }
            }
            return nullableData.Value;
        }
        
        public string GetInput(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            string? input = null;
            while(CheckNullableStringIsEmpty(input))
            {
                input = Console.ReadLine();
            }
            
            return input != null ? input : "";
        }

        bool CheckNullableStringIsEmpty(string? input)
        {
            if (input == null || input == string.Empty || input == "" )
            {
                return true;
            }
            return false;
        }

        BinomialData MakeBinomialDataFromSelectableDataset()
        {
            SetSelectableDataMessage(0);
            int index = 0;

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch(ch)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine(
                            $"Escape Pressed.. {Environment.NewLine} Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.UpArrow:
                        index = index <= 0 ? 0 : index - 1;
                        SetSelectableDataMessage(index);
                        break;
                    case ConsoleKey.DownArrow:
                        index = index >= DataStore.data.Count - 1 ? DataStore.data.Count - 1 : index + 1;
                        SetSelectableDataMessage(index);
                        break;
                    case ConsoleKey.Enter:
                        return MakeDataFromSelectedDataset(index);
                    default:
                        SetSelectableDataMessage(index);
                        break;
                }
            }
        }


        void SetSelectableDataMessage(int index)
        {
            Console.Clear();
            Console.WriteLine(UiMessages.DATASTORE_TITLE);
            var keys = DataStore.data.Keys.ToList();
            for(int i = 0, count = keys.Count ; i < count; i++)
            {
                if(i == index)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"{i + 1}. {keys[i]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        BinomialData MakeDataFromSelectedDataset(int index)
        {
            var keys = DataStore.data.Keys.ToList();
            var data = DataStore.data[keys[index]];

            BinomialData? nullableData = null;
            while(nullableData == null)
            {
                try{
                    nullableData = DataUtil.MakeBinomialData(new InputData
                    (
                        data.roof.ToString(),
                        data.probability.ToString(),
                        GetInput(UiMessages.INPUT[2]))
                    );
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    nullableData = null;
                }
            }
            return nullableData.Value;
        }

        public string SetSelectString(in BinomialData binomialData)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"You selected data{Environment.NewLine}");
            sb.Append($"Trial count     : {binomialData.trialCount}{Environment.NewLine}");
            sb.Append($"Probability     : {binomialData.probability}%{Environment.NewLine}");
            sb.Append($"Success Count   : {binomialData.successCount}");
            return sb.ToString();
        }

        public string SetResultString(in ResultData resultData)
        {
            const string STRING_FORMAT = "0.00000000000000000000000000";
            string resultString = resultData.result.ToString();

            StringBuilder sb = new StringBuilder();
            // Console.WriteLine($"resultString : {resultString}, decimalPoint : {resultData.decimalPoint}");
            if(resultData.decimalPoint >= resultString.Length)
            {
                for(int i = 0; i < resultData.decimalPoint - resultString.Length + 1; i++)
                {
                    sb.Append("0");
                    if(i == 0)
                    {
                        sb.Append(".");
                    }
                }
            }
            else if(resultData.decimalPoint > 0)
            {
                resultString = resultString.Insert(resultString.Length - resultData.decimalPoint, ".");
            }
            
            sb.Append(resultString);
            if(sb.Length > STRING_FORMAT.Length)
                sb.Remove(STRING_FORMAT.Length, sb.Length - STRING_FORMAT.Length);
            sb.Append("%");
            return sb.ToString();
        }
    }
}