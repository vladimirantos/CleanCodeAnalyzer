using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Utils;

namespace Cleaner.Entity
{
    public enum AccessModifiers
    {
        None, Public, Protected, Internal, Private
    }

    public enum ClassModifiers
    {
        None, Abstract, Sealed, Static, Internal
    }

    public enum PropertyModifiers
    {
        None, Virtual, Static, New, Override, Abstract, Sealed, Unsafe, Internal, Protected
    }

    public enum FieldModifiers
    {
        None, Static, Readonly, Const, Event, New, Volatile, Internal
    }

    public enum MethodModifiers
    {
        None, Abstract, Virtual, Sealed, Async, Extern, Override, Static, Unsafe, Internal
    }

    /// <summary>
    /// Společné rozhraní všech prvků v C#. Zahrnuje třídy, metody, property i proměnné.
    /// </summary>
    public interface IElement
    {
        string Name { get; set; }
    }

    public interface IVariable : IElement
    {
         string DataType { get; set; }
    }

    /// <summary>
    /// Rozhraní pro všechny prvky ve třídě.
    /// </summary>
    interface IClassElement : IElement
    {
        AccessModifiers AccessModifier { get; set; }
        bool? IsStatic { get; }
    }
}
