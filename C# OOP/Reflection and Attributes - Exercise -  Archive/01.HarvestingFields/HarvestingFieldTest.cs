namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = Type.GetType("P01_HarvestingFields.HarvestingFields");

            FieldInfo[] fields = type.GetFields((BindingFlags)60);

            string end;
            while ((end = Console.ReadLine()) != "HARVEST")
            {
                string accessModifier = end;

                switch (accessModifier)
                {
                    case "private":
                        Console.WriteLine(PrintFields(f => f.IsPrivate));
                        break;
                    case "protected":
                        Console.WriteLine(PrintFields(f => f.IsFamily));
                        break;
                    case "public":
                        Console.WriteLine(PrintFields(f => f.IsPublic));
                        break;
                    case "all":
                        Console.WriteLine(PrintFields(f => f.IsPrivate || f.IsPublic || f.IsFamily || f.IsStatic));
                        break;
                }

            }

            string PrintFields(Func<FieldInfo, bool> func)
            {
                StringBuilder sb = new StringBuilder();
                foreach (FieldInfo field in fields.Where(func))
                {
                    string modifier = field.IsPrivate ? "private" : field.IsFamily ? "protected" : "public";
                    sb.AppendLine(@$"{modifier} {field.FieldType.Name} {field.Name}");
                }

                return sb.ToString().Trim();
            }
        }
    }
}