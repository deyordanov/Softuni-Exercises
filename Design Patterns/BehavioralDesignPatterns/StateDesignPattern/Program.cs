using StateDesignPattern.Models;
using StateDesignPattern.States;

Phone phone = new Phone();
phone.SetState(new LockedState(phone));
phone.Unlock();
phone.GoToHomeScreen();
phone.Lock();
phone.Unlock();
phone.GoToHomeScreen(); 
phone.Lock(); 