namespace StateDesignPattern.States;

using Models;

public class HomeScreenState : PhoneState
{
    public HomeScreenState(Phone phone) 
        : base(phone) { }

    public override void Lock()
    {
        Console.WriteLine("Phone locked!");
        this._phone.SetState(new LockedState(this._phone));
    }

    public override void Unlock()
    {
        Console.WriteLine("Phone unlocked!");
        this._phone.SetState(new UnlockedState(this._phone));
    }

    public override void GoToHomeScreen()
    {
        Console.WriteLine("The phone is already on the home screen!");
    }
}