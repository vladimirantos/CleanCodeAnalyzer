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
        public List<ClassMember> Members { get; }
        public List<CcaMethod> Methods { get; }

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
    }

    public class ClassHeader : IClassElement
    {
        public AccessModifiers AccessModifier { get; set; }
        public string Name { get; set; }
        public List<ClassModifiers> ClassModifiers { get; set; }
        public bool IsStatic => ClassModifiers.Any(x => x.Equals(Entity.ClassModifiers.Static));
        public bool IsAbstract => ClassModifiers.Any(x => x.Equals(Entity.ClassModifiers.Abstract));
        public List<string> HeredityClasses { get; private set; }

        public ClassHeader(AccessModifiers accessModifier, string name, List<ClassModifiers> classModifiers, List<string> heredityClasses)
        {
            AccessModifier = accessModifier;
            Name = name;
            ClassModifiers = classModifiers;
            HeredityClasses = heredityClasses;
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
            return $"{AccessModifier} {ClassModifiers.Join()} {Name} : {HeredityClasses.Join()}";
        }
    }
}
