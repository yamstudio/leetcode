import java.util.ArrayList;

/**
 * Definition for an interval.
 * public class Interval {
 *     int start;
 *     int end;
 *     Interval() { start = 0; end = 0; }
 *     Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public List<Interval> insert(List<Interval> intervals, Interval newInterval) {
        int i = 0;
        Interval curr;
        boolean flag = false;
        List<Interval> ret = new ArrayList<Interval>();

        while (i < intervals.size() && ! flag) {
            curr = intervals.get(i);
            if (newInterval.end < curr.start) {
                flag = true;
                ret.add(newInterval);
                ret.add(curr);
            } else if (newInterval.start <= curr.end && curr.start <= newInterval.end) {
                newInterval.start = Math.min(newInterval.start, curr.start);
                newInterval.end = Math.max(newInterval.end, curr.end);
            } else {
                ret.add(curr);
            }
            ++i;
        }
        
        if (flag) {
            for (; i < intervals.size(); ++i)
                ret.add(intervals.get(i));
        } else
            ret.add(newInterval);
        
        return ret;
    }
}
