using Serialization.Models;
using Serialization.Serializers;

Person originalPerson = new Person()
{
    Name = "Denis",
    Age = 20,
    Address = new Address()
    {
        Street = "324",
        City = "Pernik",
        Country = "Bulgaria",
    }
};

Person xmlDeepCopy = XML.DeepCopyXML(originalPerson);

Person jsonDeepCopy = JSON.DeepCopyJSON(originalPerson);

Person dataContractDeepCopy = DataContract.DeepCopyDataContract(originalPerson);

Person reflectionDeepCopy = Reflection.DeepCopyReflection(originalPerson);

Person expressionTreeDeepCopy = ExpressionTree.DeepCopyExpressionTrees<Person>(originalPerson);

Person fastDeepClonerCopy = Serialization.Serializers.FastDeepCloner.DeepCopyFastDeepCloner(originalPerson);