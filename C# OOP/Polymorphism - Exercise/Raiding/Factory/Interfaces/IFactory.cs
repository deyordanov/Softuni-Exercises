namespace Raiding.Factory.Interfaces
{
    using Models.Interfaces;
    public interface IFactory
    {
        IBaseHero CreateHero(string type, string name);
    }
}
