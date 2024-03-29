using VisitorDesignPattern.Models;
using VisitorDesignPattern.Visitors;

List<Client> clients = new List<Client>()
{
    new Bank("bank_name", "bank_address", "bank_number", 10),
    new Resident("resident_name", "resident_address", "resident_number", "A"),
    new Company("company_name", "company_address", "company_number", 1000),
    new Restaurant("restaurant_name", "restaurant_address", "restaurant_number", true)
};

InsuranceMessagingVisitor visitor = new InsuranceMessagingVisitor();
visitor.SendInsuranceEmails(clients);