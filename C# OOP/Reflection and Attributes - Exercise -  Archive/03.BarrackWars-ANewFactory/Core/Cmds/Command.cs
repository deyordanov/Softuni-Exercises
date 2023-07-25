namespace _03.BarrackWars_ANewFactory.Core.Cmds
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get; private set; }
        public abstract string Execute();
    }
}
