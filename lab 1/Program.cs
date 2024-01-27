using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public int personId;
    public string firstName;
    public string lastName;
    public string favoriteColour;
    public int age;
    public bool isWorking;

    public void DisplayPersonInfo()
    {
        Console.WriteLine($"{personId}: {firstName} {lastName}'s favorite colour is {favoriteColour}");
    }

    public void ChangeFavoriteColour()
    {
        favoriteColour = "White";
    }

    public int GetAgeInTenYears()
    {
        return age + 10;
    }

    public override string ToString()
    {
        return $"{personId}: {firstName} {lastName}\nPersonId: {personId}\nFirstName: {firstName}\nLastName: {lastName}\nFavoriteColour: {favoriteColour}\nAge: {age}\nIsWorking: {isWorking}";
    }
}

class Relation
{
    public enum RelationshipType { Sister, Brother, Mother, Father }
    public RelationshipType relationshipType;

    public void ShowRelationShip(Person person1, Person person2)
    {
        Console.WriteLine($"Relationship between {person1.firstName} and {person2.firstName} is: {relationshipType}hood");
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        List<Person> peopleList = new List<Person>();

        Person ian = new Person { personId = 1, firstName = "Ian", lastName = "Brooks", favoriteColour = "Red", age = 30, isWorking = true };
        Person gina = new Person { personId = 2, firstName = "Gina", lastName = "James", favoriteColour = "Green", age = 18, isWorking = false };
        Person mike = new Person { personId = 3, firstName = "Mike", lastName = "Briscoe", favoriteColour = "Blue", age = 45, isWorking = true };
        Person mary = new Person { personId = 4, firstName = "Mary", lastName = "Beals", favoriteColour = "Yellow", age = 28, isWorking = true };

        peopleList.Add(ian);
        peopleList.Add(gina);
        peopleList.Add(mike);
        peopleList.Add(mary);

        Console.WriteLine($"2: {gina.firstName} {gina.lastName}'s favorite colour is {gina.favoriteColour}");
        Console.WriteLine($"{mike}");
        ian.ChangeFavoriteColour();
        Console.WriteLine($"1: {ian.firstName} {ian.lastName}'s favorite colour is: {ian.favoriteColour}");
        Console.WriteLine($"{mary.firstName} {mary.lastName}'s Age in 10 years is: {mary.GetAgeInTenYears()}");

        Relation ginaMaryRelation = new Relation { relationshipType = Relation.RelationshipType.Sister };
        ginaMaryRelation.ShowRelationShip(gina, mary);

        Relation ianMikeRelation = new Relation { relationshipType = Relation.RelationshipType.Brother };
        ianMikeRelation.ShowRelationShip(ian, mike);

        int totalAge = peopleList.Sum(person => person.age);
        double averageAge = (double)totalAge / peopleList.Count;

        Person youngestPerson = peopleList.OrderBy(person => person.age).First();
        Person oldestPerson = peopleList.OrderByDescending(person => person.age).First();

        Console.WriteLine($"Average age is: {averageAge}");
        Console.WriteLine($"The youngest person is: {youngestPerson.firstName}");
        Console.WriteLine($"The oldest person is: {oldestPerson.firstName}");

        foreach (var person in peopleList.Where(person => person.firstName.StartsWith("M")))
        {
            Console.WriteLine($"{person}");
        }

        foreach (var person in peopleList.Where(person => person.favoriteColour.Equals("Blue", StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"{person}");
        }
    }
}
