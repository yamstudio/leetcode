import java.util.ArrayList;
import java.util.Comparator;

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
    public List<Interval> merge(List<Interval> intervals) {
        List<Interval> ret = new ArrayList<Interval>();
        Interval curr;
        int s, e, i;

        if (intervals.size() > 0) {
            Collections.sort(intervals, new IntervalComparator());
            curr = intervals.get(0);
            s = curr.start;
            e = curr.end;
            for (i = 1; i < intervals.size(); ++i) {
                curr = intervals.get(i);
                if (curr.start <= e) {
                    e = Math.max(e, curr.end);
                } else {
                    ret.add(new Interval(s, e));
                    s = curr.start;
                    e = curr.end;
                }
            }
            ret.add(new Interval(s, e));
        }
        
        return ret;
    }
    
    private class IntervalComparator implements Comparator<Interval> {
        @Override
        public int compare(Interval f, Interval s) {
            return f.start - s.start;
        }
    }
}
