/*
 * @lc app=leetcode id=729 lang=csharp
 *
 * [729] My Calendar I
 */

using System.Collections.Generic;

// @lc code=start
public class MyCalendar {

    private SortedList<int, int> Sorted;

    public MyCalendar() {
        Sorted = new SortedList<int, int>();
        Sorted[int.MinValue] = int.MinValue;
        Sorted[int.MaxValue] = int.MaxValue;
    }
    
    public bool Book(int start, int end) {
        int n = Sorted.Count, left = 0, right = n;
        while (left < right) {
            int mid = (left + right) / 2;
            if (Sorted.Keys[mid] <= start) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        if (Sorted.Keys[left] < end || Sorted.Values[left - 1] > start) {
            return false;
        }
        Sorted[start] = end;
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */
// @lc code=end

