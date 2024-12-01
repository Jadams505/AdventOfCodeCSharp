using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    internal class Day15 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public string[] TheStrings { get; set; } = new string[1];

        public override void ConvertData()
        {
            var contents = File.ReadAllText(FilePath);
            var s = contents.Trim('\n');
            TheStrings = s.Split(',');
        }

        public static long Hash(string s)
        {
            long hash = 0;
            foreach (char c in s)
            {
                int ascii = (int)c;
                hash += ascii;
                hash *= 17;
                hash %= 256;
            }
            return hash;
        }

        public override long GetSolution1()
        {
            long result = 0;

            foreach (string s in TheStrings)
            {
                result += Hash(s);
            }

            return result;
        }

        public SortedDictionary<int, LinkedList<Value>> Lookup { get; set; } = new();

        public override long GetSolution2()
        {
            long result = 0;

            foreach(string s in TheStrings)
            {
                Value v = new(s);

                if(v.Operation == '-')
                {
                    if (Lookup.TryGetValue(v.Hash, out LinkedList<Value>? value))
                    {
                        value.Remove(v);
                    }
                }

                else if(v.Operation == '=')
                {
                    if (Lookup.TryGetValue(v.Hash, out LinkedList<Value>? value))
                    {
                        var node = value.Find(v);
                        if (node is not null)
                            node.Value = new(v);
                        else
                        {
                            value.AddLast(v);
                        }
                    }
                    else
                    {
                        var add = new LinkedList<Value>();
                        add.AddLast(v);
                        Lookup[v.Hash] = add;
                    }
                }
            }

            foreach(var pair in Lookup)
            {
                int box = pair.Key + 1;
                int slot = 1;
                foreach(var v in pair.Value)
                {
                    result += (box * slot * v.Length!.Value);
                    slot++;
                }
            }

            return result;
        }

        public class Value
        {
            public string Label { get; set; } = "";
            public int Hash { get; set; } = 0;
            public char Operation { get; set; } = 'c';
            public int? Length { get; set; } = null;

            public Value(string s)
            {
                int indexEqual = s.IndexOf('=');
                if(indexEqual != -1)
                {
                    var split = s.Split('=');
                    Label = split[0];
                    Hash = (int)Hash(split[0]);
                    Operation = '=';
                    Length = int.Parse(split[1]);
                    return;
                }
                int indexDash = s.IndexOf('-');
                if(indexDash != -1)
                {
                    var split = s.Split('-');
                    Label = split[0];
                    Hash = (int)Hash(split[0]);
                    Operation = '-';
                    Length = null;
                    return;
                }
            }

            public Value(Value other)
            {
                Label = other.Label;
                Hash = other.Hash;
                Operation = other.Operation;
                Length = other.Length;
            }

            public override bool Equals(object? obj)
            {
                if(obj is Value other)
                {
                    return Label.Equals(other.Label);
                }
                return false;
            }
        }
    }
}
