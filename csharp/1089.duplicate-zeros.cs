/*
 * @lc app=leetcode id=1089 lang=csharp
 *
 * [1089] Duplicate Zeros
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public void DuplicateZeros(int[] arr) {
        bool flag = false;
        int n = arr.Length;
        var queue = new Queue<int>();
        for (int i = 0; i < n; ++i) {
            queue.Enqueue(arr[i]);
            if (flag) {
                arr[i] = 0;
                flag = false;
                continue;
            }
            int c = queue.Dequeue();
            if (c == 0) {
                flag = true;
            }
            arr[i] = c;
        }
    }
}
// @lc code=end

