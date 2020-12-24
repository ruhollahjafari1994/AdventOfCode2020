# Advent of Code 2020 

This project contains solutions to the [Advent of Code](https://adventofcode.com/) puzzles for 2020 in C#.

In previous years I have used these puzzles to improve my skills in other languages (F#, JavaScript), or to apply functional programming principles.

This year I am using it to help one of my children with his programming skills. He's solving them in Python and I'm letting him watch me solve them in C#. So the solutions this year aren't necessarily going to be very "clever" in terms of doing things in the shortest way. Instad I'm focusing on making the coding techniques understandable for a beginner (although refactoring some of the answers afterwards to show more advanced techniques).

Note - this does mean I might not complete this year's puzzles. Advent of Code does have a habit of getting quite tricky by the end!

Some notes on each day's solution.

- **Day 1** presented an ideal opportunity to use [MoreLinq's Subsets method](https://markheath.net/post/exploring-morelinq-4-combinations), and the whole solution is easily achieved in a single LINQ expression by also using `Aggregate` to multiply the terms together. One trick here was to remember to use `long` instead of `int` to avoid an overflow.
- **Day 2** gave me a chance to introduce my son to Regular Expressions. I stared by showing some ways we could parse the input line just by string splitting, and then we saw how Regex can help. Personally I find C#'s Regex class a bit fiddly to work with so probably could do with creating some helper extension methods. Also, today's puzzle was a rare chance to use the C# exclusive or (`^`) operator.
- **Day 3** gave a chance to introduce the concept of Tuples and also put modulo arithmetic to use. It's another one that could be turned nicely into a single LINQ query, with MoreLinq's Scan method probably being a good candidate, but I wanted to keep it understandable. It also showed the value of breaking the solution up into a few smaller helper functions, which could be tested individually.
- **Day 4** again highlighted the power of Regex, and there were some other interesting topics this puzzle raised. First was the need to batch input rows together (which again MoreLinq could have helped with), but I did more simply with the yield statement. The trick is not to accidentally forget the first batch. The second issue is whether this problem deserves it's own `Passport` C# class, allowing it to own its own validation logic, which would be a better approach in an enterprise application, rather than just using a `Dictionary<string,string>` to hold the state. The code for this day certainly could do with some cleaning up!
- **Day 5** I started out writing some long-hand code with a switch statement to perform the binary split. This was a pain to get right as it's easy to get off by one errors when chopping the range in half. But a eureka moment ensued when I realised the input was just a binary number and a bit of string replacement took me straight to the answer. This was also a good opportunity to introduce concept of `HashSet`, and to use a parameterized unit test.
- **Day 6** Relatively simple, but needed the same batching logic from day 4 to split input lines into batches separated by empty strings. So I introduced MoreLinq's `Split` method which s ideal for this (and back-ported it into day 4's solution). The initial solution I used for day 6 used HashSets to track all answers, but a bit of refactoring turned it into a simple LINQ expression for each part.
- **Day 7** involved some recursion and a tree structure. As usual I made a bit of a meal of solving this type of problem. I decided some strongly typed classes would help me not get confused by creating complicated dictionaries of lists of tuples. Once I'd done that a couple of recursive functions revealed the answer quite quickly, but my solution for this day could certainly do with some cleaning up.
- **Day 8** was a classic Advent of Code problem - parsing and executing some machine code instructions. For this puzzle a simple `Instruction` class and a method to execute the program sufficed, but I can imagine needing to build on this for future puzzles. My solutions this year so far haven't made a great effort to follow functional programming techniques and use immutable data structures, and today's challenge was easily solved by mutating the program directly.
- **Day 9** was relatively kind and could be solved with some simple for loops. I used MoreLinq's Subset again which was really helpful for part 1. Today's was a good example of a problem where each part *could* be solved in a single LINQ statement but it was quicker and easier to write out with loops, and arguably easier to understand. Still it will be interesting to see how others have solved this one.
- **Day 10** - true to form, we were given a puzzle that was technically "easy" but needed optimization to prevent it from being extremely slow. I over-complicated part 1 at first with recursion, and refactored to a simple solution using MoreLinq's `Pairwise`. Part 2 required me stepping away from the computer to get the algorithm clear in my head. Then unit tests proved valuable in helping me troubleshoot it with a very simple test case.
- **Day 11** - was a nice puzzle based on Conway's Game of Life. Part 2 pushed me to make my solution a bit more functional for the adjacency counting than it was previously, and I used MoreLinq's handy `Generate` method.
- **Day 12** - was a good example of a puzzle where LINQ's `Aggregate` method is more than sufficient to apply the instructions and track the state.
- **Day 13** - part 1 was nice and easy to solve with LINQ. Part 2 could be solved brute force but was way too slow. I ended up needing some help to get it optimized. Aparrently Chinese Remainder Theorem can be applied to this puzzle.
- **Day 14** - fun with bitmasks. Not especially hard, but I managed to get my ANDs and ORs muddled up enough for this to take me a while. Haven't had a chance to clean up the code yet.
- **Day 15** - a relatively kind problem, and yet easy to make mistakes, so the unit tests helped. I realised in part 1 that I could solve the puzzle without remembering the entire sequence history, although it did make for a slightly clumsy algorithm, storing the previous number only after the next one had been emitted. It paid dividends, as my solution worked just fine for part 2 without need for modification. However, I suspect there is another level of optimization possible here, as my solution takes 3 seconds. At a guess, the sequence probably repeats after a predictable number of iterations, so you don't have to go loop for so long to get part 2's solution.
- **Day 16** - in this problem we end up having to build a constraint solver. I'm sure there are much more elegant ways to do it than I came up with, but pleased I managed to solve this at all. Creating some strongly typed classes was also valuable for helping me to understand my own code!
- **Day 17** - this was a nice puzzle that took day 11's Conway's game of life themed challenge and applied it to extra dimensions. I used a `HashSet` to sparsely store cells, with tuples as the keys. The limitations of C#'s tuple type though meant it was hard to write very generic code (Tuple is not enumerable unfortunately)
- **Day 18** - part 1 will have been trivial for any language with a built-in eval function. For part 2, I chose to tokenize the equation (should really have done that for part 1), and then recursively solve subequations and replace highest priority operands. Could undoubtedly be made a lot more succinct.
- **Day 19** - I was fairly pleased with my solution to part 1, and in theory it could have been extended quite well to part 2, as I hadn't taken the "easy" option of using regex or pre-calculating all possible matches for part 1. However, after a while trying to weed out bugs, I ran out of the time I had allocated, and had to eat humble pie and get help. I found a really nice Python solution that took a fairly similar approach to my code, and ported it to C#. Hopefully I can find time to clean it up a bit further to align with my approach.
- **Day 20** - I found the first part quite easy, "solving" the whole jigsaw and making it easy to find the corner pieces. However, my solver didn't actually track what orientation each piece was in, so when I saw how complex part 2 was, I soon realized that I was in for hours of coding to finish the task. Sadly I lacked the time, so I decided once again to swallow my pride and learn from someone else's solution. There was a really nice C# solution that I used to get my second star, but part 2 is definitely one I'd like to return to at some point and see if I can make my approach work.
- **Day 21** - Another one where part 1 was easy and I got unstuck in part 2. This time though I was convinced my solution ought to work, but just couldn't get it done. In the end, I compared my answer with someone else's and it revealed two silly bugs - one was swapping allergens for ingredients (F#'s elegant type system could have protected me from that), and the other more subtle one was that I should have copied a HashSet rather than referencing it (again F# would have prevented that mistake).
- **Day 22** - part 1 was relatively simple, and was a good use case for queues. I was short on time, and part 2 looked quite involved so I've yet to tackle that.
- **Day 23** - a kinder puzzle today. Part 1 could be solved elegantly with linked lists (not sure why I made a doubly linked list - didn't need it in the end). Part 2 was also "easy" to solve, but would be horribly slow. I realised a dictionary would be much faster than my `Find` method that iterated through the list, and that turned out to be pretty much all I needed - going from probably hours to 4 seconds. I did then get it down to 2 seconds with a bit more optimisation.
- **Day 24** - I enjoyed today's puzzle. The main difficulty in part 1 would have been coming up with a hexagonal coordinate system, but thankfully that's [a problem I've tackled before](https://markheath.net/post/advent-of-code-2017-day-11). And part 2 was also about reuse as essentially we were playing Conway's game of life again. I hadn't built a generic solver, but the approach was the same as previous days. If I get the chance I'd like to rewrite today's solution to be more functional, as it lends itself well to that approach.