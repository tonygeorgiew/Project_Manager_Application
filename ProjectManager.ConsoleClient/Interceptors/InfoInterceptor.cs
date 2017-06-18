using Bytes2you.Validation;
using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class InfoInterceptor : SimpleInterceptor
    {
        private readonly IWriter writer;

        public InfoInterceptor(IWriter writer)
        {
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.writer = writer;
        }
        protected override void AfterInvoke(IInvocation invocation)
        {
            this.writer.WriteLine($"{invocation.ReturnValue}");
        }
    }
}
