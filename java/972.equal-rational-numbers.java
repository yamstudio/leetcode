/*
 * @lc app=leetcode id=972 lang=java
 *
 * [972] Equal Rational Numbers
 */

import java.util.Objects;

// @lc code=start

class Solution {
    public boolean isRationalEqual(String s, String t) {
        return Objects.equals(extend(s), extend(t));
    }

    private String extend(String s) {
        StringBuilder sb = new StringBuilder(21);
        int dotIndex = s.indexOf('.'), parenIndex = s.indexOf('(');
        String integerPart;
        if (dotIndex > 0) {
            integerPart = s.substring(0, dotIndex);
        } else {
            integerPart = s;
        }
        String nonRepeatingPart, repeatingPart; 
        if (parenIndex > 0) {
            repeatingPart = s.substring(parenIndex + 1, s.length() - 1);
            if (dotIndex > 0) {
                nonRepeatingPart = s.substring(dotIndex + 1, parenIndex);
            } else {
                nonRepeatingPart = "";
            }
        } else {
            repeatingPart = null;
            if (dotIndex > 0) {
                nonRepeatingPart = s.substring(dotIndex + 1);
            } else {
                nonRepeatingPart = "";
            }
        }

        if (repeatingPart != null && allNine(repeatingPart)) {
            if (allNine(nonRepeatingPart)) {
                sb.append(Integer.parseInt(integerPart) + 1);
                sb.append('.');
            } else {
                sb.append(integerPart);
                sb.append('.');
                char[] tmp = nonRepeatingPart.toCharArray();
                for (int i = tmp.length - 1; i >= 0; --i) {
                    if (tmp[i] == '9') {
                        tmp[i] = '0';
                    } else {
                        ++tmp[i];
                        break;
                    }
                }
                sb.append(tmp);
            }
        } else {
            sb.append(integerPart);
            sb.append('.');
            sb.append(nonRepeatingPart);
            if (repeatingPart != null) {
                int i = 0, m = repeatingPart.length();
                while (sb.length() < 21) {
                    sb.append(repeatingPart.charAt(i));
                    i = (i + 1) % m;
                }
            }

        }
        while (sb.length() < 21) {
            sb.append('0');
        }
        return sb.toString();
    }

    private boolean allNine(String s) {
        for (char c : s.toCharArray()) {
            if (c != '9') {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

