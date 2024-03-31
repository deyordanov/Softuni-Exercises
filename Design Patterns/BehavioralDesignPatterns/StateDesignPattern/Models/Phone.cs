namespace StateDesignPattern.Models;

using States;

public class Phone
{
    private PhoneState _phoneState;

    public void SetState(PhoneState state)
    {
        this._phoneState = state;
    }

    public void Lock()
    {
        this._phoneState.Lock();
    }

    public void Unlock()
    {
        this._phoneState.Unlock();
    }

    public void GoToHomeScreen()
    {
        this._phoneState.GoToHomeScreen();
    }
}