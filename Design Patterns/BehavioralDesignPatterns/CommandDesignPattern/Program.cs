using CommandDesignPattern.Commands;
using CommandDesignPattern.Commands.Contracts;
using CommandDesignPattern.Invokers;
using CommandDesignPattern.Receivers;

Receiver receiver = new Receiver();
ICommand simpleCommand = new SimpleCommand("Hello there!");
ICommand complexCommand = new ComplexCommand(receiver, "Refactoring code", "Commiting changes");
Invoker invoker =  new Invoker();
invoker.SetOnStartCommand(simpleCommand);
invoker.SetOnEndCommand(complexCommand);
invoker.DoSomethingImportant();