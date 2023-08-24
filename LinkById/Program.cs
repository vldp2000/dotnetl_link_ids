﻿// See https://aka.ms/new-console-template for more information
using LinkById;

Console.WriteLine("Linking dummy Ids to actual Ids.");

List<Item1> item1Collection = new List<Item1>()
{
    new Item1(1), new Item1(2), new Item1(3)
};

List<Item2> item2Collection = new List<Item2>()
{
    new Item2(5), new Item2(6), new Item2(7)
};

if (item1Collection.Count > 0)
    item1Collection[0].LinkedIds = new Dictionary<int, int>()
    {
        {1,111}, {2,22}, {4,33 }
    };

if (item2Collection.Count > 0)
    item2Collection[0].LinkedIds = new Dictionary<int, int>()
{
    {5,55}, {6,66}, {8,77 }
};

foreach (var item in item1Collection)
{
    Console.WriteLine($"collection {nameof(item1Collection)}. Id = {item.Id}. Linked Id = {item.LinkedId} ");
}

foreach (var item in item2Collection)
{
    Console.WriteLine($"collection {nameof(item2Collection)}. Id = {item.Id}. Linked Id = {item.LinkedId} ");
}