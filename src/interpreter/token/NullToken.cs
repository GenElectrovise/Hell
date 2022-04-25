namespace Hell.src.interpreter.token
{
    internal class NullToken : IToken
    {
        internal NullToken()
        {
        }

        string[] IToken.Resolve(string[] arguments)
        {
            return arguments;
        }

        public override string ToString()
        {
            return "null";
        }
    }
}