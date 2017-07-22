import java.util.ArrayList;

public class Solution {
    public boolean canFinish(int numCourses, int[][] prerequisites) {
        List<List<Integer>> prereq;
        List<Integer> curr;
        int[] isVisited;
        int i;
        
        if (numCourses == 0)
            return true;
        System.out.println(numCourses);
        prereq = new ArrayList<List<Integer>>(numCourses);
        isVisited = new int[numCourses];
        
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
            if (! depthFirstSearch(prereq, isVisited, i))
                return false;
        }
        
        return true;
    }
    
    private boolean depthFirstSearch(List<List<Integer>> prereq, int[] isVisited, int index) {
        if (isVisited[index] == 2 || prereq.get(index) == null)
            return true;
        if (isVisited[index] == 1)
            return false;
        isVisited[index] = 1;
        for (int p : prereq.get(index)) {
            if (! depthFirstSearch(prereq, isVisited, p))
                return false;
        }
        isVisited[index] = 2;
        return true;
    }
}
