﻿using AdventOfCode2020;
using NUnit.Framework;
using System.Linq;

namespace UnitTests
{
    public class Day10Tests
    {
        [Test]
        public void SolvePart1WithTestInput()
        {
            var testInput = @"16
10
15
5
1
11
7
19
6
12
4".Split("\r\n");
            var answer = Day10.UseAll(0,0,Day10.ParseAdapters(testInput),0);
            Assert.AreEqual(7 * 5, answer);
        }

        [Test]
        public void SolvePart1WithTestInput2()
        {
            var testInput = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3".Split("\r\n");
            var answer = Day10.UseAll(0, 0, Day10.ParseAdapters(testInput), 0);
            Assert.AreEqual(220, answer);
        }


        [Test]
        public void SolvePart2WithTestInput()
        {
            var testInput = @"16
10
15
5
1
11
7
19
6
12
4".Split("\r\n");
            var answer = Day10.CountCombinations(Day10.ParseAdapters(testInput));
            Assert.AreEqual(8, answer);
        }

        [Test]
        public void SolvePart2WithTestInput2()
        {
            var testInput = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3".Split("\r\n");
            var answer = Day10.CountCombinations(Day10.ParseAdapters(testInput));
            Assert.AreEqual(19208, answer);
        }

        [TestCase("1,2,3,4", 7)]
        public void CountCombinations(string input, long expected)
        {
            var adapters  = input.Split(',').Select(j => new Day10.Adapter(int.Parse(j))).ToList();
            var answer = Day10.CountCombinations(adapters);
            Assert.AreEqual(expected, answer);
        }
    }
}