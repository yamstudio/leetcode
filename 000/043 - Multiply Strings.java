import java.util.Arrays;

public class Solution {
    public String multiply(String num1, String num2) {
        int len1, len2, len, i, j, k, c1, result, carry;
        int[] s1, s2, temp;
        char[] ret;
        
        if (num1 == null || num2 == null)
            return null;
        len1 = num1.length();
        len2 = num2.length();
        len = len1 + len2;
        
        s1 = new int[len1];
        s2 = new int[len2];
        for (i = 0; i < len1; ++i)
            s1[i] = Character.getNumericValue(num1.charAt(len1 - 1 - i));
        for (i = 0; i < len2; ++i)
            s2[i] = Character.getNumericValue(num2.charAt(len2 - 1 - i));
        temp = new int[len];
        
        for (i = 0; i < len1; ++i) {
            c1 = s1[i];
            for (j = 0; j < len2; ++j) {
                result = c1 * s2[j];
                carry = result / 10;
                temp[i + j] += result % 10;
                if (temp[i + j] >= 10) {
                    temp[i + j] -= 10;
                    carry++;
                }
                k = 1;
                while (carry > 0) {
                    temp[i + j + k] += carry;
                    if (temp[i + j + k] >= 10) {
                        temp[i + j + k] -= 10;
                        carry = 1;
                    } else
                        carry = 0;
                    ++k;
                }
            }
        }
        
        for (i = len - 1; i >= 1 && temp[i] == 0; --i);
            ;
        ret = new char[i + 1];
        for (j = 0; j <= i; ++j)
            ret[j] = (char)('0' + temp[i - j]);
        
        return String.valueOf(ret);
    }
}
