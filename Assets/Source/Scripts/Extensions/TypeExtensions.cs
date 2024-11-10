using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetDerivedTypes(this Type baseType)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(type => type.IsSubclassOf(baseType));
        }
    }
}