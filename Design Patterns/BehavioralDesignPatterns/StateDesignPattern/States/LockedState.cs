namespace StateDesignPattern.States;

using Models;

public class LockedState : PhoneState
{
    public LockedState(Phone phone) 
        : base(phone) { }

    public override void Lock()
    {
        Console.WriteLine("Phone is already locked!");
    }

    public override void Unlock()
    {
        Console.WriteLine("Phone unlocked!");
        this._phone.SetState(new UnlockedState(this._phone));
    }

    public override void GoToHomeScreen()
    {
        Console.WriteLine("Going to the home screen!");
        this._phone.SetState(new HomeScreenState(this._phone));
    }
}