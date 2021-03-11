/*
 * @lc app=leetcode id=911 lang=java
 *
 * [911] Online Election
 */

// @lc code=start
class TopVotedCandidate {

    private Map<Integer, Integer> map;
    private int[] times;

    public TopVotedCandidate(int[] persons, int[] times) {
        this.map = new HashMap<Integer, Integer>();
        this.times = times;
        Map<Integer, Integer> count = new HashMap<Integer, Integer>();
        int n = times.length, m = -1;
        for (int i = 0; i < n; ++i) {
            int v = count.getOrDefault(persons[i], 0) + 1;
            if (v >= count.getOrDefault(m, 0)) {
                m = persons[i];
            }
            count.put(persons[i], v);
            map.put(times[i], m);
        }
    }
    
    public int q(int t) {
        int ret = Arrays.binarySearch(times, t);
        if (ret < 0) {
            return map.get(times[-ret - 2]);
        }
        return map.get(times[ret]);
    }
}

/**
 * Your TopVotedCandidate object will be instantiated and called as such:
 * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
 * int param_1 = obj.q(t);
 */
// @lc code=end

