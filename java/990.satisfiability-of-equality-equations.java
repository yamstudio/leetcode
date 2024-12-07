/*
 * @lc app=leetcode id=990 lang=java
 *
 * [990] Satisfiability of Equality Equations
 */

// @lc code=start

class Solution {
    public boolean equationsPossible(String[] equations) {
        int[] parent = new int[27];
        for (var e : equations) {
            boolean eq = e.charAt(1) == '=';
            if (!eq) {
                continue;
            }
            int l = e.charAt(0) - 'a' + 1, r = e.charAt(3) - 'a' + 1, lp = find(parent, l), rp = find(parent, r);
            parent[lp] = rp;
        }
        for (var e : equations) {
            boolean eq = e.charAt(1) == '=';
            if (eq) {
                continue;
            }
            int l = e.charAt(0) - 'a' + 1, r = e.charAt(3) - 'a' + 1, lp = find(parent, l), rp = find(parent, r);
            if (lp == rp) {
                return false;
            }
        }
        return true;
    }

    private static int find(int[] parent, int x) {
        if (parent[x] == 0) {
            parent[x] = x;
            return x;
        }
        if (parent[x] == x) {
            return x;
        }
        int p = find(parent, parent[x]);
        parent[x] = p;
        return p;
    }
}
// @lc code=end

