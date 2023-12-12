using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public partial class Record
    {
        public IEnumerable<List<State>> List6Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    List<State> curr = new(States.Count);
                                    curr.AddRange(list[0..listRange]);
                                    curr.AddRange(list2[0..list2Range]);
                                    curr.AddRange(list3[0..list3Range]);
                                    curr.AddRange(list4[0..list4Range]);
                                    curr.AddRange(list5[0..list5Range]);
                                    curr.AddRange(list6);
                                    if (CheckPermutation(curr))
                                        yield return curr;
                                }  
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<List<State>> List5Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            foreach(var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                List<State> curr = new(States.Count);
                                curr.AddRange(list[0..listRange]);
                                curr.AddRange(list2[0..list2Range]);
                                curr.AddRange(list3[0..list3Range]);
                                curr.AddRange(list4[0..list4Range]);
                                curr.AddRange(list5);
                                if (CheckPermutation(curr))
                                    yield return curr;
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<List<State>> List4Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            List<State> curr = new(States.Count);
                            curr.AddRange(list[0..listRange]);
                            curr.AddRange(list2[0..list2Range]);
                            curr.AddRange(list3[0..list3Range]);
                            curr.AddRange(list4);
                            if (CheckPermutation(curr))
                                yield return curr;
                        }
                    }
                }
            }
        }

        public IEnumerable<List<State>> List3Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int newCount = list.Count - Alternative[0] - 1;
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int newCount2 = list2.Count - Alternative[1] - 1;
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        List<State> curr = new(States.Count);
                        curr.AddRange(list[0..listRange]);
                        curr.AddRange(list2[0..list2Range]);
                        curr.AddRange(list3);
                        if (CheckPermutation(curr))
                            yield return curr;
                    }
                }
            }
        }

        public IEnumerable<List<State>> List2Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int newCount = list.Count - Alternative[0] - 1;
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    List<State> curr = new(States.Count);
                    curr.AddRange(list[0..listRange]);
                    curr.AddRange(list2);
                    if (CheckPermutation(curr))
                        yield return curr;
                }
            }
        }

        public IEnumerable<List<State>> List1Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                yield return list;
            }
        }
    }
}
