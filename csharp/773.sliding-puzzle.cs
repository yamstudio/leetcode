/*
 * @lc app=leetcode id=773 lang=csharp
 *
 * [773] Sliding Puzzle
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static (int DX, int DY)[] Dirs = new (int DX, int DY)[] {
        (DX: 0, DY: -1),
        (DX: 0, DY: 1),
        (DX: -1, DY: 0),
        (DX: 1, DY: 0)
    };

    public int SlidingPuzzle(int[][] board) {
        int ret = 0;
        var visited = new HashSet<string>();
        var queue = new Queue<(string Key, int Index)>();
        var key = string.Concat(board.SelectMany(row => row));
        for (int i = 0; i < 6; ++i) {
            if (key[i] == '0') {
                queue.Enqueue((Key: key, Index: i));
                break;
            }
        }
        while (queue.Count > 0) {
            for (int i = queue.Count - 1; i >= 0; --i) {
                var curr = queue.Dequeue();
                key = curr.Key;
                if (key == "123450") {
                    return ret;
                }
                visited.Add(key);
                var arr = key.ToCharArray();
                int j = curr.Index, r = j / 3, c = j % 3;
                foreach (var dir in Dirs) {
                    int nr = dir.DX + r, nc = dir.DY + c;
                    if (nr < 0 || nr > 1 || nc < 0 || nc > 2) {
                        continue;
                    }
                    int k = nr * 3 + nc;
                    arr[j] = arr[k];
                    arr[k] = '0';
                    var nkey = new string(arr);
                    arr[k] = arr[j];
                    arr[j] = '0';
                    if (visited.Contains(nkey)) {
                        continue;
                    }
                    queue.Enqueue((Key: nkey, Index: k));
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

