import java.util.TreeMap;
import java.util.Map;

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
    public int[] findRightInterval(Interval[] intervals) {
        int[] ret = new int[intervals.length];
        TreeMap<Integer, Integer> tm = new TreeMap<Integer, Integer>();
        Map.Entry<Integer, Integer> found;
        int i, count = 0;
        
        for (i = 0; i < intervals.length; ++i)
            tm.put(intervals[i].start, i);
        
        
        for (Interval v : intervals) {
            if ((found = tm.ceilingEntry(v.end)) == null)
                ret[count++] = -1;
            else
                ret[count++] = found.getValue();
        }
        
        return ret;
    }
}
