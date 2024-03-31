namespace StateDesignPattern.States;

using Models;

public abstract class PhoneState
{
    protected readonly Phone _phone;

    protected PhoneState(Phone phone)
    {
        this._phone = phone;
    }

    public abstract void Lock();
    public abstract void Unlock();
    public abstract void GoToHomeScreen();
}