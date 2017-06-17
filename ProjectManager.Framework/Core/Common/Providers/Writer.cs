using ProjectManager.Framework.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Framework.Core.Common.Providers
{
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
