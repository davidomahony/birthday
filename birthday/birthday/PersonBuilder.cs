using System;

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
        /// </summary>
        /// <param name="outputtedperson"></param>
        /// <returns></returns>
        public bool TryBuild(out Person outputtedperson)
        {
            outputtedperson = null;
            return false;
        }
    }
}
