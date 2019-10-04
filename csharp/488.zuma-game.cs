/*
 * @lc app=leetcode id=488 lang=csharp
 *
 * [488] Zuma Game
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    private static int FindMinStepRecurse(LinkedList<char> board, IDictionary<char, int> count) {
        board = new LinkedList<char>(board);
        var start = board.First;
        var curr = start.Next;
        bool found = false;
        do {
            found = false;
            while (curr != null) {
                char val = curr.Value;
                var end = curr.Next;
                int n = 1;
                while (end != null && end.Value == val) {
                    end = end.Next;
                    ++n;
                }
                if (n >= 3) {
                    found = true;
                    while (curr != end) {
                        var tmp = curr.Next;
                        board.Remove(curr);
                        curr = tmp;
                    }
                }
                curr = end;
            }
            curr = start.Next;
        } while (found);
        if (curr == null) {
            return 0;
        }
        int ret = int.MaxValue;
        while (curr != null) {
            char val = curr.Value;
            var next = curr.Next;
            if (next == null || val != next.Value) {
                if (count[val] > 1) {
                    count[val] -= 2;
                    board.Remove(curr);
                    int tmp = FindMinStepRecurse(board, count);
                    if (tmp != int.MaxValue) {
                        ret = Math.Min(ret, tmp + 2);
                    }
                    board.AddAfter(start, curr);
                    count[val] += 2;
                }
                start = curr;
                curr = next;
            } else {
                if (count[val] > 0) {
                    count[val]--;
                    board.Remove(curr);
                    board.Remove(next);
                    int tmp = FindMinStepRecurse(board, count);
                    if (tmp != int.MaxValue) {
                        ret = Math.Min(ret, tmp + 1);
                    }
                    board.AddAfter(start, curr);
                    board.AddAfter(curr, next);
                    count[val]++;
                }
                start = next;
                curr = start.Next;
            }
        }
        return ret;
    }
    
    public int FindMinStep(string board, string hand) {
        IDictionary<char, int> count = new Dictionary<char, int>()
        {
            { 'B', 0 },
            { 'G', 0 },
            { 'R', 0 },
            { 'W', 0 },
            { 'Y', 0 },
        };
        foreach (char c in hand) {
            ++count[c];
        }
        var boardList = new LinkedList<char>(board);
        boardList.AddFirst('*');
        int ret = FindMinStepRecurse(boardList, count);
        return ret == int.MaxValue ? -1 : ret;
    }
}
// @lc code=end

