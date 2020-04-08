/*
 * @lc app=leetcode id=855 lang=csharp
 *
 * [855] Exam Room
 */

using System.Collections.Generic;

// @lc code=start
public class ExamRoom {

    private int Count;
    private SortedSet<int> Sorted;

    public ExamRoom(int N) {
        Sorted = new SortedSet<int>();
        Count = N;
    }
    
    public int Seat() {
        int max = 0, pos = 0, prev = -1;
        foreach (int student in Sorted) {
            if (prev < 0) {
                max = student;
            } else {
                int dist = (student - prev) / 2;
                if (dist > max) {
                    max = dist;
                    pos = prev + dist;
                }
            }
            prev = student;
        }
        if (prev >= 0 && Count - prev - 1 > max) {
            pos = Count - 1;
        }
        Sorted.Add(pos);
        return pos;
    }
    
    public void Leave(int p) {
        Sorted.Remove(p);
    }
}

/**
 * Your ExamRoom object will be instantiated and called as such:
 * ExamRoom obj = new ExamRoom(N);
 * int param_1 = obj.Seat();
 * obj.Leave(p);
 */
// @lc code=end

