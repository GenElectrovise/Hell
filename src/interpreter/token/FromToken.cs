namespace Hell.src.interpreter.token
{
    internal class FromToken : IToken
    {
        public string? Parent { get; set; }

        internal FromToken()
        {
        }

        string[] IToken.Resolve(string[] arguments)
        {
            this.Parent = arguments[0];
            return arguments.Where((content, index) => { return index != 0; }).ToArray();
        }

        public override string ToString()
        {
            return "from " + Parent;
        }
    }
}