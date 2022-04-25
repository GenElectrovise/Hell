namespace Hell.src.interpreter.token
{
    internal class RunToken : IToken
    {
        public string? FunctionName { get; set; }
        public IToken? Target { get; set; }

        internal RunToken()
        {
        }

        string[] IToken.Resolve(string[] arguments)
        {
            // If "the result of"
            if (arguments.Length >= 3)
            {
                if (arguments[0].Equals("the") && arguments[1].Equals("result") && arguments[2].Equals("of"))
                {
                    arguments = arguments.Where((content, index) => { return index <= 2; }).ToArray(); // Remove "the result of"
                    TokenFactory.make(ResultOfToken.RESULT_OF_TOKEN).Resolve(arguments);
                }
            }

            // If a paragraph name

            this.FunctionName = arguments[0];
            return arguments.Where((content, index) => { return index != 0; }).ToArray();
        }

        public override string ToString()
        {
            return "run " + FunctionName;
        }
    }
}