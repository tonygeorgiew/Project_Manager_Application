using ProjectManager.Framework.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Framework.Core.Common.Providers
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
