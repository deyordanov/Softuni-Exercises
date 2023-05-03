using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factory;
using Raiding.Factory.Interfaces;
using Raiding.IO;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IFactory factory = new Factory();
IEngine engine = new Engine(reader, writer, factory);
engine.Run();