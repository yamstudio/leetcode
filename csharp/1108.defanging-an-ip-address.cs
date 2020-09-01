/*
 * @lc app=leetcode id=1108 lang=csharp
 *
 * [1108] Defanging an IP Address
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static IEnumerable<char> GetChars(string address) {
        foreach (char c in address) {
            if (c == '.') {
                yield return '[';
                yield return '.';
                yield return ']';
                continue;
            }
            yield return c;
        }
    } 

    public string DefangIPaddr(string address) {
        return new string(GetChars(address).ToArray());
    }
}
// @lc code=end

