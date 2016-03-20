﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    public class CcaProject
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public List<CcaClass> Classes { get; set; } = new List<CcaClass>();

        public CcaProject(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public CcaProject()
        {
            //todo: zjistit nazev projektu - kontrola jestli se hlavni namespace jmenuje jako projekt
        }
    }
}