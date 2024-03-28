using BuilderDesignPattern;
using BuilderDesignPattern.Builders;
using BuilderDesignPattern.Builders.Contracts;

Director director = new Director();

CarBuilder carBuilder = new CarBuilder();
director.BuildBmw(carBuilder);
carBuilder.Build();
Console.WriteLine(carBuilder.Build());

Console.WriteLine("<=============================>");

CarSchemaBuilder carSchemaBuilder = new CarSchemaBuilder();
director.BuildMercedes(carSchemaBuilder);
carSchemaBuilder
    .Color("Black")
    .Engine("6.3L")
    .Horsepower("550");
Console.WriteLine(carSchemaBuilder.Build());