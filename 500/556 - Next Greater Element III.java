import java.util.Arrays;

class Solution {
    public int nextGreaterElement(int n) {
        char[] s = Integer.toString(n).toCharArray();
        int len = s.length, i, j, ret;
        char temp;
        
        for (i = len - 1; i > 0; --i) {
            if (s[i] > s[i - 1])
                break;
        }
        
        if (i == 0)
            return -1;
        
        for (j = len - 1; j >= i; --j) {
            if (s[j] > s[i - 1]) {
                temp = s[i - 1];
                s[i - 1] = s[j];
                s[j] = temp;
                break;
            }
        }

        Arrays.sort(s, i, len);
        
        try {
            return Integer.valueOf(new String(s));
        } catch (NumberFormatException e) {
            return -1;
        }
    }
}