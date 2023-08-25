// See https://aka.ms/new-console-template for more information
using LinkById;

Console.WriteLine("Linking dummy Ids to actual Ids.");

List<Item1> item1List = new List<Item1>(){new Item1(-1), new Item1(-2), new Item1(-3)};
List<Item2> item2List = new List<Item2>(){new Item2(-5), new Item2(-6), new Item2(-7)};

var substituteRefJobForItem1 = new Dictionary<int, int>() { { -1, 111 }, { -2, 22 }, { -3, 33 } };
var substituteIdForItem2 = new Dictionary<int, int>() { { -5, 55 }, { -6, 66 }, { -7, 77 } };
var substituteIdForItem2 = new Dictionary<int, int>() { { -5, 55 }, { -6, 66 }, { -7, 77 } };

var substituteForItem2 = new Dictionary<int, int>() { { -5, 55 }, { -6, 66 }, { -7, 77 } };

Item1.AddLinkedIdList(typeof(Item1), substituteRefJobForItem1);
Item2.AddLinkedIdList(typeof(Item2), substituteIdForItem2);

foreach (var item in item1List)
{
    Console.WriteLine($" -->ILinkedById. Collection {nameof(item1List)}. RefJob = {item.RefJob}. New value = {item.LinkedValue} ");
    Console.WriteLine($" >> ISubstitute. Collection {nameof(item1List)}. RefJob = {item.RefJob}. New value = {item.FindSubstituteValue("RefJob", substituteRefJobForItem1)} ");
}


foreach (var item in item2List)
{
    Console.WriteLine($" -->ILinkedById. Collection {nameof(item2List)}. Id = {item.Id}. New value= {item.LinkedValue} ");
    Console.WriteLine($" >> ISubstitute. Collection {nameof(item1List)}. Id = {item.Id}. New value = {item.FindSubstituteValue("Id", substituteIdForItem2)} ");
}
Item1.CleanLinkedValues();
