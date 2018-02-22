﻿using System.Collections.Generic;

namespace Converter.Golos
{
    public class ParsedType
    {
        public string Name { get; set; }

        public string CppName { get; set; }

        public bool IsArray { get; internal set; }

        public bool IsTemplate { get; internal set; }

        public List<ParsedType> Container { get; set; } = new List<ParsedType>();

        public bool IsOptional { get; internal set; }

        public override string ToString()
        {
            if (IsTemplate)
                return $"{Name}<{string.Join(", ", Container)}>";
            if (IsArray)
                return $"{Name}[]";
            return Name;
        }
    }
}