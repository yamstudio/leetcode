/*
 * @lc app=leetcode id=854 lang=csharp
 *
 * [854] K-Similar Strings
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int KSimilarity(string A, string B) {
        if (A == B) {
            return 0;
        } 
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        int ret = 1, n = A.Length;
        visited.Add(A);
        queue.Enqueue(A);
        while (true) {
            for (int k = queue.Count; k > 0; --k) {
                var curr = queue.Dequeue();
                var arr = curr.ToCharArray();
                int i = 0;
                while (arr[i] == B[i]) {
                    ++i;
                }
                char c = arr[i], tc = B[i];
                for (int j = i + 1; j < n; ++j) {
                    if (arr[j] == B[j] || arr[j] != tc) {
                        continue;
                    }
                    arr[i] = arr[j];
                    arr[j] = c;
                    var next = new string(arr);
                    if (next == B) {
                        return ret;
                    }
                    if (visited.Add(next)) {
                        queue.Enqueue(next);
                    }
                    arr[j] = arr[i];
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

