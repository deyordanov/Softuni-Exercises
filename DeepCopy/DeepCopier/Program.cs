using DeepCopy.Core;
using DeepCopy.Core.Contracts;
using DeepCopy.IO;
using DeepCopy.IO.Contracts;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();

IEngine engine = new Engine(reader, writer);
engine.Run();