import java.util.regex.Pattern;
import java.util.regex.Matcher;

class Solution {
    public int[] exclusiveTime(int n, List<String> logs) {
        Pattern p = Pattern.compile("([0-9]+):([a-z]+):([0-9]+)");
        Matcher m;
        Stack<Integer> stack = new Stack<Integer>();
        int id, time, i, prev = 0, top;
        int[] ret = new int[n];
        
        for (String l : logs) {
            m = p.matcher(l);
            m.find();
            id = Integer.valueOf(m.group(1));
            time = Integer.valueOf(m.group(3));
            
            if (! stack.isEmpty())
                ret[stack.peek()] += time - prev;
            prev = time;
            
            if (m.group(2).equals("start"))
                stack.push(id);
            else {
                ret[stack.pop()]++;
                prev++;
            }
        }
        
        return ret;
    }
}
