/*
 * @lc app=leetcode id=414 lang=csharp
 *
 * [414] Third Maximum Number
 */

using System.Collections.Generic;

public class Solution {
    public int ThirdMax(int[] nums) {
        IList<int> max = new List<int>(3);
        foreach (int num in nums) {
            int i;
            bool flag = false;
            for (i = 0; i < max.Count; ++i) {
                if (max[i] < num) {
                    break;
                } else if (max[i] == num) {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                continue;
            }
            if (max.Count < 3) {
                max.Insert(i, num);
            } else {
                if (i < max.Count) {
                    max.RemoveAt(2);
                    max.Insert(i, num);
                }
            }
        }
        return max[max.Count == 3 ? 2 : 0];
    }
}

