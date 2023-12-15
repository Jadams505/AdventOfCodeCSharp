using System.Collections;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Days
{
    public partial class Record
    {
        public IEnumerable<List<State>> List30Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                int list21Range = list21.LastIndexOf(State.Damaged) + 2;
                                                                                                Range range21 = new(range20.End, range20.End.Value + list21Range);
                                                                                                if (!ValidRange(list21, range21)) continue;
                                                                                                foreach (var list22 in EnumeratePermutations(Alternative[21], States.Count - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                {
                                                                                                    int list22Range = list22.LastIndexOf(State.Damaged) + 2;
                                                                                                    Range range22 = new(range21.End, range21.End.Value + list22Range);
                                                                                                    if (!ValidRange(list22, range22)) continue;
                                                                                                    foreach (var list23 in EnumeratePermutations(Alternative[22], States.Count - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                    {
                                                                                                        int list23Range = list23.LastIndexOf(State.Damaged) + 2;
                                                                                                        Range range23 = new(range22.End, range22.End.Value + list23Range);
                                                                                                        if (!ValidRange(list23, range23)) continue;
                                                                                                        foreach (var list24 in EnumeratePermutations(Alternative[23], States.Count - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                        {
                                                                                                            int list24Range = list24.LastIndexOf(State.Damaged) + 2;
                                                                                                            Range range24 = new(range23.End, range23.End.Value + list24Range);
                                                                                                            if (!ValidRange(list24, range24)) continue;
                                                                                                            foreach (var list25 in EnumeratePermutations(Alternative[24], States.Count - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                            {
                                                                                                                int list25Range = list25.LastIndexOf(State.Damaged) + 2;
                                                                                                                Range range25 = new(range24.End, range24.End.Value + list25Range);
                                                                                                                if (!ValidRange(list25, range25)) continue;
                                                                                                                foreach (var list26 in EnumeratePermutations(Alternative[25], States.Count - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                {
                                                                                                                    int list26Range = list26.LastIndexOf(State.Damaged) + 2;
                                                                                                                    Range range26 = new(range25.End, range25.End.Value + list26Range);
                                                                                                                    if (!ValidRange(list26, range26)) continue;
                                                                                                                    foreach (var list27 in EnumeratePermutations(Alternative[26], States.Count - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                    {
                                                                                                                        int list27Range = list27.LastIndexOf(State.Damaged) + 2;
                                                                                                                        Range range27 = new(range26.End, range26.End.Value + list27Range);
                                                                                                                        if (!ValidRange(list27, range27)) continue;
                                                                                                                        foreach (var list28 in EnumeratePermutations(Alternative[27], States.Count - list27Range - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                        {
                                                                                                                            int list28Range = list28.LastIndexOf(State.Damaged) + 2;
                                                                                                                            Range range28 = new(range27.End, range27.End.Value + list28Range);
                                                                                                                            if (!ValidRange(list28, range28)) continue;
                                                                                                                            foreach (var list29 in EnumeratePermutations(Alternative[28], States.Count - list28Range - list27Range - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                            {
                                                                                                                                int list29Range = list29.LastIndexOf(State.Damaged) + 2;
                                                                                                                                Range range29 = new(range28.End, range28.End.Value + list29Range);
                                                                                                                                if (!ValidRange(list29, range29)) continue;
                                                                                                                                foreach (var list30 in EnumeratePermutations(Alternative[29], States.Count - list29Range - list28Range - list27Range - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                                {
                                                                                                                                    List<State> curr = new(States.Count);
                                                                                                                                    curr.AddRange(list[0..listRange]);
                                                                                                                                    curr.AddRange(list2[0..list2Range]);
                                                                                                                                    curr.AddRange(list3[0..list3Range]);
                                                                                                                                    curr.AddRange(list4[0..list4Range]);
                                                                                                                                    curr.AddRange(list5[0..list5Range]);
                                                                                                                                    curr.AddRange(list6[0..list6Range]);
                                                                                                                                    curr.AddRange(list7[0..list7Range]);
                                                                                                                                    curr.AddRange(list8[0..list8Range]);
                                                                                                                                    curr.AddRange(list9[0..list9Range]);
                                                                                                                                    curr.AddRange(list10[0..list10Range]);
                                                                                                                                    curr.AddRange(list11[0..list11Range]);
                                                                                                                                    curr.AddRange(list12[0..list12Range]);
                                                                                                                                    curr.AddRange(list13[0..list13Range]);
                                                                                                                                    curr.AddRange(list14[0..list14Range]);
                                                                                                                                    curr.AddRange(list15[0..list15Range]);
                                                                                                                                    curr.AddRange(list16[0..list16Range]);
                                                                                                                                    curr.AddRange(list17[0..list17Range]);
                                                                                                                                    curr.AddRange(list18[0..list18Range]);
                                                                                                                                    curr.AddRange(list19[0..list19Range]);
                                                                                                                                    curr.AddRange(list20[0..list20Range]);
                                                                                                                                    curr.AddRange(list21[0..list21Range]);
                                                                                                                                    curr.AddRange(list22[0..list22Range]);
                                                                                                                                    curr.AddRange(list23[0..list23Range]);
                                                                                                                                    curr.AddRange(list24[0..list24Range]);
                                                                                                                                    curr.AddRange(list25[0..list25Range]);
                                                                                                                                    curr.AddRange(list26[0..list26Range]);
                                                                                                                                    curr.AddRange(list27[0..list27Range]);
                                                                                                                                    curr.AddRange(list28[0..list28Range]);
                                                                                                                                    curr.AddRange(list29[0..list29Range]);
                                                                                                                                    curr.AddRange(list30);
                                                                                                                                    if (CheckPermutation(curr))
                                                                                                                                        yield return curr;
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List29Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                int list21Range = list21.LastIndexOf(State.Damaged) + 2;
                                                                                                Range range21 = new(range20.End, range20.End.Value + list21Range);
                                                                                                if (!ValidRange(list21, range21)) continue;
                                                                                                foreach (var list22 in EnumeratePermutations(Alternative[21], States.Count - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                {
                                                                                                    int list22Range = list22.LastIndexOf(State.Damaged) + 2;
                                                                                                    Range range22 = new(range21.End, range21.End.Value + list22Range);
                                                                                                    if (!ValidRange(list22, range22)) continue;
                                                                                                    foreach (var list23 in EnumeratePermutations(Alternative[22], States.Count - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                    {
                                                                                                        int list23Range = list23.LastIndexOf(State.Damaged) + 2;
                                                                                                        Range range23 = new(range22.End, range22.End.Value + list23Range);
                                                                                                        if (!ValidRange(list23, range23)) continue;
                                                                                                        foreach (var list24 in EnumeratePermutations(Alternative[23], States.Count - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                        {
                                                                                                            int list24Range = list24.LastIndexOf(State.Damaged) + 2;
                                                                                                            Range range24 = new(range23.End, range23.End.Value + list24Range);
                                                                                                            if (!ValidRange(list24, range24)) continue;
                                                                                                            foreach (var list25 in EnumeratePermutations(Alternative[24], States.Count - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                            {
                                                                                                                int list25Range = list25.LastIndexOf(State.Damaged) + 2;
                                                                                                                Range range25 = new(range24.End, range24.End.Value + list25Range);
                                                                                                                if (!ValidRange(list25, range25)) continue;
                                                                                                                foreach (var list26 in EnumeratePermutations(Alternative[25], States.Count - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                {
                                                                                                                    int list26Range = list26.LastIndexOf(State.Damaged) + 2;
                                                                                                                    Range range26 = new(range25.End, range25.End.Value + list26Range);
                                                                                                                    if (!ValidRange(list26, range26)) continue;
                                                                                                                    foreach (var list27 in EnumeratePermutations(Alternative[26], States.Count - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                    {
                                                                                                                        int list27Range = list27.LastIndexOf(State.Damaged) + 2;
                                                                                                                        Range range27 = new(range26.End, range26.End.Value + list27Range);
                                                                                                                        if (!ValidRange(list27, range27)) continue;
                                                                                                                        foreach (var list28 in EnumeratePermutations(Alternative[27], States.Count - list27Range - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                        {
                                                                                                                            int list28Range = list28.LastIndexOf(State.Damaged) + 2;
                                                                                                                            Range range28 = new(range27.End, range27.End.Value + list28Range);
                                                                                                                            if (!ValidRange(list28, range28)) continue;
                                                                                                                            foreach (var list29 in EnumeratePermutations(Alternative[28], States.Count - list28Range - list27Range - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                            {
                                                                                                                                List<State> curr = new(States.Count);
                                                                                                                                curr.AddRange(list[0..listRange]);
                                                                                                                                curr.AddRange(list2[0..list2Range]);
                                                                                                                                curr.AddRange(list3[0..list3Range]);
                                                                                                                                curr.AddRange(list4[0..list4Range]);
                                                                                                                                curr.AddRange(list5[0..list5Range]);
                                                                                                                                curr.AddRange(list6[0..list6Range]);
                                                                                                                                curr.AddRange(list7[0..list7Range]);
                                                                                                                                curr.AddRange(list8[0..list8Range]);
                                                                                                                                curr.AddRange(list9[0..list9Range]);
                                                                                                                                curr.AddRange(list10[0..list10Range]);
                                                                                                                                curr.AddRange(list11[0..list11Range]);
                                                                                                                                curr.AddRange(list12[0..list12Range]);
                                                                                                                                curr.AddRange(list13[0..list13Range]);
                                                                                                                                curr.AddRange(list14[0..list14Range]);
                                                                                                                                curr.AddRange(list15[0..list15Range]);
                                                                                                                                curr.AddRange(list16[0..list16Range]);
                                                                                                                                curr.AddRange(list17[0..list17Range]);
                                                                                                                                curr.AddRange(list18[0..list18Range]);
                                                                                                                                curr.AddRange(list19[0..list19Range]);
                                                                                                                                curr.AddRange(list20[0..list20Range]);
                                                                                                                                curr.AddRange(list21[0..list21Range]);
                                                                                                                                curr.AddRange(list22[0..list22Range]);
                                                                                                                                curr.AddRange(list23[0..list23Range]);
                                                                                                                                curr.AddRange(list24[0..list24Range]);
                                                                                                                                curr.AddRange(list25[0..list25Range]);
                                                                                                                                curr.AddRange(list26[0..list26Range]);
                                                                                                                                curr.AddRange(list27[0..list27Range]);
                                                                                                                                curr.AddRange(list28[0..list28Range]);
                                                                                                                                curr.AddRange(list29);
                                                                                                                                if (CheckPermutation(curr))
                                                                                                                                    yield return curr;
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List28Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                int list21Range = list21.LastIndexOf(State.Damaged) + 2;
                                                                                                Range range21 = new(range20.End, range20.End.Value + list21Range);
                                                                                                if (!ValidRange(list21, range21)) continue;
                                                                                                foreach (var list22 in EnumeratePermutations(Alternative[21], States.Count - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                {
                                                                                                    int list22Range = list22.LastIndexOf(State.Damaged) + 2;
                                                                                                    Range range22 = new(range21.End, range21.End.Value + list22Range);
                                                                                                    if (!ValidRange(list22, range22)) continue;
                                                                                                    foreach (var list23 in EnumeratePermutations(Alternative[22], States.Count - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                    {
                                                                                                        int list23Range = list23.LastIndexOf(State.Damaged) + 2;
                                                                                                        Range range23 = new(range22.End, range22.End.Value + list23Range);
                                                                                                        if (!ValidRange(list23, range23)) continue;
                                                                                                        foreach (var list24 in EnumeratePermutations(Alternative[23], States.Count - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                        {
                                                                                                            int list24Range = list24.LastIndexOf(State.Damaged) + 2;
                                                                                                            Range range24 = new(range23.End, range23.End.Value + list24Range);
                                                                                                            if (!ValidRange(list24, range24)) continue;
                                                                                                            foreach (var list25 in EnumeratePermutations(Alternative[24], States.Count - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                            {
                                                                                                                int list25Range = list25.LastIndexOf(State.Damaged) + 2;
                                                                                                                Range range25 = new(range24.End, range24.End.Value + list25Range);
                                                                                                                if (!ValidRange(list25, range25)) continue;
                                                                                                                foreach (var list26 in EnumeratePermutations(Alternative[25], States.Count - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                {
                                                                                                                    int list26Range = list26.LastIndexOf(State.Damaged) + 2;
                                                                                                                    Range range26 = new(range25.End, range25.End.Value + list26Range);
                                                                                                                    if (!ValidRange(list26, range26)) continue;
                                                                                                                    foreach (var list27 in EnumeratePermutations(Alternative[26], States.Count - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                    {
                                                                                                                        int list27Range = list27.LastIndexOf(State.Damaged) + 2;
                                                                                                                        Range range27 = new(range26.End, range26.End.Value + list27Range);
                                                                                                                        if (!ValidRange(list27, range27)) continue;
                                                                                                                        foreach (var list28 in EnumeratePermutations(Alternative[27], States.Count - list27Range - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                        {
                                                                                                                            List<State> curr = new(States.Count);
                                                                                                                            curr.AddRange(list[0..listRange]);
                                                                                                                            curr.AddRange(list2[0..list2Range]);
                                                                                                                            curr.AddRange(list3[0..list3Range]);
                                                                                                                            curr.AddRange(list4[0..list4Range]);
                                                                                                                            curr.AddRange(list5[0..list5Range]);
                                                                                                                            curr.AddRange(list6[0..list6Range]);
                                                                                                                            curr.AddRange(list7[0..list7Range]);
                                                                                                                            curr.AddRange(list8[0..list8Range]);
                                                                                                                            curr.AddRange(list9[0..list9Range]);
                                                                                                                            curr.AddRange(list10[0..list10Range]);
                                                                                                                            curr.AddRange(list11[0..list11Range]);
                                                                                                                            curr.AddRange(list12[0..list12Range]);
                                                                                                                            curr.AddRange(list13[0..list13Range]);
                                                                                                                            curr.AddRange(list14[0..list14Range]);
                                                                                                                            curr.AddRange(list15[0..list15Range]);
                                                                                                                            curr.AddRange(list16[0..list16Range]);
                                                                                                                            curr.AddRange(list17[0..list17Range]);
                                                                                                                            curr.AddRange(list18[0..list18Range]);
                                                                                                                            curr.AddRange(list19[0..list19Range]);
                                                                                                                            curr.AddRange(list20[0..list20Range]);
                                                                                                                            curr.AddRange(list21[0..list21Range]);
                                                                                                                            curr.AddRange(list22[0..list22Range]);
                                                                                                                            curr.AddRange(list23[0..list23Range]);
                                                                                                                            curr.AddRange(list24[0..list24Range]);
                                                                                                                            curr.AddRange(list25[0..list25Range]);
                                                                                                                            curr.AddRange(list26[0..list26Range]);
                                                                                                                            curr.AddRange(list27[0..list27Range]);
                                                                                                                            curr.AddRange(list28);
                                                                                                                            if (CheckPermutation(curr))
                                                                                                                                yield return curr;
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List27Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                int list21Range = list21.LastIndexOf(State.Damaged) + 2;
                                                                                                Range range21 = new(range20.End, range20.End.Value + list21Range);
                                                                                                if (!ValidRange(list21, range21)) continue;
                                                                                                foreach (var list22 in EnumeratePermutations(Alternative[21], States.Count - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                {
                                                                                                    int list22Range = list22.LastIndexOf(State.Damaged) + 2;
                                                                                                    Range range22 = new(range21.End, range21.End.Value + list22Range);
                                                                                                    if (!ValidRange(list22, range22)) continue;
                                                                                                    foreach (var list23 in EnumeratePermutations(Alternative[22], States.Count - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                    {
                                                                                                        int list23Range = list23.LastIndexOf(State.Damaged) + 2;
                                                                                                        Range range23 = new(range22.End, range22.End.Value + list23Range);
                                                                                                        if (!ValidRange(list23, range23)) continue;
                                                                                                        foreach (var list24 in EnumeratePermutations(Alternative[23], States.Count - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                        {
                                                                                                            int list24Range = list24.LastIndexOf(State.Damaged) + 2;
                                                                                                            Range range24 = new(range23.End, range23.End.Value + list24Range);
                                                                                                            if (!ValidRange(list24, range24)) continue;
                                                                                                            foreach (var list25 in EnumeratePermutations(Alternative[24], States.Count - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                            {
                                                                                                                int list25Range = list25.LastIndexOf(State.Damaged) + 2;
                                                                                                                Range range25 = new(range24.End, range24.End.Value + list25Range);
                                                                                                                if (!ValidRange(list25, range25)) continue;
                                                                                                                foreach (var list26 in EnumeratePermutations(Alternative[25], States.Count - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                {
                                                                                                                    int list26Range = list26.LastIndexOf(State.Damaged) + 2;
                                                                                                                    Range range26 = new(range25.End, range25.End.Value + list26Range);
                                                                                                                    if (!ValidRange(list26, range26)) continue;
                                                                                                                    foreach (var list27 in EnumeratePermutations(Alternative[26], States.Count - list26Range - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                    {
                                                                                                                        List<State> curr = new(States.Count);
                                                                                                                        curr.AddRange(list[0..listRange]);
                                                                                                                        curr.AddRange(list2[0..list2Range]);
                                                                                                                        curr.AddRange(list3[0..list3Range]);
                                                                                                                        curr.AddRange(list4[0..list4Range]);
                                                                                                                        curr.AddRange(list5[0..list5Range]);
                                                                                                                        curr.AddRange(list6[0..list6Range]);
                                                                                                                        curr.AddRange(list7[0..list7Range]);
                                                                                                                        curr.AddRange(list8[0..list8Range]);
                                                                                                                        curr.AddRange(list9[0..list9Range]);
                                                                                                                        curr.AddRange(list10[0..list10Range]);
                                                                                                                        curr.AddRange(list11[0..list11Range]);
                                                                                                                        curr.AddRange(list12[0..list12Range]);
                                                                                                                        curr.AddRange(list13[0..list13Range]);
                                                                                                                        curr.AddRange(list14[0..list14Range]);
                                                                                                                        curr.AddRange(list15[0..list15Range]);
                                                                                                                        curr.AddRange(list16[0..list16Range]);
                                                                                                                        curr.AddRange(list17[0..list17Range]);
                                                                                                                        curr.AddRange(list18[0..list18Range]);
                                                                                                                        curr.AddRange(list19[0..list19Range]);
                                                                                                                        curr.AddRange(list20[0..list20Range]);
                                                                                                                        curr.AddRange(list21[0..list21Range]);
                                                                                                                        curr.AddRange(list22[0..list22Range]);
                                                                                                                        curr.AddRange(list23[0..list23Range]);
                                                                                                                        curr.AddRange(list24[0..list24Range]);
                                                                                                                        curr.AddRange(list25[0..list25Range]);
                                                                                                                        curr.AddRange(list26[0..list26Range]);
                                                                                                                        curr.AddRange(list27);
                                                                                                                        if (CheckPermutation(curr))
                                                                                                                            yield return curr;
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List26Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                int list21Range = list21.LastIndexOf(State.Damaged) + 2;
                                                                                                Range range21 = new(range20.End, range20.End.Value + list21Range);
                                                                                                if (!ValidRange(list21, range21)) continue;
                                                                                                foreach (var list22 in EnumeratePermutations(Alternative[21], States.Count - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                {
                                                                                                    int list22Range = list22.LastIndexOf(State.Damaged) + 2;
                                                                                                    Range range22 = new(range21.End, range21.End.Value + list22Range);
                                                                                                    if (!ValidRange(list22, range22)) continue;
                                                                                                    foreach (var list23 in EnumeratePermutations(Alternative[22], States.Count - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                    {
                                                                                                        int list23Range = list23.LastIndexOf(State.Damaged) + 2;
                                                                                                        Range range23 = new(range22.End, range22.End.Value + list23Range);
                                                                                                        if (!ValidRange(list23, range23)) continue;
                                                                                                        foreach (var list24 in EnumeratePermutations(Alternative[23], States.Count - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                        {
                                                                                                            int list24Range = list24.LastIndexOf(State.Damaged) + 2;
                                                                                                            Range range24 = new(range23.End, range23.End.Value + list24Range);
                                                                                                            if (!ValidRange(list24, range24)) continue;
                                                                                                            foreach (var list25 in EnumeratePermutations(Alternative[24], States.Count - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                            {
                                                                                                                int list25Range = list25.LastIndexOf(State.Damaged) + 2;
                                                                                                                Range range25 = new(range24.End, range24.End.Value + list25Range);
                                                                                                                if (!ValidRange(list25, range25)) continue;
                                                                                                                foreach (var list26 in EnumeratePermutations(Alternative[25], States.Count - list25Range - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                                {
                                                                                                                    List<State> curr = new(States.Count);
                                                                                                                    curr.AddRange(list[0..listRange]);
                                                                                                                    curr.AddRange(list2[0..list2Range]);
                                                                                                                    curr.AddRange(list3[0..list3Range]);
                                                                                                                    curr.AddRange(list4[0..list4Range]);
                                                                                                                    curr.AddRange(list5[0..list5Range]);
                                                                                                                    curr.AddRange(list6[0..list6Range]);
                                                                                                                    curr.AddRange(list7[0..list7Range]);
                                                                                                                    curr.AddRange(list8[0..list8Range]);
                                                                                                                    curr.AddRange(list9[0..list9Range]);
                                                                                                                    curr.AddRange(list10[0..list10Range]);
                                                                                                                    curr.AddRange(list11[0..list11Range]);
                                                                                                                    curr.AddRange(list12[0..list12Range]);
                                                                                                                    curr.AddRange(list13[0..list13Range]);
                                                                                                                    curr.AddRange(list14[0..list14Range]);
                                                                                                                    curr.AddRange(list15[0..list15Range]);
                                                                                                                    curr.AddRange(list16[0..list16Range]);
                                                                                                                    curr.AddRange(list17[0..list17Range]);
                                                                                                                    curr.AddRange(list18[0..list18Range]);
                                                                                                                    curr.AddRange(list19[0..list19Range]);
                                                                                                                    curr.AddRange(list20[0..list20Range]);
                                                                                                                    curr.AddRange(list21[0..list21Range]);
                                                                                                                    curr.AddRange(list22[0..list22Range]);
                                                                                                                    curr.AddRange(list23[0..list23Range]);
                                                                                                                    curr.AddRange(list24[0..list24Range]);
                                                                                                                    curr.AddRange(list25[0..list25Range]);
                                                                                                                    curr.AddRange(list26);
                                                                                                                    if (CheckPermutation(curr))
                                                                                                                        yield return curr;
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List25Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                int list21Range = list21.LastIndexOf(State.Damaged) + 2;
                                                                                                Range range21 = new(range20.End, range20.End.Value + list21Range);
                                                                                                if (!ValidRange(list21, range21)) continue;
                                                                                                foreach (var list22 in EnumeratePermutations(Alternative[21], States.Count - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                {
                                                                                                    int list22Range = list22.LastIndexOf(State.Damaged) + 2;
                                                                                                    Range range22 = new(range21.End, range21.End.Value + list22Range);
                                                                                                    if (!ValidRange(list22, range22)) continue;
                                                                                                    foreach (var list23 in EnumeratePermutations(Alternative[22], States.Count - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                    {
                                                                                                        int list23Range = list23.LastIndexOf(State.Damaged) + 2;
                                                                                                        Range range23 = new(range22.End, range22.End.Value + list23Range);
                                                                                                        if (!ValidRange(list23, range23)) continue;
                                                                                                        foreach (var list24 in EnumeratePermutations(Alternative[23], States.Count - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                        {
                                                                                                            int list24Range = list24.LastIndexOf(State.Damaged) + 2;
                                                                                                            Range range24 = new(range23.End, range23.End.Value + list24Range);
                                                                                                            if (!ValidRange(list24, range24)) continue;
                                                                                                            foreach (var list25 in EnumeratePermutations(Alternative[24], States.Count - list24Range - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                            {
                                                                                                                List<State> curr = new(States.Count);
                                                                                                                curr.AddRange(list[0..listRange]);
                                                                                                                curr.AddRange(list2[0..list2Range]);
                                                                                                                curr.AddRange(list3[0..list3Range]);
                                                                                                                curr.AddRange(list4[0..list4Range]);
                                                                                                                curr.AddRange(list5[0..list5Range]);
                                                                                                                curr.AddRange(list6[0..list6Range]);
                                                                                                                curr.AddRange(list7[0..list7Range]);
                                                                                                                curr.AddRange(list8[0..list8Range]);
                                                                                                                curr.AddRange(list9[0..list9Range]);
                                                                                                                curr.AddRange(list10[0..list10Range]);
                                                                                                                curr.AddRange(list11[0..list11Range]);
                                                                                                                curr.AddRange(list12[0..list12Range]);
                                                                                                                curr.AddRange(list13[0..list13Range]);
                                                                                                                curr.AddRange(list14[0..list14Range]);
                                                                                                                curr.AddRange(list15[0..list15Range]);
                                                                                                                curr.AddRange(list16[0..list16Range]);
                                                                                                                curr.AddRange(list17[0..list17Range]);
                                                                                                                curr.AddRange(list18[0..list18Range]);
                                                                                                                curr.AddRange(list19[0..list19Range]);
                                                                                                                curr.AddRange(list20[0..list20Range]);
                                                                                                                curr.AddRange(list21[0..list21Range]);
                                                                                                                curr.AddRange(list22[0..list22Range]);
                                                                                                                curr.AddRange(list23[0..list23Range]);
                                                                                                                curr.AddRange(list24[0..list24Range]);
                                                                                                                curr.AddRange(list25);
                                                                                                                if (CheckPermutation(curr))
                                                                                                                    yield return curr;
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List24Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                int list21Range = list21.LastIndexOf(State.Damaged) + 2;
                                                                                                Range range21 = new(range20.End, range20.End.Value + list21Range);
                                                                                                if (!ValidRange(list21, range21)) continue;
                                                                                                foreach (var list22 in EnumeratePermutations(Alternative[21], States.Count - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                {
                                                                                                    int list22Range = list22.LastIndexOf(State.Damaged) + 2;
                                                                                                    Range range22 = new(range21.End, range21.End.Value + list22Range);
                                                                                                    if (!ValidRange(list22, range22)) continue;
                                                                                                    foreach (var list23 in EnumeratePermutations(Alternative[22], States.Count - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                    {
                                                                                                        int list23Range = list23.LastIndexOf(State.Damaged) + 2;
                                                                                                        Range range23 = new(range22.End, range22.End.Value + list23Range);
                                                                                                        if (!ValidRange(list23, range23)) continue;
                                                                                                        foreach (var list24 in EnumeratePermutations(Alternative[23], States.Count - list23Range - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                        {
                                                                                                            List<State> curr = new(States.Count);
                                                                                                            curr.AddRange(list[0..listRange]);
                                                                                                            curr.AddRange(list2[0..list2Range]);
                                                                                                            curr.AddRange(list3[0..list3Range]);
                                                                                                            curr.AddRange(list4[0..list4Range]);
                                                                                                            curr.AddRange(list5[0..list5Range]);
                                                                                                            curr.AddRange(list6[0..list6Range]);
                                                                                                            curr.AddRange(list7[0..list7Range]);
                                                                                                            curr.AddRange(list8[0..list8Range]);
                                                                                                            curr.AddRange(list9[0..list9Range]);
                                                                                                            curr.AddRange(list10[0..list10Range]);
                                                                                                            curr.AddRange(list11[0..list11Range]);
                                                                                                            curr.AddRange(list12[0..list12Range]);
                                                                                                            curr.AddRange(list13[0..list13Range]);
                                                                                                            curr.AddRange(list14[0..list14Range]);
                                                                                                            curr.AddRange(list15[0..list15Range]);
                                                                                                            curr.AddRange(list16[0..list16Range]);
                                                                                                            curr.AddRange(list17[0..list17Range]);
                                                                                                            curr.AddRange(list18[0..list18Range]);
                                                                                                            curr.AddRange(list19[0..list19Range]);
                                                                                                            curr.AddRange(list20[0..list20Range]);
                                                                                                            curr.AddRange(list21[0..list21Range]);
                                                                                                            curr.AddRange(list22[0..list22Range]);
                                                                                                            curr.AddRange(list23[0..list23Range]);
                                                                                                            curr.AddRange(list24);
                                                                                                            if (CheckPermutation(curr))
                                                                                                                yield return curr;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List23Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                int list21Range = list21.LastIndexOf(State.Damaged) + 2;
                                                                                                Range range21 = new(range20.End, range20.End.Value + list21Range);
                                                                                                if (!ValidRange(list21, range21)) continue;
                                                                                                foreach (var list22 in EnumeratePermutations(Alternative[21], States.Count - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                {
                                                                                                    int list22Range = list22.LastIndexOf(State.Damaged) + 2;
                                                                                                    Range range22 = new(range21.End, range21.End.Value + list22Range);
                                                                                                    if (!ValidRange(list22, range22)) continue;
                                                                                                    foreach (var list23 in EnumeratePermutations(Alternative[22], States.Count - list22Range - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                    {
                                                                                                        List<State> curr = new(States.Count);
                                                                                                        curr.AddRange(list[0..listRange]);
                                                                                                        curr.AddRange(list2[0..list2Range]);
                                                                                                        curr.AddRange(list3[0..list3Range]);
                                                                                                        curr.AddRange(list4[0..list4Range]);
                                                                                                        curr.AddRange(list5[0..list5Range]);
                                                                                                        curr.AddRange(list6[0..list6Range]);
                                                                                                        curr.AddRange(list7[0..list7Range]);
                                                                                                        curr.AddRange(list8[0..list8Range]);
                                                                                                        curr.AddRange(list9[0..list9Range]);
                                                                                                        curr.AddRange(list10[0..list10Range]);
                                                                                                        curr.AddRange(list11[0..list11Range]);
                                                                                                        curr.AddRange(list12[0..list12Range]);
                                                                                                        curr.AddRange(list13[0..list13Range]);
                                                                                                        curr.AddRange(list14[0..list14Range]);
                                                                                                        curr.AddRange(list15[0..list15Range]);
                                                                                                        curr.AddRange(list16[0..list16Range]);
                                                                                                        curr.AddRange(list17[0..list17Range]);
                                                                                                        curr.AddRange(list18[0..list18Range]);
                                                                                                        curr.AddRange(list19[0..list19Range]);
                                                                                                        curr.AddRange(list20[0..list20Range]);
                                                                                                        curr.AddRange(list21[0..list21Range]);
                                                                                                        curr.AddRange(list22[0..list22Range]);
                                                                                                        curr.AddRange(list23);
                                                                                                        if (CheckPermutation(curr))
                                                                                                            yield return curr;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List22Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                int list21Range = list21.LastIndexOf(State.Damaged) + 2;
                                                                                                Range range21 = new(range20.End, range20.End.Value + list21Range);
                                                                                                if (!ValidRange(list21, range21)) continue;
                                                                                                foreach (var list22 in EnumeratePermutations(Alternative[21], States.Count - list21Range - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                                {
                                                                                                    List<State> curr = new(States.Count);
                                                                                                    curr.AddRange(list[0..listRange]);
                                                                                                    curr.AddRange(list2[0..list2Range]);
                                                                                                    curr.AddRange(list3[0..list3Range]);
                                                                                                    curr.AddRange(list4[0..list4Range]);
                                                                                                    curr.AddRange(list5[0..list5Range]);
                                                                                                    curr.AddRange(list6[0..list6Range]);
                                                                                                    curr.AddRange(list7[0..list7Range]);
                                                                                                    curr.AddRange(list8[0..list8Range]);
                                                                                                    curr.AddRange(list9[0..list9Range]);
                                                                                                    curr.AddRange(list10[0..list10Range]);
                                                                                                    curr.AddRange(list11[0..list11Range]);
                                                                                                    curr.AddRange(list12[0..list12Range]);
                                                                                                    curr.AddRange(list13[0..list13Range]);
                                                                                                    curr.AddRange(list14[0..list14Range]);
                                                                                                    curr.AddRange(list15[0..list15Range]);
                                                                                                    curr.AddRange(list16[0..list16Range]);
                                                                                                    curr.AddRange(list17[0..list17Range]);
                                                                                                    curr.AddRange(list18[0..list18Range]);
                                                                                                    curr.AddRange(list19[0..list19Range]);
                                                                                                    curr.AddRange(list20[0..list20Range]);
                                                                                                    curr.AddRange(list21[0..list21Range]);
                                                                                                    curr.AddRange(list22);
                                                                                                    if (CheckPermutation(curr))
                                                                                                        yield return curr;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List21Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            int list20Range = list20.LastIndexOf(State.Damaged) + 2;
                                                                                            Range range20 = new(range19.End, range19.End.Value + list20Range);
                                                                                            if (!ValidRange(list20, range20)) continue;
                                                                                            foreach (var list21 in EnumeratePermutations(Alternative[20], States.Count - list20Range - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                            {
                                                                                                List<State> curr = new(States.Count);
                                                                                                curr.AddRange(list[0..listRange]);
                                                                                                curr.AddRange(list2[0..list2Range]);
                                                                                                curr.AddRange(list3[0..list3Range]);
                                                                                                curr.AddRange(list4[0..list4Range]);
                                                                                                curr.AddRange(list5[0..list5Range]);
                                                                                                curr.AddRange(list6[0..list6Range]);
                                                                                                curr.AddRange(list7[0..list7Range]);
                                                                                                curr.AddRange(list8[0..list8Range]);
                                                                                                curr.AddRange(list9[0..list9Range]);
                                                                                                curr.AddRange(list10[0..list10Range]);
                                                                                                curr.AddRange(list11[0..list11Range]);
                                                                                                curr.AddRange(list12[0..list12Range]);
                                                                                                curr.AddRange(list13[0..list13Range]);
                                                                                                curr.AddRange(list14[0..list14Range]);
                                                                                                curr.AddRange(list15[0..list15Range]);
                                                                                                curr.AddRange(list16[0..list16Range]);
                                                                                                curr.AddRange(list17[0..list17Range]);
                                                                                                curr.AddRange(list18[0..list18Range]);
                                                                                                curr.AddRange(list19[0..list19Range]);
                                                                                                curr.AddRange(list20[0..list20Range]);
                                                                                                curr.AddRange(list21);
                                                                                                if (CheckPermutation(curr))
                                                                                                    yield return curr;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List20Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        int list19Range = list19.LastIndexOf(State.Damaged) + 2;
                                                                                        Range range19 = new(range18.End, range18.End.Value + list19Range);
                                                                                        if (!ValidRange(list19, range19)) continue;
                                                                                        foreach (var list20 in EnumeratePermutations(Alternative[19], States.Count - list19Range - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                        {
                                                                                            List<State> curr = new(States.Count);
                                                                                            curr.AddRange(list[0..listRange]);
                                                                                            curr.AddRange(list2[0..list2Range]);
                                                                                            curr.AddRange(list3[0..list3Range]);
                                                                                            curr.AddRange(list4[0..list4Range]);
                                                                                            curr.AddRange(list5[0..list5Range]);
                                                                                            curr.AddRange(list6[0..list6Range]);
                                                                                            curr.AddRange(list7[0..list7Range]);
                                                                                            curr.AddRange(list8[0..list8Range]);
                                                                                            curr.AddRange(list9[0..list9Range]);
                                                                                            curr.AddRange(list10[0..list10Range]);
                                                                                            curr.AddRange(list11[0..list11Range]);
                                                                                            curr.AddRange(list12[0..list12Range]);
                                                                                            curr.AddRange(list13[0..list13Range]);
                                                                                            curr.AddRange(list14[0..list14Range]);
                                                                                            curr.AddRange(list15[0..list15Range]);
                                                                                            curr.AddRange(list16[0..list16Range]);
                                                                                            curr.AddRange(list17[0..list17Range]);
                                                                                            curr.AddRange(list18[0..list18Range]);
                                                                                            curr.AddRange(list19[0..list19Range]);
                                                                                            curr.AddRange(list20);
                                                                                            if (CheckPermutation(curr))
                                                                                                yield return curr;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List19Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    int list18Range = list18.LastIndexOf(State.Damaged) + 2;
                                                                                    Range range18 = new(range17.End, range17.End.Value + list18Range);
                                                                                    if (!ValidRange(list18, range18)) continue;
                                                                                    foreach (var list19 in EnumeratePermutations(Alternative[18], States.Count - list18Range - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                    {
                                                                                        List<State> curr = new(States.Count);
                                                                                        curr.AddRange(list[0..listRange]);
                                                                                        curr.AddRange(list2[0..list2Range]);
                                                                                        curr.AddRange(list3[0..list3Range]);
                                                                                        curr.AddRange(list4[0..list4Range]);
                                                                                        curr.AddRange(list5[0..list5Range]);
                                                                                        curr.AddRange(list6[0..list6Range]);
                                                                                        curr.AddRange(list7[0..list7Range]);
                                                                                        curr.AddRange(list8[0..list8Range]);
                                                                                        curr.AddRange(list9[0..list9Range]);
                                                                                        curr.AddRange(list10[0..list10Range]);
                                                                                        curr.AddRange(list11[0..list11Range]);
                                                                                        curr.AddRange(list12[0..list12Range]);
                                                                                        curr.AddRange(list13[0..list13Range]);
                                                                                        curr.AddRange(list14[0..list14Range]);
                                                                                        curr.AddRange(list15[0..list15Range]);
                                                                                        curr.AddRange(list16[0..list16Range]);
                                                                                        curr.AddRange(list17[0..list17Range]);
                                                                                        curr.AddRange(list18[0..list18Range]);
                                                                                        curr.AddRange(list19);
                                                                                        if (CheckPermutation(curr))
                                                                                            yield return curr;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List18Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                int list17Range = list17.LastIndexOf(State.Damaged) + 2;
                                                                                Range range17 = new(range16.End, range16.End.Value + list17Range);
                                                                                if (!ValidRange(list17, range17)) continue;
                                                                                foreach (var list18 in EnumeratePermutations(Alternative[17], States.Count - list17Range - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                                {
                                                                                    List<State> curr = new(States.Count);
                                                                                    curr.AddRange(list[0..listRange]);
                                                                                    curr.AddRange(list2[0..list2Range]);
                                                                                    curr.AddRange(list3[0..list3Range]);
                                                                                    curr.AddRange(list4[0..list4Range]);
                                                                                    curr.AddRange(list5[0..list5Range]);
                                                                                    curr.AddRange(list6[0..list6Range]);
                                                                                    curr.AddRange(list7[0..list7Range]);
                                                                                    curr.AddRange(list8[0..list8Range]);
                                                                                    curr.AddRange(list9[0..list9Range]);
                                                                                    curr.AddRange(list10[0..list10Range]);
                                                                                    curr.AddRange(list11[0..list11Range]);
                                                                                    curr.AddRange(list12[0..list12Range]);
                                                                                    curr.AddRange(list13[0..list13Range]);
                                                                                    curr.AddRange(list14[0..list14Range]);
                                                                                    curr.AddRange(list15[0..list15Range]);
                                                                                    curr.AddRange(list16[0..list16Range]);
                                                                                    curr.AddRange(list17[0..list17Range]);
                                                                                    curr.AddRange(list18);
                                                                                    if (CheckPermutation(curr))
                                                                                        yield return curr;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List17Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            int list16Range = list16.LastIndexOf(State.Damaged) + 2;
                                                                            Range range16 = new(range15.End, range15.End.Value + list16Range);
                                                                            if (!ValidRange(list16, range16)) continue;
                                                                            foreach (var list17 in EnumeratePermutations(Alternative[16], States.Count - list16Range - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                            {
                                                                                List<State> curr = new(States.Count);
                                                                                curr.AddRange(list[0..listRange]);
                                                                                curr.AddRange(list2[0..list2Range]);
                                                                                curr.AddRange(list3[0..list3Range]);
                                                                                curr.AddRange(list4[0..list4Range]);
                                                                                curr.AddRange(list5[0..list5Range]);
                                                                                curr.AddRange(list6[0..list6Range]);
                                                                                curr.AddRange(list7[0..list7Range]);
                                                                                curr.AddRange(list8[0..list8Range]);
                                                                                curr.AddRange(list9[0..list9Range]);
                                                                                curr.AddRange(list10[0..list10Range]);
                                                                                curr.AddRange(list11[0..list11Range]);
                                                                                curr.AddRange(list12[0..list12Range]);
                                                                                curr.AddRange(list13[0..list13Range]);
                                                                                curr.AddRange(list14[0..list14Range]);
                                                                                curr.AddRange(list15[0..list15Range]);
                                                                                curr.AddRange(list16[0..list16Range]);
                                                                                curr.AddRange(list17);
                                                                                if (CheckPermutation(curr))
                                                                                    yield return curr;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List16Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        int list15Range = list15.LastIndexOf(State.Damaged) + 2;
                                                                        Range range15 = new(range14.End, range14.End.Value + list15Range);
                                                                        if (!ValidRange(list15, range15)) continue;
                                                                        foreach (var list16 in EnumeratePermutations(Alternative[15], States.Count - list15Range - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                        {
                                                                            List<State> curr = new(States.Count);
                                                                            curr.AddRange(list[0..listRange]);
                                                                            curr.AddRange(list2[0..list2Range]);
                                                                            curr.AddRange(list3[0..list3Range]);
                                                                            curr.AddRange(list4[0..list4Range]);
                                                                            curr.AddRange(list5[0..list5Range]);
                                                                            curr.AddRange(list6[0..list6Range]);
                                                                            curr.AddRange(list7[0..list7Range]);
                                                                            curr.AddRange(list8[0..list8Range]);
                                                                            curr.AddRange(list9[0..list9Range]);
                                                                            curr.AddRange(list10[0..list10Range]);
                                                                            curr.AddRange(list11[0..list11Range]);
                                                                            curr.AddRange(list12[0..list12Range]);
                                                                            curr.AddRange(list13[0..list13Range]);
                                                                            curr.AddRange(list14[0..list14Range]);
                                                                            curr.AddRange(list15[0..list15Range]);
                                                                            curr.AddRange(list16);
                                                                            if (CheckPermutation(curr))
                                                                                yield return curr;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List15Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    int list14Range = list14.LastIndexOf(State.Damaged) + 2;
                                                                    Range range14 = new(range13.End, range13.End.Value + list14Range);
                                                                    if (!ValidRange(list14, range14)) continue;
                                                                    foreach (var list15 in EnumeratePermutations(Alternative[14], States.Count - list14Range - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                    {
                                                                        List<State> curr = new(States.Count);
                                                                        curr.AddRange(list[0..listRange]);
                                                                        curr.AddRange(list2[0..list2Range]);
                                                                        curr.AddRange(list3[0..list3Range]);
                                                                        curr.AddRange(list4[0..list4Range]);
                                                                        curr.AddRange(list5[0..list5Range]);
                                                                        curr.AddRange(list6[0..list6Range]);
                                                                        curr.AddRange(list7[0..list7Range]);
                                                                        curr.AddRange(list8[0..list8Range]);
                                                                        curr.AddRange(list9[0..list9Range]);
                                                                        curr.AddRange(list10[0..list10Range]);
                                                                        curr.AddRange(list11[0..list11Range]);
                                                                        curr.AddRange(list12[0..list12Range]);
                                                                        curr.AddRange(list13[0..list13Range]);
                                                                        curr.AddRange(list14[0..list14Range]);
                                                                        curr.AddRange(list15);
                                                                        if (CheckPermutation(curr))
                                                                            yield return curr;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List14Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                int list13Range = list13.LastIndexOf(State.Damaged) + 2;
                                                                Range range13 = new(range12.End, range12.End.Value + list13Range);
                                                                if (!ValidRange(list13, range13)) continue;
                                                                foreach (var list14 in EnumeratePermutations(Alternative[13], States.Count - list13Range - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                                {
                                                                    List<State> curr = new(States.Count);
                                                                    curr.AddRange(list[0..listRange]);
                                                                    curr.AddRange(list2[0..list2Range]);
                                                                    curr.AddRange(list3[0..list3Range]);
                                                                    curr.AddRange(list4[0..list4Range]);
                                                                    curr.AddRange(list5[0..list5Range]);
                                                                    curr.AddRange(list6[0..list6Range]);
                                                                    curr.AddRange(list7[0..list7Range]);
                                                                    curr.AddRange(list8[0..list8Range]);
                                                                    curr.AddRange(list9[0..list9Range]);
                                                                    curr.AddRange(list10[0..list10Range]);
                                                                    curr.AddRange(list11[0..list11Range]);
                                                                    curr.AddRange(list12[0..list12Range]);
                                                                    curr.AddRange(list13[0..list13Range]);
                                                                    curr.AddRange(list14);
                                                                    if (CheckPermutation(curr))
                                                                        yield return curr;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List13Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            int list12Range = list12.LastIndexOf(State.Damaged) + 2;
                                                            Range range12 = new(range11.End, range11.End.Value + list12Range);
                                                            if (!ValidRange(list12, range12)) continue;
                                                            foreach (var list13 in EnumeratePermutations(Alternative[12], States.Count - list12Range - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                            {
                                                                List<State> curr = new(States.Count);
                                                                curr.AddRange(list[0..listRange]);
                                                                curr.AddRange(list2[0..list2Range]);
                                                                curr.AddRange(list3[0..list3Range]);
                                                                curr.AddRange(list4[0..list4Range]);
                                                                curr.AddRange(list5[0..list5Range]);
                                                                curr.AddRange(list6[0..list6Range]);
                                                                curr.AddRange(list7[0..list7Range]);
                                                                curr.AddRange(list8[0..list8Range]);
                                                                curr.AddRange(list9[0..list9Range]);
                                                                curr.AddRange(list10[0..list10Range]);
                                                                curr.AddRange(list11[0..list11Range]);
                                                                curr.AddRange(list12[0..list12Range]);
                                                                curr.AddRange(list13);
                                                                if (CheckPermutation(curr))
                                                                    yield return curr;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List12Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        int list11Range = list11.LastIndexOf(State.Damaged) + 2;
                                                        Range range11 = new(range10.End, range10.End.Value + list11Range);
                                                        if (!ValidRange(list11, range11)) continue;
                                                        foreach (var list12 in EnumeratePermutations(Alternative[11], States.Count - list11Range - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                        {
                                                            List<State> curr = new(States.Count);
                                                            curr.AddRange(list[0..listRange]);
                                                            curr.AddRange(list2[0..list2Range]);
                                                            curr.AddRange(list3[0..list3Range]);
                                                            curr.AddRange(list4[0..list4Range]);
                                                            curr.AddRange(list5[0..list5Range]);
                                                            curr.AddRange(list6[0..list6Range]);
                                                            curr.AddRange(list7[0..list7Range]);
                                                            curr.AddRange(list8[0..list8Range]);
                                                            curr.AddRange(list9[0..list9Range]);
                                                            curr.AddRange(list10[0..list10Range]);
                                                            curr.AddRange(list11[0..list11Range]);
                                                            curr.AddRange(list12);
                                                            if (CheckPermutation(curr))
                                                                yield return curr;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List11Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    int list10Range = list10.LastIndexOf(State.Damaged) + 2;
                                                    Range range10 = new(range9.End, range9.End.Value + list10Range);
                                                    if (!ValidRange(list10, range10)) continue;
                                                    foreach (var list11 in EnumeratePermutations(Alternative[10], States.Count - list10Range - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                    {
                                                        List<State> curr = new(States.Count);
                                                        curr.AddRange(list[0..listRange]);
                                                        curr.AddRange(list2[0..list2Range]);
                                                        curr.AddRange(list3[0..list3Range]);
                                                        curr.AddRange(list4[0..list4Range]);
                                                        curr.AddRange(list5[0..list5Range]);
                                                        curr.AddRange(list6[0..list6Range]);
                                                        curr.AddRange(list7[0..list7Range]);
                                                        curr.AddRange(list8[0..list8Range]);
                                                        curr.AddRange(list9[0..list9Range]);
                                                        curr.AddRange(list10[0..list10Range]);
                                                        curr.AddRange(list11);
                                                        if (CheckPermutation(curr))
                                                            yield return curr;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List10Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                int list9Range = list9.LastIndexOf(State.Damaged) + 2;
                                                Range range9 = new(range8.End, range8.End.Value + list9Range);
                                                if (!ValidRange(list9, range9)) continue;
                                                foreach (var list10 in EnumeratePermutations(Alternative[9], States.Count - list9Range - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                                {
                                                    List<State> curr = new(States.Count);
                                                    curr.AddRange(list[0..listRange]);
                                                    curr.AddRange(list2[0..list2Range]);
                                                    curr.AddRange(list3[0..list3Range]);
                                                    curr.AddRange(list4[0..list4Range]);
                                                    curr.AddRange(list5[0..list5Range]);
                                                    curr.AddRange(list6[0..list6Range]);
                                                    curr.AddRange(list7[0..list7Range]);
                                                    curr.AddRange(list8[0..list8Range]);
                                                    curr.AddRange(list9[0..list9Range]);
                                                    curr.AddRange(list10);
                                                    if (CheckPermutation(curr))
                                                        yield return curr;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List9Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            int list8Range = list8.LastIndexOf(State.Damaged) + 2;
                                            Range range8 = new(range7.End, range7.End.Value + list8Range);
                                            if (!ValidRange(list8, range8)) continue;
                                            foreach (var list9 in EnumeratePermutations(Alternative[8], States.Count - list8Range - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                            {
                                                List<State> curr = new(States.Count);
                                                curr.AddRange(list[0..listRange]);
                                                curr.AddRange(list2[0..list2Range]);
                                                curr.AddRange(list3[0..list3Range]);
                                                curr.AddRange(list4[0..list4Range]);
                                                curr.AddRange(list5[0..list5Range]);
                                                curr.AddRange(list6[0..list6Range]);
                                                curr.AddRange(list7[0..list7Range]);
                                                curr.AddRange(list8[0..list8Range]);
                                                curr.AddRange(list9);
                                                if (CheckPermutation(curr))
                                                    yield return curr;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List8Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        int list7Range = list7.LastIndexOf(State.Damaged) + 2;
                                        Range range7 = new(range6.End, range6.End.Value + list7Range);
                                        if (!ValidRange(list7, range7)) continue;
                                        foreach (var list8 in EnumeratePermutations(Alternative[7], States.Count - list7Range - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                        {
                                            List<State> curr = new(States.Count);
                                            curr.AddRange(list[0..listRange]);
                                            curr.AddRange(list2[0..list2Range]);
                                            curr.AddRange(list3[0..list3Range]);
                                            curr.AddRange(list4[0..list4Range]);
                                            curr.AddRange(list5[0..list5Range]);
                                            curr.AddRange(list6[0..list6Range]);
                                            curr.AddRange(list7[0..list7Range]);
                                            curr.AddRange(list8);
                                            if (CheckPermutation(curr))
                                                yield return curr;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List7Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
                                foreach (var list6 in EnumeratePermutations(Alternative[5], States.Count - listRange - list2Range - list3Range - list4Range - list5Range))
                                {
                                    int list6Range = list6.LastIndexOf(State.Damaged) + 2;
                                    Range range6 = new(range5.End, range5.End.Value + list6Range);
                                    if (!ValidRange(list6, range6)) continue;
                                    foreach (var list7 in EnumeratePermutations(Alternative[6], States.Count - listRange - list2Range - list3Range - list4Range - list5Range - list6Range))
                                    {
                                        List<State> curr = new(States.Count);
                                        curr.AddRange(list[0..listRange]);
                                        curr.AddRange(list2[0..list2Range]);
                                        curr.AddRange(list3[0..list3Range]);
                                        curr.AddRange(list4[0..list4Range]);
                                        curr.AddRange(list5[0..list5Range]);
                                        curr.AddRange(list6[0..list6Range]);
                                        curr.AddRange(list7);
                                        if (CheckPermutation(curr))
                                            yield return curr;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public IEnumerable<List<State>> List6Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
                            {
                                int list5Range = list5.LastIndexOf(State.Damaged) + 2;
                                Range range5 = new(range4.End, range4.End.Value + list5Range);
                                if (!ValidRange(list5, range5)) continue;
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
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
                        foreach (var list4 in EnumeratePermutations(Alternative[3], States.Count - listRange - list2Range - list3Range))
                        {
                            int list4Range = list4.LastIndexOf(State.Damaged) + 2;
                            Range range4 = new(range3.End, range3.End.Value + list4Range);
                            if (!ValidRange(list4, range4)) continue;
                            foreach (var list5 in EnumeratePermutations(Alternative[4], States.Count - listRange - list2Range - list3Range - list4Range))
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
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
                    foreach (var list3 in EnumeratePermutations(Alternative[2], States.Count - listRange - list2Range))
                    {
                        int list3Range = list3.LastIndexOf(State.Damaged) + 2;
                        Range range3 = new(range2.End, range2.End.Value + list3Range);
                        if (!ValidRange(list3, range3)) continue;
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
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
                foreach (var list2 in EnumeratePermutations(Alternative[1], States.Count - listRange))
                {
                    int list2Range = list2.LastIndexOf(State.Damaged) + 2;
                    Range range2 = new(range.End, range.End.Value + list2Range);
                    if (!ValidRange(list2, range2)) continue;
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
                int listRange = list.LastIndexOf(State.Damaged) + 2;
                Range range = new(0, listRange);
                if (!ValidRange(list, range)) continue;
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

        public long CountPermutations(int index, int length, Range lastRange)
        {
            long count = 0;
            if (index == Alternative.Count - 1)
            {
               // long count = 0;
                Range range = new(lastRange.End, States.Count);
                foreach (var list in EnumeratePermutations(Alternative[index], length))
                {
                    if (!ValidRange(list, range)) continue;
                    count++;
                }
                //return count;
            }
            else
            {
                foreach (var list in EnumeratePermutations(Alternative[index], length))
                {
                    int list3Range = list.LastIndexOf(State.Damaged) + 2;
                    Range range3 = new(lastRange.End, lastRange.End.Value + list3Range);
                    if (!ValidRange(list, range3)) continue;
                    count += CountPermutations(index + 1, length - list3Range, range3);
                }
            }

            return count;
        }

        public long CountPermutations()
        {
            long count = 0;
            return CountPermutations(0, States.Count, new Range(0, 0));
        }

        public IEnumerable<List<State>> List1Permutations()
        {
            foreach (var list in EnumeratePermutations(Alternative[0], States.Count))
            {
                if (CheckPermutation(list))
                    yield return list;
            }
        }
    }
}
