using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day13 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public List<Mirror> Mirrors { get; set; } = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            Mirror m = new();
            for(int i = 0; i < contents.Length; ++i)
            {
                var line = contents[i];
                if(line == "")
                {
                    Mirrors.Add(m);
                    m = new();
                }
                else
                {
                    List<char> temp = new();
                    foreach(var c in line)
                    {
                        temp.Add(c);
                        
                    }
                    m.Data.Add(temp);
                }
            }
            Mirrors.Add(m);
        }

        public override long GetSolution1()
        {
            long result = 0;

            foreach(var m in Mirrors)
            {
                int h = m.HorizontalReflextion();
                int v = m.VerticalReflextion();

                if(v != -1)
                    result += v;

                if(h != -1)
                    result += h * 100;
            }

            return result;
        }

        public override long GetSolution2()
        {
            long result = 0;
            int i = 0;
            foreach (var m in Mirrors)
            {
                int ret = m.FindSmudge(out bool isV);

                if(ret == -1)
                {
                    Console.WriteLine("bad");
                }

                if (isV && ret != -1)
                    result += ret;

                if (!isV && ret != -1)
                    result += ret * 100;

                i++;
            }
            
            return result;
        }
    }

    public class Mirror
    {
        public List<List<char>> Data { get; set; } = new();

        public int VerticalReflextion(int except = -2)
        {
            int index = -1;

            for (int i = 1; i < Data[0].Count; ++i)
            {
                for (int j = 0; j < Data.Count; ++j)
                {
                    for (int l = i - 1, r = i; l >= 0 && r < Data[j].Count; l--, r++)
                    {
                        char left = Data[j][l];
                        char right = Data[j][r];
                        if (!left.Equals(right))
                        {
                            index = -1;
                            goto End;
                        }
                        else
                        {
                            index = i;
                        }
                    }
                }
                if (index != -1 && index != except)
                    break;
            End:
                int bruh = 0;
            }
            return index;
        }

        public int FindSmudge(out bool isV)
        {
            int ogv = VerticalReflextion();
            int ogh = HorizontalReflextion();
            for (int i = 0; i < Data.Count; ++i)
            {
                for(int j = 0; j < Data[i].Count; ++j)
                {
                    if (Data[i][j] == '#')
                        Data[i][j] = '.';
                    else if (Data[i][j] == '.')
                        Data[i][j] = '#';

                    int v = VerticalReflextion(ogv);
                    int h = HorizontalReflextion(ogh);

                    if (Data[i][j] == '#')
                        Data[i][j] = '.';
                    else if (Data[i][j] == '.')
                        Data[i][j] = '#';

                    if (v != -1 && v != ogv)
                    {
                        isV = true;

                        return v;
                    }

                    if (h != -1 && h != ogh)
                    {
                        isV = false;
                        return h;
                    }

                }
            }
            isV = false;
            return -1;
        }

        public string StringList(List<char> cs)
        {
            StringBuilder b = new(cs.Count);

            foreach(char c in cs)
            {
                b.Append(c);
            }
            return b.ToString();
        }

        public int HorizontalReflextion(int except = -2)
        {
            int index = -1;
            for(int i = 1; i < Data.Count; ++i)
            {
                index = -1;
                for(int j = i - 1, k = i; j >= 0 && k < Data.Count; j--, k++)
                {
                    string up = StringList(Data[j]);
                    string down = StringList(Data[k]);
                    if (!up.Equals(down))
                    {
                        index = -1;
                        break;
                    }
                    else
                    {
                        index = i;
                    }
                }
                if (index != -1 && index != except)
                    break;
            }
            return index;
        }

        public bool SameOnBothSides(string s, int index)
        {
            string left = "";
            for(int i = 0; i < index; ++i)
            {
                left += s[i];
            }

            string right = s[index..];
            return left.Reverse().Equals(right);
        }
    }
}
