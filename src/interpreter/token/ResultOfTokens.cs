namespace Hell.src.interpreter.token
{
    internal class ResultOfToken : IToken
    {
        public static readonly string RESULT_OF_TOKEN = "the result of";
        public IToken? Target { get; set; }

        internal ResultOfToken()
        {
        }

        string[] IToken.Resolve(string[] arguments)
        {
            this.Target = arguments[0];
            return arguments.Where((content, index) => { return index != 0; }).ToArray();
        }

        public override string ToString()
        {
            return "with " + Target;
        }
    }
}