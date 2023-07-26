namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = input[0];
            string[] commandArgs = input.Skip(1).ToArray();

            var commandType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("No such command exists!");
            }

            ICommand commandInstance = Activator.CreateInstance(commandType) as ICommand;

            string result = commandInstance.Execute(commandArgs);


            return result;
        }
    }
}
