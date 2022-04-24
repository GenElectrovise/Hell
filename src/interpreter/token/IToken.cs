using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.src.interpreter.token
{
    internal interface IToken
    {
        /// <summary>
        /// Takes the remaining items as an array and reduces that array (look up reduce function on an array). E.g. a RUN token will get the first element of the array (the name of the function to run) and store it, then remove that element from the array.
        /// </summary>
        /// <param name="arguments">The remaining space-seperated items on the line</param>
        /// <returns></returns>
        string[] Resolve(string[] arguments);
    }
}
