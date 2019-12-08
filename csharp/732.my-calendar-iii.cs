/*
 * @lc app=leetcode id=732 lang=csharp
 *
 * [732] My Calendar III
 */

// @lc code=start
public class MyCalendarThree {

    private SortedList<int, int> Sorted;

    public MyCalendarThree() {
        Sorted = new SortedList<int, int>();
    }
    
    public int Book(int start, int end) {
        int count = 0, ret = 0;
        Sorted.TryGetValue(start, out int startCount);
        Sorted.TryGetValue(end, out int endCount);
        Sorted[start] = 1 + startCount;
        Sorted[end] = -1 + endCount;
        foreach (var c in Sorted.Values) {
            count += c;
            ret = Math.Max(ret, count);
        }
        return ret;
    }
}

/**
 * Your MyCalendarThree object will be instantiated and called as such:
 * MyCalendarThree obj = new MyCalendarThree();
 * int param_1 = obj.Book(start,end);
 */
// @lc code=end

