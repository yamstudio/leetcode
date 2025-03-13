/*
 * @lc app=leetcode id=1452 lang=java
 *
 * [1452] People Whose List of Favorite Companies Is Not a Subset of Another List
 */

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

// @lc code=start
class Solution {
    public List<Integer> peopleIndexes(List<List<String>> favoriteCompanies) {
        int n = favoriteCompanies.size();
        List<Set<String>> favs = new ArrayList<>(n);
        int[] roots = new int[n];
        for (int i = 0; i < n; ++i) {
            roots[i] = i;
            favs.add(new HashSet<>(favoriteCompanies.get(i)));
        }
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; ++j) {
                int ri = find(roots, i), rj = find(roots, j);
                if (ri == rj) {
                    continue;
                }
                var fi = favs.get(ri);
                var fj = favs.get(rj);
                if (fi.containsAll(fj)) {
                    roots[rj] = ri;
                } else if (fj.containsAll(fi)) {
                    roots[ri] = rj;
                }
            }
        }
        List<Integer> ret = new ArrayList<>();
        for (int i = 0; i < n; ++i) {
            if (find(roots, i) == i) {
                ret.add(i);
            }
        }
        return ret;
    }

    private static int find(int[] roots, int i) {
        int r = roots[i];
        if (r != i) {
            r = find(roots, r);
            roots[i] = r;
        }
        return r;
    }
}
// @lc code=end

