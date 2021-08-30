using System;

namespace Birthday
{
    public class TestInputs
    {
        public static string ProvidedInput = @" 
            [
	            [""Doe"", ""John"", ""1982/10/08""],
	            [""Wayne"", ""Bruce"", ""1965/01/30""],
	            [""Gaga"", ""Lady"", ""1986/03/28""]
            ]
            ";

        public static string ProvidedInputWithBirthdayToday = @" 
            [
	            [""Doe"", ""John"", """ + DateTime.Today.Date + @"""],
	            [""Wayne"", ""Bruce"", ""1965/01/30""],
	            [""Gaga"", ""Lady"", ""1986/03/28""]
            ]
            ";

        public static string ProvidedInputWithPersonWithThreeNames = @" 
            [
	            [""Doe"", ""Joe"", ""John"", """ + DateTime.Today.Date + @"""]
            ]
            ";

        public static string ProvidedInputWithOneDateInDifferentFormat = @" 
            [
	            [""Doe"", ""Joe"", ""John"", """ + DateTime.Today.Date + @"""],
	            [""Gaga"", ""Lady"", ""1986/28/02""]
            ]
            ";
    }
}
