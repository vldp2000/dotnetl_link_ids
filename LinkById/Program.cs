// See https://aka.ms/new-console-template for more information
using JWTTestWebApi.Services.ServiceHelper;
using LinkById;

Console.WriteLine("Linking dummy Ids to actual Ids.");

List<Item1> item1List = new List<Item1>(){new Item1(-1), new Item1(-2), new Item1(-3)};
List<Item2> item2List = new List<Item2>(){new Item2(-5, "Code-5"), new Item2(-6, "Code-6"), new Item2(-7,"Code-7") };

Dictionary<int, int> substituteRefJobForItem1 = new Dictionary<int, int>();
substituteRefJobForItem1.Add(-1, 111);
substituteRefJobForItem1.Add(-2, 22);
substituteRefJobForItem1.Add(-3, 33);

Dictionary<int, int> substituteIdForItem2 = new Dictionary<int, int>() { { -5, 55 }, { -6, 66 }, { -7, 77 } };


Item1.AddLinkedIdList(typeof(Item1), substituteRefJobForItem1);
Item2.AddLinkedIdList(typeof(Item2), substituteIdForItem2);

if (substituteRefJobForItem1 != null)
    foreach (var item in item1List) 
    {
        Console.WriteLine($" -->ILinkedById. Collection {nameof(item1List)}. RefJob = {item.RefJob}. New value = {item.LinkedValue} ");
        Console.WriteLine($" >> ISubstitute. Collection {nameof(item1List)}. RefJob = {item.RefJob}. New value = {item.FindSubstituteValue("RefJob", substituteRefJobForItem1)} ");
        int? refjob = ObjectPropertyFromDictionarySubstituter.SubstituteIntPropertyValueUsingProvidedDictionary(obj: item, propertyName: "RefJob", dict: substituteRefJobForItem1);
        Console.WriteLine($" - Substituter. Collection {nameof(item1List)}. RefJob = {item.RefJob}.  Substitute value-> {refjob}");
    }


foreach (var item in item2List)
{
    Console.WriteLine($" -->ILinkedById. Collection {nameof(item2List)}. Id = {item.Id}. New value= {item.LinkedValue} ");
    Console.WriteLine($" >> ISubstitute. Collection {nameof(item1List)}. Id = {item.Id}. New value = {item.FindSubstituteValue("Id", substituteIdForItem2)} ");
    int? id = ObjectPropertyFromDictionarySubstituter.SubstituteIntPropertyValueUsingProvidedDictionary(obj: item, propertyName: "Id", dict: substituteIdForItem2);
    Console.WriteLine($" - Substituter. {nameof(item1List)}. Id = {item.Id}.  Substitute value-> {id}");
}
Item1.CleanLinkedValues();
