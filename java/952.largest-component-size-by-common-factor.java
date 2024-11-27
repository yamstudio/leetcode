/*
 * @lc app=leetcode id=952 lang=java
 *
 * [952] Largest Component Size by Common Factor
 */

import java.util.Arrays;
import java.util.Comparator;
import java.util.stream.IntStream;

// @lc code=start
import static java.util.stream.Collectors.groupingBy;
import static java.util.stream.Collectors.counting;

class Solution {
    public int largestComponentSize(int[] nums) {
        int max = Arrays.stream(nums).max().orElseThrow();
        int[] roots = IntStream.range(0, max + 1).toArray();
        for (int num : nums) {
            for (int x = (int)Math.floor(Math.sqrt((double)num)); x > 1; --x) {
                if (num % x == 0) {
                    roots[findRoot(num, roots)] = findRoot(x, roots);
                    roots[findRoot(num, roots)] = findRoot(num / x, roots);
                }
            }
        }
        return Arrays
            .stream(nums)
            .boxed()
            .collect(groupingBy(x -> findRoot(x, roots), counting()))
            .values()
            .stream()
            .max(Comparator.naturalOrder())
            .map(Long::intValue)
            .orElseThrow();
    }

    private static int findRoot(int x, int[] roots) {
        if (roots[x] == x) {
            return x;
        }
        int parent = findRoot(roots[x], roots);
        roots[x] = parent;
        return parent;
    }
}
// @lc code=end

