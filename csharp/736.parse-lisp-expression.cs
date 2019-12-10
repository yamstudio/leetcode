/*
 * @lc app=leetcode id=736 lang=csharp
 *
 * [736] Parse Lisp Expression
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static (int Val, int Index) EvaluateRecurse(string expression, int i, IDictionary<string, IList<int>> vars) {
        if (expression[i] != '(') {
            int j = i + 1;
            while (expression[j] != ' ' && expression[j] != ')') {
                ++j;
            }
            string expr = expression.Substring(i, j - i);
            int val;
            if (expr[0] != '-' && (expr[0] < '0' || expr[0] > '9')) {
                var list = vars[expr];
                val = list[list.Count - 1];
            } else {
                val = int.Parse(expr);
            }
            return (
                Val: val,
                Index: j
            );
        }
        if (expression[i + 1] != 'l') {
            var isAdd = expression[i + 1] == 'a';
            if (isAdd) {
                i += 5;
            } else {
                i += 6;
            }
            var l1 = EvaluateRecurse(expression, i, vars);
            i = l1.Index + 1;
            var l2 = EvaluateRecurse(expression, i, vars);
            return (
                Val: isAdd ? l1.Val + l2.Val : l1.Val * l2.Val,
                Index: l2.Index + 1
            );
        }
        var locals = new HashSet<string>();
        i += 5;
        while (true) {
            if (expression[i] == '(') {
                break;
            }
            int j = i + 1;
            while (expression[j] != ' ' && expression[j] != ')') {
                ++j;
            }
            if (expression[j] == ')') {
                break;
            }
            string name = expression.Substring(i, j - i);
            i = j + 1;
            var l = EvaluateRecurse(expression, i, vars);
            if (locals.Contains(name)) {
                var list = vars[name];
                list[list.Count - 1] = l.Val;
            } else {
                locals.Add(name);
                IList<int> list;
                if (!vars.TryGetValue(name, out list)) {
                    list = new List<int>();
                    vars[name] = list;
                }
                list.Add(l.Val);
            }
            i = l.Index + 1;
        }
        var f = EvaluateRecurse(expression, i, vars);
        foreach (var name in locals) {
            var list = vars[name];
            list.RemoveAt(list.Count - 1);
        }
        return (
            Val: f.Val,
            Index: f.Index + 1
        );
    }

    public int Evaluate(string expression) {
        return EvaluateRecurse(expression, 0, new Dictionary<string, IList<int>>()).Val;
    }
}
// @lc code=end

