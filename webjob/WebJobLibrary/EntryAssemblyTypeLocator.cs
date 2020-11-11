using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace WebJobLibrary
{
    internal class EntryAssemblyTypeLocator : ITypeLocator
    {
        public IReadOnlyList<Type> GetTypes() =>
            Assembly.GetEntryAssembly().GetTypes();
    }
}
