using System.Reflection;

namespace Hell
{
    /// <summary>
    /// Global configuration for the running Hell Compiler and Interpreter.
    /// </summary>
    public class RunContext
    {
        public string[] Args { get; } = new string[0];
        public string S_ProgramPath { get; set; } = "no_path";
        
        // UseDebug (abstracts boolean to a string so 
        private string _useDebug = "true";
        public bool B_UseDebug
        {
            get { return Boolean.Parse(_useDebug); }
            set { _useDebug = value.ToString(); }
        }

        // UseTrace
        private string _useTrace = "true";
        public bool B_UseTrace
        {
            get { return Boolean.Parse(_useTrace); }
            set { _useTrace = value.ToString(); }
        }

        public RunContext(string[] args)
        {
            this.Args = (args == null ? new string[0] : args);
            SetFromArgs();
        }

        /// <summary>
        /// Arguments are formatted: "T_key1 value1 T_key2 value2", where T specifies the type of the argument to come (I Int64, B Boolean, S String)
        /// </summary>
        private void SetFromArgs()
        {
            // Default values
            S_ProgramPath = "example.hell";
            B_UseDebug = true;

            Hell.Debug("Setting RunContext args from input");

            // For each input 
            for (int i = 0; i < Args.Length; i++)
            {
                Hell.Debug(" > Testing " + Args[i]);
                
                // If the given argument is a valid argument
                if(Hell.ALLOWED_ARGUMENTS.Contains(Args[i]))
                {
                    Hell.Debug(" > > Found valid argument key " + Args[i]);
                    try
                    {
                        // This is funky reflection stuff because this was the first way I thought to do this.
                        // Get the type of this object (a RunContext)
                        Type type = this.GetType();

                        // Get a property of this object with the given name (i.e. Entering "ProgramPath" should return the property ProgramPath)
                        PropertyInfo property = type.GetProperty(Args[i]);
                        if (property == null)
                        {
                            throw new NullReferenceException("The argument " + Args[i] + " does not map to a value within RunContext");
                        }

                        // Set the value of the property to the 'i + 1' element, which should be its value
                        SetKeyAndValue(property, Args[i], (Args[i + 1] == null ? null : Args[i + 1]));
                    } catch (Exception ex)
                    {
                        Hell.Info("Ah these gosh darned wordy things!! I don't know what this one means! Oh well...");
                        Hell.Debug("Error occured while loading argument " + Args[i]);
                        Hell.Debug(ex.Message);
                        Hell.Debug(ex.Source);
                        Hell.Debug(ex.ToString());
                    }
                } else
                {
                    Hell.Debug(" > > Discarding invalid argument key " + Args[i]);
                }
            }
        }

        private void SetKeyAndValue(PropertyInfo? property, string key, string value)
        {
            Object? castValue = null;
            String startChars = key.Substring(0, 2);
            if (startChars.Equals("I_"))
            {
                castValue = Int64.Parse(key.Substring(2));
                Hell.Trace(" > > > " + key + " is Int64" + castValue);
            }
            else if (startChars.Equals("B_"))
            {
                castValue = Boolean.Parse(key.Substring(2));
                Hell.Trace(" > > > " + key + " is Boolean" + castValue);
            } 
            else if (startChars.Equals("S_"))
            {
                castValue = value;
                Hell.Trace(" > > > " + key + " is String " + castValue);
            } else
            {
                Hell.Debug(" > > > " + key + " has no type");
            }

            // Console.WriteLine(this);
            // Console.WriteLine(castValue);
            // Console.WriteLine("" + null);

            property.SetValue(this, castValue, null);

            Hell.Debug(" > > > Value of " + key + " set to " + castValue + " : Proof is " + property.GetValue(this));
        }
    }
}
