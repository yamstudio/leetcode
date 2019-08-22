/*
 * @lc app=leetcode id=275 lang=csharp
 *
 * [275] H-Index II
 */
public class Solution {
    public int HIndex(int[] citations) {
        int n = citations.Length, left = 0, right = n - 1;
        while (left <= right) {
            int mid = (left + right) / 2, h = n - mid;
            if (h == citations[mid]) {
                return h;
            } else if (h < citations[mid]) {
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return n - left;
    }
}

