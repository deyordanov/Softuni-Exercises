namespace _03.BarrackWars_ANewFactory.Core.Cmds
{
    using _03BarracksFactory.Contracts;

    public class Report: Command
    {
        private IRepository repository;
        public Report(string[] data, IRepository repository) : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
            => this.repository.Statistics;
    }
}
