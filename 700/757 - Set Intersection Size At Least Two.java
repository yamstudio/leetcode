import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class Solution {
    public int intersectionSizeTwo(int[][] intervals) {
        List<Integer> s = new ArrayList<>();
        s.add(-1);
        s.add(-1);
        
        Arrays.sort(intervals, (int[] a, int[] b) -> {
            return (a[1] > b[1] || (a[1] == b[1] && a[0] < b[0])) ? 1 : -1;
        });
        
        for (int[] i : intervals) {
            int len = s.size();
            if (i[0] <= s.get(len - 2)) {
                continue;
            }
            
            if (i[0] > s.get(len - 1)) {
                s.add(i[1] - 1);
            }
            s.add(i[1]);
        }

        return s.size() - 2;
    }
}