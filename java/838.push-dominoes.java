/*
 * @lc app=leetcode id=838 lang=java
 *
 * [838] Push Dominoes
 */

// @lc code=start
class Solution {
    public String pushDominoes(String dominoes) {
        int n = dominoes.length();
        char[] array = dominoes.toCharArray();
        for (int i = 0; i < n;) {
            int ni = i + 1;
            while (ni < n && array[i] == array[ni]) {
                ++ni;
            }
            if (array[i] == '.') {
                boolean r = i > 0 && array[i - 1] == 'R', l = ni < n && array[ni] == 'L';
                if (l) {
                    if (r) {
                        int h = (ni - i) / 2;
                        for (int j = 0; j < h; ++j) {
                            array[i + j] = 'R';
                            array[ni - 1 - j] = 'L';
                        }
                    } else {
                        for (int j = i; j < ni; ++j) {
                            array[j] = 'L';
                        }
                    }
                } else {
                    if (r) {
                        for (int j = i; j < ni; ++j) {
                            array[j] = 'R';
                        }
                    }
                }
            }
            i = ni;
        }
        return new String(array);
    }
}
// @lc code=end

