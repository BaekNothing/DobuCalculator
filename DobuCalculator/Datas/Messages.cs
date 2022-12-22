namespace DobuCalCulator
{
    public static class UiMessages
    {
        public static readonly string TITLE = "Dobu Calculator";

        public static readonly string[] INPUT = new string[]
        {
            "Please enter number of trials.(1 ~ int.MaxValue)",
            "Please enter probability of success.(0 ~ 100(%))",
            "Please enter number of successes.(0 ~ trails)"
        };

        public static readonly string INTRO = 
            "Welcome to Dobu Calculator!" +
            "Please choose the way to input data..";

        public static readonly string[] MENU = new string[]
        {
            "FROM INPUT",
            "FROM DATAS"
        };

        public static readonly string GET_TRAILS =
            "Please enter number of trials.(1 ~ int.MaxValue)";
        public static readonly string GET_PROBABILITY =
            "Please enter probability of success.(0 ~ 100(%))";
        public static string GET_SUCCESSES(string trials)=>
            $"Please enter number of successes.(1 ~ {trials})";


        public static readonly string[] RESULT = new string[]
        {
            "FROM INPUT",
            "FROM DATA"
        };

        public static readonly string DATASTORE_TITLE 
            = "Please Select Data in this Store";
    }

}