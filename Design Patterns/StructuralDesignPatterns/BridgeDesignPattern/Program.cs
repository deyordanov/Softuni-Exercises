using BridgeDesignPattern.Abstractions;
using BridgeDesignPattern.Implementors;
using BridgeDesignPattern.Implementors.Contracts;

IMessageSender emailSender = new EmailSender();
Message textMessage = new TextMessage(emailSender);
textMessage.Send("Hello, Bridge Pattern!");

IMessageSender smsSender = new SmsSender();
Message encryptedMessage = new EncryptedMessage(smsSender);
encryptedMessage.Send("Hello, Bridge Pattern!");