using Plugin.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

string dirName = "plugins";
Console.WriteLine("Hello World");

Console.WriteLine("Plugin Demo Application");
Console.WriteLine($"Compile all plugins and put the dll in the `{dirName}` Folder");

if(!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);
var files = Directory.GetFiles(dirName, "*.dll");
if (files.Length == 0)
{
    Console.WriteLine("No plugins in the folder");
    return;
}

Console.WriteLine($"{files.Length} dlls in the folder, loading...");
List<Type> lstTypes = new List<Type>();
foreach (var file in files)
{
    Console.WriteLine($"Loading {file}...");
    var foundTypes = Plugin.Lib.PluginLoader.LoadTypes(file);
    lstTypes.AddRange(foundTypes);
    Console.WriteLine($"{foundTypes.Length} types found in {file}");
}

Console.WriteLine($"Total Types: {lstTypes.Count}");
Console.WriteLine("Creating Operations Instances...");

var operations = Plugin.Lib.PluginLoader.Instantiate<IOperation>(lstTypes);
if (operations.Length == 0)
{
    Console.WriteLine("No operations found");
    return;
}

Console.WriteLine("Choose an operation:");
for (int i = 0; i < operations.Length; i++)
{
    Console.WriteLine($"{i + 1}: {operations[i].Name}");
}
var opt = Console.ReadLine();
if (opt == null)
{
    Console.WriteLine("Invalid Option [1]");
    return;
}
if (!int.TryParse(opt, out int optionNumber))
{
    Console.WriteLine("Invalid Option [2]");
    return;
}
if (optionNumber <= 0 || optionNumber > operations.Length)
{
    Console.WriteLine("Invalid Option [3]");
    return;
}

var operation = operations[optionNumber - 1];
Console.WriteLine($"You choose {operation.Name}");

Random rnd = new Random();
var n1 = rnd.Next(1, 10);
var n2 = rnd.Next(1, 10);

var result = operation.Calculate(n1, n2);
Console.WriteLine($"N1: {n1}; N2: {n2}");
Console.WriteLine($"{n1} <{operation.Name}> {n2} = {result}");

Console.WriteLine("End");
