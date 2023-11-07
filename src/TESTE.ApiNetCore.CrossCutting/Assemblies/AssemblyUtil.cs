using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TESTE.ApiNetCore.CrossCutting.Assemblies
{
    [ExcludeFromCodeCoverage]
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {            
            return new Assembly[]
            {
                Assembly.Load("TESTE.ApiNetCore.Api"),
                Assembly.Load("TESTE.ApiNetCore.Application"),
                Assembly.Load("TESTE.ApiNetCore.Domain"),
                Assembly.Load("TESTE.ApiNetCore.Domain.Core"),
                Assembly.Load("TESTE.ApiNetCore.Infrastructure"),
                Assembly.Load("TESTE.ApiNetCore.CrossCutting")
            };
        }
    }
}
