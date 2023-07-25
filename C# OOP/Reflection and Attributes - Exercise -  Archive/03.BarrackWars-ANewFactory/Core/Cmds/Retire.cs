namespace _03.BarrackWars_ANewFactory.Core.Cmds
{
    using _03BarracksFactory.Contracts;

    public class Retire : Command
    {
        private IRepository repository;
        public Retire(string[] data, IRepository repository) 
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string unitType = this.Data[1];

            string result = $"{unitType} retired!";

            this.repository.RemoveUnit(unitType);

            return result;
        }
    }
}
