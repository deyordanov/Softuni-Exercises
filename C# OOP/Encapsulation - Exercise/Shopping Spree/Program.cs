using ShoppingSpree.Models;
string[] peopleInfo = Console.ReadLine().Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);
List<Person> people = new List<Person>();
List<Product> products = new List<Product>();
try
{
    for (int i = 0; i < peopleInfo.Length; i++)
    {
        Person person = new Person(peopleInfo[i], decimal.Parse(peopleInfo[++i]));
        people.Add(person);
    }
    string[] productsInfo = Console.ReadLine().Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);
    for (int i = 0; i < productsInfo.Length; i++)
    {
        Product product = new Product(productsInfo[i], decimal.Parse(productsInfo[++i]));
        products.Add(product);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}
string end;
while((end  = Console.ReadLine()) != "END")
{
    string[] input = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    Person person = people.FirstOrDefault(p => p.Name == input[0]);
    Product product = products.FirstOrDefault(p => p.Name == input[1]);
    if(person != null && product != null)
    {
        Console.WriteLine(person.AddProduct(product));
    }
}
people.ForEach(p => Console.WriteLine(p));