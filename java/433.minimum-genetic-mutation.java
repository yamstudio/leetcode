/*
 * @lc app=leetcode id=433 lang=java
 *
 * [433] Minimum Genetic Mutation
 *
 * autogenerated using scripts/convert.py
 */
import java.util.HashSet;
import java.util.Arrays;
import java.util.Queue;
import java.util.LinkedList;

public class Solution {
    public int minMutation(String start, String end, String[] bank) {
        HashSet<String> set = new HashSet<String>(Arrays.asList(bank));
        char[] genes = new char[]{'A', 'C', 'G', 'T'};
        Queue<String> queue = new LinkedList<String>();
        StringBuilder mutation;
        String curr, mutationString;
        int i, j, ret = 0, size, len = start.length();
        
        if (! set.contains(end))
            return -1;
        queue.add(start);
        if (set.contains(start))
            set.remove(start);
        
        while ((size = queue.size()) != 0) {
            for (i = 0; i < size; ++i) {
                curr = queue.poll();
                
                for (j = 0; j < len; ++j) {
                    mutation = new StringBuilder(curr);
                    
                    for (char c : genes) {
                        mutation.setCharAt(j, c);
                        mutationString = mutation.toString();
                        
                        if (set.contains(mutationString)) {
                            if (mutationString.equals(end))
                                return ret + 1;
                            else {
                                set.remove(mutationString);
                                queue.add(mutationString);
                            }
                        }
                    }
                }
            }
            
            ++ret;
        }
        
        return -1;
    }
}
