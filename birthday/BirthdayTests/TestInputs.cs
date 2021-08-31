using System;

namespace Birthday
{
    public class TestInputs
    {
        public static string ProvidedInput = @" 
            [
	            [""Doe"", ""John"", """ + DateTime.Today.Date.AddDays(3).AddYears(-1) + @"""],
	            [""Wayne"", ""Bruce"", """ + DateTime.Today.Date.AddDays(2).AddYears(-1) + @"""],
	            [""Gaga"", ""Lady"", """ + DateTime.Today.Date.AddDays(1).AddYears(-1) + @"""]
            ]
            ";

        public static string ProvidedInputWithBirthdayToday = @" 
            [
	            [""Doe"", ""John"", """ + DateTime.Today.Date.AddYears(-1) + @"""],
	            [""Wayne"", ""Bruce"", ""1965/01/30""],
	            [""Gaga"", ""Lady"", ""1986/03/28""]
            ]
            ";

        public static string ProvidedInputWithPersonWithThreeNames = @" 
            [
	            [""Doe"", ""Joe"", ""John"", """ + DateTime.Today.Date.AddYears(-1) + @"""]
            ]
            ";

        public static string ProvidedInputWithOneDateInDifferentFormat = @" 
            [
	            [""Doe"", ""Joe"", ""John"", """ + DateTime.Today.Date.AddYears(-1) + @"""],
	            [""Gaga"", ""Lady"", ""1986/28/02""]
            ]
            ";

        public static string ProvidedInputWithBirthdayInTheFuture = @" 
            [
	            [""Doe"", ""Joe"", ""John"", """ + DateTime.Today.Date.AddYears(5) + @"""],
	            [""Gaga"", ""Lady"", ""1986/28/02""]
            ]
            ";
    }
}
