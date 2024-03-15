namespace Plugin.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class PluginLoader
{
    public static Type[] LoadTypes(string dllPath)
    {
        var asm = Assembly.LoadFrom(dllPath);
        return asm.GetTypes();
    }

    public static T[] Instantiate<T>(IEnumerable<Type> types)
    {
        var tRef = typeof(T);
        var matchingTypes = types.Where(t => tRef.IsAssignableFrom(t))
                                 .Where(t => t.IsClass);

        var instances = matchingTypes.Select(t => (T)(Activator.CreateInstance(t) ?? throw new NullReferenceException($"Could not create a new instance of {t.FullName}"))) // default contructor
                                     .ToArray();

        return instances;
    }

}
