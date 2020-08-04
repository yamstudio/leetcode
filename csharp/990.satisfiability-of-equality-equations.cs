/*
 * @lc app=leetcode id=990 lang=csharp
 *
 * [990] Satisfiability of Equality Equations
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    
    private static int FindRoot(int[] roots, int curr) {
        return roots[curr] == curr ? curr : (roots[curr] = FindRoot(roots, roots[curr]));
    }
    
    public bool EquationsPossible(string[] equations) {
        var neq = new List<string>();
        var roots = Enumerable.Range(0, 26).ToArray();
        foreach (var eq in equations) {
            if (eq[1] == '!') {
                neq.Add(eq);
                continue;
            }
            int a = (int)eq[0] - (int)'a', b = (int)eq[3] - (int)'a';
            roots[FindRoot(roots, a)] = FindRoot(roots, b);
        }
        foreach (var eq in neq) {
            int a = (int)eq[0] - (int)'a', b = (int)eq[3] - (int)'a';
            if (FindRoot(roots, a) == FindRoot(roots, b)) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

