import java.util.HashSet;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Set;

class Solution {
    public int openLock(String[] deadends, String target) {
        int ret = 0;

        Set<String> visited = new HashSet<>();
        for (String s : deadends) {
            visited.add(s);
        }
        
        if (visited.contains("0000")) {
            return -1;
        } else if (target.equals("0000")) {
            return 0;
        }
        Queue<String> q = new LinkedList<>();
        
        visited.add("0000");
        q.offer("0000");
        
        while (!q.isEmpty()) {
            ++ret;

            int count = q.size();
            while (count-- > 0) {
                String curr = q.poll();
                
                for (int i = 0; i < 4; ++i) {
                    char c = curr.charAt(i);
                    String a = curr.substring(0, i), b = curr.substring(i + 1);

                    String prev = a + (char) (c == '0' ? '9' : c - 1) + b;
                    String next = a + (char) (c == '9' ? '0' : c + 1) + b;
                    if (prev.equals(target) || next.equals(target)) {
                        return ret;
                    }
                    
                    if (!visited.contains(prev)) {
                        visited.add(prev);
                        q.offer(prev);
                    }
                    
                    if (!visited.contains(next)) {
                        visited.add(next);
                        q.offer(next);
                    }
                }
            }
        }
        
        return -1;
    }
}