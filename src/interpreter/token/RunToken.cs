namespace Hell.src.interpreter.token
{
    internal class RunToken : IToken
    {
        public string FunctionName { get; set; }

        string[] IToken.Resolve(string[] arguments)
        {
            this.FunctionName = arguments[0];
            return arguments.Where((content, index) => { return index != 0; }).ToArray();
        }

        public override string ToString()
        {
            return "run " + FunctionName;
        }
    }
}