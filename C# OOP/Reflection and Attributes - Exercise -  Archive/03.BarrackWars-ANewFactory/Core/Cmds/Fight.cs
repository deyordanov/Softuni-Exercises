namespace _03.BarrackWars_ANewFactory.Core.Cmds
{
    using System;
    using _03BarracksFactory.Contracts;

    public class Fight : Command
    {
        private const int DefaultExitCode = 0;
        public Fight(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(DefaultExitCode);

            return null;
        }
    }
}
