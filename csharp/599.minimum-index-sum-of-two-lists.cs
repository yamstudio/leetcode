/*
 * @lc app=leetcode id=599 lang=csharp
 *
 * [599] Minimum Index Sum of Two Lists
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string[] FindRestaurant(string[] list1, string[] list2) {
        IDictionary<string, int> map = new Dictionary<string, int>();
        for (int i = 0; i < list1.Length; ++i) {
            map[list1[i]] = i;
        }
        IList<string> ret = new List<string>();
        int curr = int.MaxValue;
        for (int i = 0; i < list2.Length; ++i) {
            int sum;
            string s = list2[i];
            if (map.TryGetValue(s, out sum)) {
                sum += i;
                if (sum < curr) {
                    ret.Clear();
                    ret.Add(s);
                    curr = sum;
                } else if (sum == curr) {
                    ret.Add(s);
                }
            }
        }
        return ret.ToArray();
    }
}
// @lc code=end

