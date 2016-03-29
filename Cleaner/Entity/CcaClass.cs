using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Utils;

namespace Cleaner.Entity
{
    public class LocationInfo
    {
        public string Directory { get; }
        public string File { get; }

        public LocationInfo(string directory, string file)
        {
            Directory = directory;
            File = file;
        }
    }
    public class CcaClass
    {
        public LocationInfo Location { get; private set; }
        public string Namespace { get; set; }
        public ClassHeader Header { get; }
        public List<ClassVariable> Variables { get; set; }
        public List<CcaProperty> Properties { get; set; }
        public List<CcaMethod> Methods { get; set; }

        public CcaClass(LocationInfo location, ClassHeader header)
        {
            Location = location;
            Header = header;
        }

        public CcaClass(string directory, string file, ClassHeader header)
            : this(new LocationInfo(directory, file), header)
        {
            
        }

        public CcaClass()
        {
            
        }

        public override string ToString()
        {
            return $"{Namespace}.{Header}";
        }

        public string ToFullString()
        {
            return $"{Namespace} {Header.ToFullString()}";
        }
    }

    public class ClassHeader : IClassElement
    {
        public AccessModifiers AccessModifier { get; set; }
        public string Name { get; set; }
        public List<ClassModifiers> ClassModifiers { get; set; }
        public bool? IsStatic => ClassModifiers.Any(x => x.Equals(Entity.ClassModifiers.Static));
        public bool IsAbstract => ClassModifiers.Any(x => x.Equals(Entity.ClassModifiers.Abstract));
        public List<string> BaseClasses { get; private set; }
        public string Content { get; set; }

        public ClassHeader(AccessModifiers accessModifier, string name, List<ClassModifiers> classModifiers, List<string> baseClasses)
        {
            AccessModifier = accessModifier;
            Name = name;
            ClassModifiers = classModifiers;
            BaseClasses = baseClasses;
        }

        public ClassHeader(AccessModifiers accessModifier, string name)
            : this(accessModifier, name, new List<ClassModifiers>(), new List<string>())
        {
            AccessModifier = accessModifier;
            Name = name;
        }

        public ClassHeader(AccessModifiers accessModifier, string name, List<ClassModifiers> classModifiers)
            : this(accessModifier, name, classModifiers, new List<string>())
        {
        }

        public ClassHeader()
        {
            //todo: odstranit
        }

        public override string ToString()
        {
            return Name;
        }

        public string ToFullString()
        {
            return $"{AccessModifier} {ClassModifiers.Join()} {Name} : {BaseClasses.Join()}";
        }
    }
}
