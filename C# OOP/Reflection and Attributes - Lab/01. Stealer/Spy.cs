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
    }
}
