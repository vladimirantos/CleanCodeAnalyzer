using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Utils;

namespace Cleaner.Entity
{
    public class CcaClass
    {
        public string File { get; private set; }
        public CcaNamespace Namespace { get; set; }
        public ClassHeader Header { get; }
        public List<ClassMember> Members { get; }
        public List<CcaMethod> Methods { get; }

        public CcaClass(string file, ClassHeader header)
        {
            File = file;
            Header = header;
        }

        public CcaClass()
        {
            //todo: odstranit
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
        public List<CcaClass> HeredityClasses { get; private set; }

        public ClassHeader(AccessModifiers accessModifier, string name, List<ClassModifiers> classModifiers, List<CcaClass> heredityClasses)
        {
            AccessModifier = accessModifier;
            Name = name;
            ClassModifiers = classModifiers;
            HeredityClasses = heredityClasses;
        }

        public ClassHeader(AccessModifiers accessModifier, string name)
            : this(accessModifier, name, new List<ClassModifiers>(), new List<CcaClass>())
        {
            AccessModifier = accessModifier;
            Name = name;
        }

        public ClassHeader(AccessModifiers accessModifier, string name, List<ClassModifiers> classModifiers)
            : this(accessModifier, name, classModifiers, new List<CcaClass>())
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
            string classModifiers = null;
            ClassModifiers.ForEach(x => classModifiers += x);
            string heredity = null;
            HeredityClasses.ForEach(x => heredity += x);
            return $"{AccessModifier} {classModifiers} {Name} {heredity}";
        }
    }
}
