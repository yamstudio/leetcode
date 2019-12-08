/*
 * @lc app=leetcode id=731 lang=csharp
 *
 * [731] My Calendar II
 */

using System.Collections.Generic;

// @lc code=start
public class MyCalendarTwo {

    private SortedList<int, int> Sorted;

    public MyCalendarTwo() {
        Sorted = new SortedList<int, int>();
    }
    
    public bool Book(int start, int end) {
        int count = 0;
        Sorted.TryGetValue(start, out int startCount);
        Sorted.TryGetValue(end, out int endCount);
        Sorted[start] = 1 + startCount;
        Sorted[end] = -1 + endCount;
        bool flag = true;
        foreach (var c in Sorted.Values) {
            count += c;
            if (count == 3) {
                flag = false;
                break;
            }
        }
        if (!flag) {
            Sorted[start] = startCount;
            Sorted[end] = endCount;
        }
        return flag;
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */
// @lc code=end

