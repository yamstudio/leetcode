/*
 * @lc app=leetcode id=306 lang=csharp
 *
 * [306] Additive Number
 */
public class Solution {

    private bool IsAdditiveNumberRecurse(string num, string n1, string n2) {
        if ((n1.Length > 1 && n1[0] == '0') || (n2.Length > 1 && n2[0] == '0')) {
            return false;
        }
        string sum = (long.Parse(n1) + long.Parse(n2)).ToString();
        if (num.Length <= sum.Length) {
            return num == sum;
        }
        if (num.Substring(0, sum.Length) != sum) {
            return false;
        }
        return IsAdditiveNumberRecurse(num.Substring(sum.Length), n2, sum);
    }

    public bool IsAdditiveNumber(string num) {
        int n = num.Length;
        for (int i = 1; i < n; ++i) {
            string n1 = num.Substring(0, i);
            for (int j = 1; j < n - i; ++j) {
                string n2 = num.Substring(i, j);
                if (IsAdditiveNumberRecurse(num.Substring(i + j), n1, n2)) {
                    return true;
                }
            }
        }
        return false;
    }
}

