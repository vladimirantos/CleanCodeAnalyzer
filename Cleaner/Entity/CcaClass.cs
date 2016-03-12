using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public bool IsStatic { get; }
        public List<CcaClass> HeredityClasses { get; private set; }

        public ClassHeader(AccessModifiers accessModifier, string name, List<ClassModifiers> classModifiers, List<CcaClass> heredityClasses, bool isStatic)
        {
            AccessModifier = accessModifier;
            Name = name;
            ClassModifiers = classModifiers;
            HeredityClasses = heredityClasses;
            IsStatic = isStatic;
        }

        public ClassHeader(AccessModifiers accessModifier, string name)
        {
            AccessModifier = accessModifier;
            Name = name;
        }

        public ClassHeader(AccessModifiers accessModifier, string name, List<ClassModifiers> classModifiers, List<CcaClass> heredityClasses) 
            : this(accessModifier, name, classModifiers, heredityClasses, false)
        {
        }

        public ClassHeader(AccessModifiers accessModifier, string name, List<ClassModifiers> classModifiers)
            : this(accessModifier, name, classModifiers, new List<CcaClass>(), false)
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
