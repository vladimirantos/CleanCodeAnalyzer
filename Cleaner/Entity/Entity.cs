using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    enum AccessModifiers
    {
        Public, Protected, Internal, Private
    }

    enum ClassModifiers
    {
        Abstract, Sealed, Internal, Private, Public
    }

    enum MethodModifiers
    {
        Abstract, Virtual, Sealed, Async, Extern, Override, Static
    }

    /// <summary>
    /// Společné rozhraní všech prvků v C#. Zahrnuje třídy, metody, property i proměnné.
    /// </summary>
    interface IElement
    {
        string Name { get; set; }
    }

    interface IVariable : IElement
    {
         string DataType { get; set; }
    }

    /// <summary>
    /// Rozhraní pro všechny prvky ve třídě.
    /// </summary>
    interface IClassElement : IElement
    {
        AccessModifiers AccessModifier { get; set; }
        bool IsStatic { get; }
    }
}
