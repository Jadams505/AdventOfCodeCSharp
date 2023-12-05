using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day5 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        List<long> Seeds { get; set; } = new();

        public List<(long source, long dest, long range)> SeedToSoil { get; set; } = new();

        public List<(long source, long dest, long range)> SoilToFertilizer { get; set; } = new();

        public List<(long source, long dest, long range)> FertToWat { get; set; } = new();

        public List<(long source, long dest, long range)> WatToLight { get; set; } = new();

        public List<(long source, long dest, long range)> LightToTemp { get; set; } = new();

        public List<(long source, long dest, long range)> TempToHum { get; set; } = new();

        public List<(long source, long dest, long range)> HumToLoc { get; set; } = new();

        public override void ConvertData()
        {
            string line = File.ReadAllText(FilePath);
            int startIndex = 0;

            int seed = line.IndexOf("seeds:", startIndex);
            int seedToSoil = line.IndexOf("seed-to-soil");
            int soilToFert = line.IndexOf("soil-to");
            int fertToWater = line.IndexOf("fertilizer-to");
            int waterToL = line.IndexOf("water-to-light");
            int lightToTemp = line.IndexOf("light-to");
            int tempToHum = line.IndexOf("temperature-to");
            int humToLoc = line.IndexOf("humidity-to-loc");
            int end = int.MaxValue;

            Match match = Regex.Match(line, @"\d+");

            List<long> SeedToSoil = new();
            List<long> SoilToFertilizer = new();
            List<long> FertToWat = new();
            List<long> WatToLight = new();
            List<long> LightToTemp = new();
            List<long> TempToHum = new();
            List<long> HumToLoc = new();

            do
            {
                if (!match.Success)
                    break;
                long num = long.Parse(match.Value);

                if (match.Index < seedToSoil)
                {
                    Seeds.Add(num);
                    goto Next;
                }
                if (match.Index < soilToFert)
                {
                    SeedToSoil.Add(num);
                    goto Next;
                }
                if (match.Index < fertToWater)
                {
                    SoilToFertilizer.Add(num);
                    goto Next;
                }
                if (match.Index < waterToL)
                {
                    FertToWat.Add(num);
                    goto Next;
                }
                if (match.Index < lightToTemp)
                {
                    WatToLight.Add(num);
                    goto Next;
                }
                if (match.Index < tempToHum)
                {
                    LightToTemp.Add(num);
                    goto Next;
                }
                if (match.Index < humToLoc)
                {
                    TempToHum.Add(num);
                    goto Next;
                }
                if (match.Index < end)
                {
                    HumToLoc.Add(num);
                    goto Next;
                }

            Next:
                match = match.NextMatch();

            } while (true);

            this.SeedToSoil = ToDict(SeedToSoil);
            this.SoilToFertilizer = ToDict(SoilToFertilizer);
            this.FertToWat = ToDict(FertToWat);
            this.WatToLight = ToDict(WatToLight);
            this.LightToTemp = ToDict(LightToTemp);
            this.TempToHum = ToDict(TempToHum);
            this.HumToLoc = ToDict(HumToLoc);
        }

        public static List<(long, long, long)> ToDict(List<long> list)
        {
            List<(long s, long d, long r)> dict = new();
            for (int i = 0; i < list.Count; i += 3)
            {
                long dest = list[i];
                long source = list[i + 1];
                long range = list[i + 2];

                dict.Add((source, dest, range));
            }
            return dict;
        }

        public static long FindInDict(List<(long, long, long)> dict, long value)
        {
            foreach ((long s, long d, long r) in dict)
            {
                if (value - r >= s || value < s)
                    continue;
                long diff = value - s;
                return d + diff;
            }
            return -1;
        }

        public static List<(long rangeStart, long rangeEnd)> FindInDict(List<(long, long, long)> dict, long start, long range)
        {
            List<(long, long)> ranges = new();
            foreach ((long s, long d, long r) in dict)
            {
                long min = Math.Max(start, s);
                long max = Math.Min(s + r - 1, start + range - 1);

                if (min >= max)
                    continue;

                long lower = min - s + d;
                long upper = max - s + d;

                ranges.Add((lower, upper - lower + 1));
            }

            return ranges;
        }

        public static List<(long fromStart, long fromEnd, long toStart, long toEnd)>
            FindInDict2(List<(long s, long d, long r)> dict, long start, long range)
        {
            // everything is inclusive
            List<(long fromStart, long fromEnd, long toStart, long toEnd)> ranges = new();
            foreach ((long s, long d, long r) in dict)
            {
                long min = Math.Max(start, s);
                long max = Math.Min(s + r - 1, start + range - 1);

                if (min >= max)
                    continue;

                long lower = min - s + d;
                long upper = max - s + d;

                if(max - min != upper - lower)
                {
                    bool bad = true;
                }

                ranges.Add((min, max, lower, upper));
            }
            long end = start + range - 1;
            if (ranges.Count >= 1)
            {
                ranges.Sort((a, b) => a.fromStart.CompareTo(b.fromStart));

                long tempStart = start;
                long tempEnd = ranges[0].fromStart - 1;
                long added = 0;
                long initialCount = ranges.Count;
                if (tempEnd - tempStart >= 0)
                {
                    ranges.Insert(0, (tempStart, tempEnd, tempStart, tempEnd));
                    added++;
                }
                
                for (int i = (int)added; i < initialCount - 1; ++i)
                {
                    var curr = ranges[i];
                    var next = ranges[i + 1];
                    tempStart = curr.fromEnd + 1;
                    tempEnd = next.fromStart - 1;
                    if (tempEnd - tempStart >= 0)
                    {
                        ranges.Add((tempStart, tempEnd, tempStart, tempEnd));
                        added++;
                    }
                }

                tempStart = ranges[^1].fromEnd + 1;
                tempEnd = end;
                if (tempEnd - tempStart >= 0)
                {
                    ranges.Add((tempStart, tempEnd, tempStart, tempEnd));
                    added++;
                }
            }

            return ranges;
        }

        public IEnumerable<List<(long, long, long)>> Trail()
        {
            yield return SeedToSoil;
            yield return SoilToFertilizer;
            yield return FertToWat;
            yield return WatToLight;
            yield return LightToTemp;
            yield return TempToHum;
            yield return HumToLoc;
        }

        public override long GetSolution1()
        {
            List<(long seed, long loc)> lookup = new();
            foreach (var i in Seeds)
            {
                long locIndex = i;
                foreach (var dict in Trail())
                {
                    long f = FindInDict(dict, locIndex);
                    if (f == -1)
                    {
                        continue;
                    }
                    else
                    {
                        locIndex = f;
                    }
                }

                lookup.Add((i, locIndex));
            }

            return lookup.Min(x => x.loc);
        }

        public override long GetSolution2()
        {
            List<(long seed, long loc)> lookup = new();
            for (int i = 0; i < Seeds.Count; i += 2)
            {
                long start = Seeds[i];
                long range = Seeds[i + 1];

                List<(long start, long end, long s, long len)> toCheck = new() { (start, start + range - 1, start, range) };
                List<(long start, long end, long s, long len)> next = new();
                foreach (var dict in Trail())
                {
                    foreach (var r in toCheck)
                    {
                        var f = FindInDict2(dict, r.s, r.len);
                        if (f.Count == 0)
                        {
                            next.Add(r);
                        }
                        else
                        {
                            foreach (var entry in f)
                            {
                                next.Add((entry.fromStart, entry.fromEnd, entry.toStart, entry.toEnd - entry.toStart + 1));
                            }
                        }
                    }
                    if (next.Count != 0)
                    {
                        toCheck.Clear();
                        toCheck.AddRange(next);
                        next.Clear();
                    }
                }

                lookup.Add((start, toCheck.Min(x => x.s)));

            }
            return lookup.Min(x => x.loc);
        }
    }
}
