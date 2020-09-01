/*
 * @lc app=leetcode id=1106 lang=csharp
 *
 * [1106] Parsing A Boolean Expression
 */

// @lc code=start
public class Solution {

    private static void FindEnd(string expression, int n, ref int i) {
        int acc = 0;
        while (acc != -1) {
            char c = expression[i++];
            if (c == '(') {
                ++acc;
            } else if (c == ')') {
                --acc;
            }
        }
    }


    private static bool ParseBoolExprRecurse(string expression, int n, ref int i) {
        if (expression[i] == 't') {
            ++i;
            return true;
        }
        if (expression[i] == 'f') {
            ++i;
            return false;
        }
        if (expression[i] == '!') {
            i += 2;
            bool b = ParseBoolExprRecurse(expression, n, ref i);
            ++i;
            return !b;
        }
        if (expression[i] == '&') {
            i += 2;
            bool b = true;
            while (i < n) {
                b &= ParseBoolExprRecurse(expression, n, ref i);
                if (!b) {
                    FindEnd(expression, n, ref i);
                    break;
                }
                if (expression[i] == ')') {
                    ++i;
                    break;
                }
                ++i;
            }
            return b;
        }
        if (expression[i] == '|') {
            i += 2;
            bool b = false;
            while (i < n) {
                b |= ParseBoolExprRecurse(expression, n, ref i);
                if (b) {
                    FindEnd(expression, n, ref i);
                    break;
                }
                if (expression[i] == ')') {
                    ++i;
                    break;
                }
                ++i;
            }
            return b;
        }
        return false;
    }

    public bool ParseBoolExpr(string expression) {
        int i = 0;
        return ParseBoolExprRecurse(expression, expression.Length, ref i);
    }
}
// @lc code=end

