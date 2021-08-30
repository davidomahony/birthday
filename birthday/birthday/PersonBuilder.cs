using System;
using System.Linq;

namespace Birthday
{
    public class PersonBuilder
    {
        private string[] inputs;

        public void SetPersonInputs(string[] inputs)
        {
            this.inputs = inputs;
        }

        /// <summary>
        /// As the input is a string array we dont know how many names a person could have
        /// SO a valid person will have a list of names (which should not contain letters) and only one date.
        /// Also if an entry contains two dates its not a valid person
        /// </summary>
        /// <param name="outputtedperson"></param>
        /// <returns></returns>
        public bool TryBuild(out Person outputtedperson)
        {
            outputtedperson = new Person();
            bool foundBirthday = false;

            if (this.inputs == null || this.inputs.Length < 2)
            {
                return false;
            }

            foreach (string input in inputs)
            {
                if (DateTime.TryParse(input, out DateTime date))
                {
                    // two birthdays not a valid person
                    if (foundBirthday)
                    {
                        return false;
                    }

                    outputtedperson.Birthday = date.Date;
                    foundBirthday = true;
                }
                else
                {
                    if (input.All(char.IsLetter))
                    {
                        outputtedperson.Names.Add(input);
                    }
                }
            }

            // inputted name "Doe" "John" should be diplayed "John Doe"
            // therefore it makes sense to reverse the names
            outputtedperson.Names.Reverse();

            return outputtedperson.Names.Count > 1 && foundBirthday;
        }
    }
}
