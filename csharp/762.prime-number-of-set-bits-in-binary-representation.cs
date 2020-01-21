/*
 * @lc app=leetcode id=762 lang=csharp
 *
 * [762] Prime Number of Set Bits in Binary Representation
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static HashSet<int> Primes = new HashSet<int> {
        2, 3, 5, 7, 11, 13, 17, 19
    };

    public int CountPrimeSetBits(int L, int R) {
        return Enumerable
            .Range(L, R - L + 1)
            .Select(num => {
                int count = 0;
                while (num != 0) {
                    if ((num & 1) == 1) {
                        ++count;
                    }
                    num >>= 1;
                }
                return count;
            })
            .Where(count => Primes.Contains(count))
            .Count();
    }
}
// @lc code=end

