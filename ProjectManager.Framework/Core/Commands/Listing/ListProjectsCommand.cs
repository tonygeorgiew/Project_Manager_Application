using System;
using System.Collections.Generic;

using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.Framework.Core.Commands.Listing
{
    public sealed class ListProjectsCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 0;

        public ListProjectsCommand(IDatabase database)
            : base(database)
        {
        }

        public override int ParameterCount
        {
            get
            {
                return ParameterCountConstant;
            }
        }

        public override string Execute(IList<string> parameters)
        {
            var projectId = int.Parse(parameters[0]);
            if (this.Database.Projects.Count <= projectId || projectId < 0)
            {
                throw new UserValidationException("The project is not present in the database");
            }

            var project = this.Database.Projects[projectId];

            return project.ToString();
        }
    }
}
