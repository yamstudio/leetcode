/*
 * @lc app=leetcode id=466 lang=csharp
 *
 * [466] Count The Repetitions
 */
public class Solution {
    public int GetMaxRepetitions(string s1, int n1, string s2, int n2) {
        int[] count = new int[n1 + 1], index = new int[n1 + 1];
        int curr = 0, i2 = 0, l1 = s1.Length, l2 = s2.Length;
        for (int c = 1; c <= n1; ++c) {
            for (int i1 = 0; i1 < l1; ++i1) {
                if (s1[i1] == s2[i2]) {
                    ++i2;
                    if (i2 == l2) {
                        ++curr;
                        i2 = 0;
                    }
                }
            }
            count[c] = curr;
            index[c] = i2;

            for (int j = 0; j < c; ++j) {
                if (index[j] == i2) {
                    int length = c - j;
                    int preCount = count[j + (n1 - j) % length];
                    int repeatCount = ((n1 - j) / length) * (count[c] - count[j]);
                    return (preCount + repeatCount) / n2;
                }
            }
        }
        return count[n1] / n2;
    }
}

