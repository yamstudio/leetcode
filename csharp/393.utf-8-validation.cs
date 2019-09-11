/*
 * @lc app=leetcode id=393 lang=csharp
 *
 * [393] UTF-8 Validation
 */
public class Solution {
    public bool ValidUtf8(int[] data) {
        int n = data.Length, i = 0;
        while (i < n) {
            int curr = data[i];
            if ((curr & 0b10000000) == 0) {
                ++i;
                continue;
            }
            int count = 1, mask = 0b11000000, expected = 0b10000000;
            while (count <= 3) {
                mask |= 1 << (6 - count);
                expected |= 1 << (7 - count);
                if ((curr & mask) == expected) {
                    break;
                }
                ++count;
            }
            if (count > 3) {
                return false;
            }
            if (i + count >= n) {
                return false;
            }
            ++i;
            while (count-- > 0) {
                if ((data[i++] & 0b11000000) != 0b10000000) {
                    return false;
                }
            }
        }
        return true;
    }
}

