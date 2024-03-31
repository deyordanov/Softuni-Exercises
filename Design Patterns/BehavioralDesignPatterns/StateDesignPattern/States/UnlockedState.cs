namespace StateDesignPattern.States;

using Models;

public class UnlockedState : PhoneState
{
    public UnlockedState(Phone phone) 
        : base(phone) { }

    public override void Lock()
    {
        Console.WriteLine("Phone locked!");
        this._phone.SetState(new LockedState(this._phone));
    }

    public override void Unlock()
    {
        Console.WriteLine("Phone is already unlocked!");
    }

    public override void GoToHomeScreen()
    {
        Console.WriteLine("Going to the home screen!");
        this._phone.SetState(new HomeScreenState(this._phone));
    }
}