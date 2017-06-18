using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Factories;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers;
using System;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";


        private IProcessor processor;
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer, IProcessor processor)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(processor, "processor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.processor = processor;
        }

        public void Start()
        {
            for (;;)
            {
                var commandLine = reader.ReadLine();

                if (commandLine.ToLower() == TerminationCommand)
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.ProcessCommand(commandLine);
                    writer.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message.ToString());
                }
            }
        }
    }
}
