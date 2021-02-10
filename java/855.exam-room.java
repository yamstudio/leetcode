/*
 * @lc app=leetcode id=855 lang=java
 *
 * [855] Exam Room
 */

// @lc code=start
class ExamRoom {

    private int n;
    private Set<Integer> sorted;

    public ExamRoom(int N) {
        n = N;
        sorted = new TreeSet<Integer>();
    }
    
    public int seat() {
        int ret = 0, max = 0, prev = -1;
        for (int s : sorted) {
            if (prev == -1) {
                max = s;
            } else {
                int d = (s - prev) / 2;
                if (d > max) {
                    max = d;
                    ret = prev + d;
                }
            }
            prev = s;
        }
        if (prev != -1 && n - 1 - prev > max) {
            ret = n - 1;
        }
        sorted.add(ret);
        return ret;
    }
    
    public void leave(int p) {
        sorted.remove(p);
    }
}

/**
 * Your ExamRoom object will be instantiated and called as such:
 * ExamRoom obj = new ExamRoom(N);
 * int param_1 = obj.seat();
 * obj.leave(p);
 */
// @lc code=end

