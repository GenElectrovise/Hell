namespace Hell.src.interpreter.token
{
    internal class WithToken : IToken
    {
        public string? ParamName { get; set; }

        internal WithToken()
        {
        }

        string[] IToken.Resolve(string[] arguments)
        {
            this.ParamName = arguments[0];
            return arguments.Where((content, index) => { return index != 0; }).ToArray();
        }

        public override string ToString()
        {
            return "with " + ParamName;
        }
    }
}