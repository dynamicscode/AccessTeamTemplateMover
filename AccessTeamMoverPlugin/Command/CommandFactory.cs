﻿using AccessTeamMoverPlugin.Common;

namespace AccessTeamMoverPlugin.Command
{
    internal class CommandFactory
    {
        public static ICommand GetInstance(Operation operation)
        {
            ICommand command;

            switch (operation)
            {
                case Operation.Import:
                    command = new ImportCommand();
                    break;
                case Operation.Export:
                default:
                    command = new ExportCommand();
                    break;
            }
            return command;
        }
    }
}
