using PizzaCalories;
using PizzaCalories.Items;
try
{
    string[] pizzaDetails = Console.ReadLine().Split(" ").Skip(1).ToArray();
    Pizza pizza = new Pizza(pizzaDetails[0]);
    string[] doughDetails = Console.ReadLine().Split(" ").Skip(1).ToArray();
    char[] type = doughDetails[0].ToLower().ToCharArray();
    char[] technique = doughDetails[1].ToLower().ToCharArray();
    type[0] = char.ToUpper(type[0]);
    technique[0] = char.ToUpper(technique[0]);
    pizza.AddDough(new Dough(new string(type), new string(technique), double.Parse(doughDetails[2])));
    string end;
    while ((end = Console.ReadLine()) != "END")
    {
        string[] input = end.Split(" ").Skip(1).ToArray();
        char[] typeOfTopping = input[0].ToLower().ToCharArray();
        typeOfTopping[0] = char.ToUpper(typeOfTopping[0]);
        Topping topping = new Topping(new string(typeOfTopping), double.Parse(input[1]));
        pizza.AddToppings(topping);
    }
    Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

