import java.util.ArrayList;

public class Solution {
    public int[] findOrder(int numCourses, int[][] prerequisites) {
        List<List<Integer>> prereq;
        List<Integer> curr, temp;
        int[] isVisited, ret;
        int i;
        
        if (numCourses == 0)
            return null;
        prereq = new ArrayList<List<Integer>>(numCourses);
        isVisited = new int[numCourses];
        temp = new ArrayList<Integer>(numCourses);
        
        for (i = 0; i < numCourses; ++i)
            prereq.add(null);
        
        for (int[] pair : prerequisites) {
            if ((curr = prereq.get(pair[0])) == null) {
                curr = new ArrayList<Integer>();
                prereq.set(pair[0], curr);
            }
            curr.add(pair[1]);
        }
        
        for (i = 0; i < numCourses; ++i) {
            if (! depthFirstSearch(prereq, isVisited, i, temp))
                return new int[0];
        }
        
        ret = new int[numCourses];
        for (i = 0; i < numCourses; ++i)
            ret[i] = temp.get(i).intValue();
        
        return ret;
    }
    
    private boolean depthFirstSearch(List<List<Integer>> prereq, int[] isVisited, int index, List<Integer> temp) {
        if (isVisited[index] == 2)
            return true;
        if (isVisited[index] == 1)
            return false;
        
        if (prereq.get(index) != null) {
            isVisited[index] = 1;
            for (int p : prereq.get(index)) {
                if (! depthFirstSearch(prereq, isVisited, p, temp))
                    return false;
            }
        }
        
        isVisited[index] = 2;
        temp.add(index);
        return true;
    }
}
