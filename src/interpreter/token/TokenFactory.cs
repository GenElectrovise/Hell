using Hell.src.interpreter.token;

namespace Hell.src.interpreter.token
{
    internal class TokenFactory
    {
        public static readonly string ENTRY_PARAGRAPH_NAME = "once-upon-a-time-there-was-a-program";
        public static readonly string PARAGRAPH_START = "\t";

        public static readonly string RUN = "run";

        public static IToken make(string name)
        {
            switch (name.ToLowerInvariant()) {
                case "run":
                    return new RunToken();
                case "from":
                    return new FromToken();
                case "with":
                    return new WithToken();
            }
        }
    }
}
