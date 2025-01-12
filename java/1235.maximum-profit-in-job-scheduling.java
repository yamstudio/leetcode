/*
 * @lc app=leetcode id=1235 lang=java
 *
 * [1235] Maximum Profit in Job Scheduling
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.TreeMap;

// @lc code=start

import static java.util.Comparator.comparing;

class Solution {
    public int jobScheduling(int[] startTime, int[] endTime, int[] profit) {
        var endToProfit = new TreeMap<Integer, Integer>();
        int n = startTime.length;
        List<Job> jobs = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            jobs.add(new Job(startTime[i], endTime[i], profit[i]));
        }
        Collections.sort(jobs, comparing(Job::endTime));
        endToProfit.put(0, 0);
        for (Job job : jobs) {
            var lastEnd = endToProfit.floorEntry(job.startTime());
            int p = lastEnd.getValue() + job.profit();
            if (p > endToProfit.lastEntry().getValue()) {
                endToProfit.put(job.endTime(), p);
            }
        }
        return endToProfit.lastEntry().getValue();
    }

    private record Job(int startTime, int endTime, int profit) {}
}
// @lc code=end

