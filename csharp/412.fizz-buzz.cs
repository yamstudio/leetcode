/*
 * @lc app=leetcode id=412 lang=csharp
 *
 * [412] Fizz Buzz
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<string> FizzBuzz(int n) {
        return new List<string>(Enumerable.Range(1, n).Select(x => {
            bool three = x % 3 == 0, five = x % 5 == 0;
            return three ?
                (five ? "FizzBuzz" : "Fizz") :
                (five ? "Buzz" : x.ToString());
        }));
    }
}

