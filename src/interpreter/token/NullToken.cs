namespace Hell.src.interpreter.token
{
    internal class NullToken : IToken
    {
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