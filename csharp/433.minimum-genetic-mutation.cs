/*
 * @lc app=leetcode id=433 lang=csharp
 *
 * [433] Minimum Genetic Mutation
 */

using System.Collections.Generic;

public class Solution {

    private static char[] chars = new char[] { 'A', 'C', 'T', 'G' };

    public int MinMutation(string start, string end, string[] bank) {
        ISet<string> set = new HashSet<string>(bank), visited = new HashSet<string>();
        Queue<string> queue = new Queue<string>();
        int change = 0;
        queue.Enqueue(start);
        while (queue.Count > 0) {
            int count = queue.Count;
            while (count-- > 0) {
                string curr = queue.Dequeue();
                if (curr == end) {
                    return change;
                }
                char[] array = curr.ToCharArray();
                for (int i = 0; i < 8; ++i) {
                    char c = array[i];
                    foreach (char n in chars) {
                        if (c == n) {
                            continue;
                        }
                        array[i] = n;
                        string next = new string(array);
                        if (visited.Contains(next) || !set.Contains(next)) {
                            continue;
                        }
                        queue.Enqueue(next);
                        visited.Add(next);
                    }
                    array[i] = c;
                }
            }
            ++change;
        }
        return -1;
    }
}

