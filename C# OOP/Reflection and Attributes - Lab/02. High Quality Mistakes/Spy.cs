namespace Stealer
{
    using System.Reflection;
    using System.Text;
    using Contracts;

    public class Spy : ISpy
    {
        public string StealFieldInfo(string nameOfClass, params string[] fieldsToInvestigate)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(nameOfClass);

            sb.AppendLine($"Class under investigation: {type.FullName}");

            FieldInfo[] fields = type.GetFields((BindingFlags)60);

            Object classInstance = Activator.CreateInstance(type, new object[] { } );

            foreach (FieldInfo field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string nameOfClass)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(nameOfClass);

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            
            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo getter in privateMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getter.Name} have to be public!");
            }

            foreach (MethodInfo setter in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setter.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }
    }
}
