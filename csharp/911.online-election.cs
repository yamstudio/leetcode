/*
 * @lc app=leetcode id=911 lang=csharp
 *
 * [911] Online Election
 */

using System.Collections.Generic;

// @lc code=start
public class TopVotedCandidate {

    private int[] Times;
    private IDictionary<int, int> Winnings;

    public TopVotedCandidate(int[] persons, int[] times) {
        Times = times;
        Winnings = new Dictionary<int, int>();
        int winning = 0, n = times.Length;
        var counts = new Dictionary<int, int>();
        for (int i = 0; i < n; ++i) {
            int person = persons[i], time = times[i];
            if (counts.TryGetValue(person, out int count)) {
                counts[person] = count + 1;
            } else {
                counts[person] = 1;
            }
            if (counts[person] >= counts[winning]) {
                winning = person;
            }
            Winnings[time] = winning;
        }
    }
    
    public int Q(int t) {
        int l = 0, r = Times.Length;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (t >= Times[m]) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return Winnings[Times[r - 1]];
    }
}

/**
 * Your TopVotedCandidate object will be instantiated and called as such:
 * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
 * int param_1 = obj.Q(t);
 */
// @lc code=end

