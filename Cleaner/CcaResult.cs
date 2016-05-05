﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner
{
    public class CcaResult
    {
        public CcaClass Class { get; private set; }

        public Errors Errors { get; } = new Errors();

        public CcaResult(CcaClass @class)
        {
            Class = @class;
        }
    }

    public class Errors
    {
        public int NamesLength { get; set; }
        public int CorrectNames { get; set; }
        public int CodeLines { get; set; }
        public int CommentLines { get; set; }
        public int WhitespaceLines { get; set; }
        public int RealCodeLines => CodeLines - (CommentLines + WhitespaceLines);
        public int CountVariables { get; set; }
        public int CountProperties { get; set; }
        public int CountMethods { get; set; }
        public int SimilarityMethods { get; set; }
        public int CountArgs { get; set; }
        public int CyclomaticComplx { get; set; }
    }

}