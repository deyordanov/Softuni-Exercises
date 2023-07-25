namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");

            var instance = Activator.CreateInstance(type, true);

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            string end;
            while ((end = Console.ReadLine()) != "END")
            {
                string[] commandArgs = end.Split("_");
                string command = commandArgs[0];
                int number = int.Parse(commandArgs[1]);

                InvokeMethod(command, number);
            }



            void InvokeMethod(string methodName, int number)
            {
                foreach (MethodInfo method in methods.Where(m => m.Name == methodName))
                {
                    method.Invoke(instance, new object[] { number });
                }

                FieldInfo field = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                Console.WriteLine(field.GetValue(instance));
            }
        }
    }
}