/*
 * @lc app=leetcode id=1268 lang=java
 *
 * [1268] Search Suggestions System
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// @lc code=start
class Solution {
    public List<List<String>> suggestedProducts(String[] products, String searchWord) {
        TrieNode root = new TrieNode();
        for (String product : products) {
            TrieNode curr = root;
            int n = product.length();
            for (int i = 0; i < n; ++i) {
                int k = product.charAt(i) - 'a';
                if (curr.children[k] == null) {
                    curr.children[k] = new TrieNode();
                }
                curr = curr.children[k];
            }
            curr.isWord = true;
        }
        int l = searchWord.length();
        List<List<String>> ret = new ArrayList<>(l);
        TrieNode curr = root;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < l; ++i) {
            char c = searchWord.charAt(i);
            curr = curr.children[c - 'a'];
            if (curr == null) {
                break;
            }
            List<String> currRet = new ArrayList<>(3);
            sb.append(c);
            search(curr, currRet, sb);
            ret.add(currRet);
        }
        while (ret.size() < l) {
            ret.add(Collections.emptyList());
        }
        return ret;
    }

    private static void search(TrieNode curr, List<String> ret, StringBuilder sb) {
        if (curr == null || ret.size() == 3) {
            return;
        }
        if (curr.isWord) {
            ret.add(sb.toString());
        }
        for (int i = 0; i < 26 && ret.size() < 3; ++i) {
            TrieNode next = curr.children[i];
            if (next == null) {
                continue;
            }
            sb.append((char)(i + 'a'));
            search(next, ret, sb);
            sb.deleteCharAt(sb.length() - 1);
        }
    }

    private static class TrieNode {
        boolean isWord = false;
        TrieNode[] children = new TrieNode[26];
    }
}
// @lc code=end

