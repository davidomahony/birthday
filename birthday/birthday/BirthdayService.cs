using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday
{
    public class BirthdayService
    {
        // ideally this would be an interace IBUilder
        private PersonBuilder builder = new PersonBuilder();

        /// <summary>
        /// Input is a json string and output is a list of people
        /// </summary>
        public IEnumerable<string> IdentifySameBirthdays(string inputtedJsonString)
        {
            if (string.IsNullOrEmpty(inputtedJsonString))
            {
                return Enumerable.Empty<string>();
            }

            bool successParsing = this.TryParseJson(inputtedJsonString, out List<string[]> parsedJson);
            if (!successParsing)
            {
                return Enumerable.Empty<string>();
            }

            List<Person> peopleWithBirthdayToday = new List<Person>();
            parsedJson.ForEach(p =>
            {
                this.builder.SetPersonInputs(p);
                if (this.builder.TryBuild(out Person createdPerson)
                    && createdPerson.Birthday.Month.Equals(DateTime.Today.Month)
                    && createdPerson.Birthday.Day.Equals(DateTime.Today.Day))
                {
                    peopleWithBirthdayToday.Add(createdPerson);
                }
            });

            return peopleWithBirthdayToday.Count == 0 ?
                Enumerable.Empty<string>() :
                peopleWithBirthdayToday.Select(p => string.Join(" ", p.Names));
        }

        private bool TryParseJson(string inputtedString, out List<string[]> parsedInput)
        {
            parsedInput = null;

            try
            {
                parsedInput = JsonConvert.DeserializeObject<List<string[]>>(inputtedString);
                if (parsedInput?.Any() != true)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
