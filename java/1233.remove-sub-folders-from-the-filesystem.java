/*
 * @lc app=leetcode id=1233 lang=java
 *
 * [1233] Remove Sub-Folders from the Filesystem
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start
class Solution {
    public List<String> removeSubfolders(String[] folder) {
        Folder root = new Folder();
        for (String path : folder) {
            StringBuilder sb = new StringBuilder();
            int n = path.length();
            Folder curr = root;
            for (int i = 1; i <= n && curr.subs != null; ++i) {
                if (i < n && path.charAt(i) != '/') {
                    sb.append(path.charAt(i));
                    continue;
                }
                String seg = sb.toString();
                sb.delete(0, sb.length());
                curr = curr.subs.computeIfAbsent(seg, ignored -> new Folder());
            }
            curr.subs = null;
        }
        List<String> ret = new ArrayList<>();
        helper(ret, root, new StringBuilder());
        return ret;
    }

    private static void helper(List<String> ret, Folder curr, StringBuilder sb) {
        if (curr.subs == null) {
            ret.add(sb.toString());
            return;
        }
        sb.append("/");
        for (var nextEntry : curr.subs.entrySet()) {
            String name = nextEntry.getKey();
            Folder next = nextEntry.getValue();
            sb.append(name);
            helper(ret, next, sb);
            sb.delete(sb.length() - name.length(), sb.length());
        }
        sb.deleteCharAt(sb.length() - 1);
    }

    private class Folder {
        private Map<String, Folder> subs = new HashMap<>();
    }
}
// @lc code=end

