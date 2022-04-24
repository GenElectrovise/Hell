namespace Hell.src.interpreter.token
{
    internal class FromToken : IToken
    {
        public string[] Parents { get; set; }

        string[] IToken.Resolve(string[] arguments)
        {

            int[] indicesToRemove = { };

            // The first argument will always be a method name (e.g. run hello from *world from universe*), where ** is the input to this function
            Parents.Append(arguments[0]);
            return arguments.Where((content, index) => { return index != 0; }).ToArray(); // Return all but index 0

            do
            {

            } while (HasNextFor(arguments));

            while (arguments[0] != null || arguments[0].Equals("from"))
            {

            }

            if (arguments[0].Equals("from"))
            {
                arguments = RemoveNextFrom(arguments);
                Parents.Append(arguments[0]);
                return arguments.Where((content, index) => { return index != 0; }).ToArray(); // Return all but index 0
            }

            // For each argument
            for (int i = 1; i < arguments.Length; i++)
            {
                // If the given argument is FROM
                string argument = arguments[i];
                if (argument.Equals("from")) 
                {
                    // Need to remove index i later
                    indicesToRemove.Append(i);

                    if (arguments[i + 1] != null) 
                    {
                        // Need to remove index i+1 later
                        indicesToRemove.Append(i + 1);

                        string parentName = arguments[i + 1];
                        this.Parents.Append(parentName);
                    } 
                    else // Ignore the from 
                    {
                        Hell.Debug("No target for from!! (parse failed, ignoring)");
                        Hell.Info("Where is that from thingy telling me to go? Eh, it'll be fine...");
                        continue;
                    }
                }
            }

            // Remove all indices of used terms from the remaining arguments on the line.
            return arguments.Where((content, index) => { return indicesToRemove.Contains(index); }).ToArray();
        }

        private bool HasNextFor(string[] arguments)
        {
            if (arguments.Length < 1)
            {
                return false;
            }
            if (!arguments[0].Equals("from"))
            {
                return false;
            }

            return true;
        }

        private string[] RemoveNextFrom(string[] arguments)
        {
            if(arguments[0] == "from")
            {
                return arguments.Where((content, index) => { return index != 0; }).ToArray(); // Return all but index 0
            }

            return arguments;
        }

        private void ParseNameAndReduce(string name)
        {

        }

        public override string ToString()
        {
            return "from " + ParentName;
        }
    }
}