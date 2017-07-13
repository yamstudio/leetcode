public class Solution {
    public List<List<String>> partition(String s) {
        boolean[][] isPalindrome;
        List<List<String>> ret = new ArrayList<List<String>>();
        int i, j;
        
        if (s == null)
            return ret;
        isPalindrome = new boolean[s.length()][s.length()];
        
        for (i = s.length() - 1; i >= 0; --i) {
            for (j = i; j < s.length(); ++j) {
                if (s.charAt(i) == s.charAt(j) && (i >= j - 2 || isPalindrome[i + 1][j - 1]))
                    isPalindrome[i][j] = true;
            }
        }
        
        helper(s, 0, isPalindrome, new ArrayList<String>(), ret);
        
        return ret;
    }
    
    private void helper(String s, int from, boolean[][] isPalindrome, List<String> prefix, List<List<String>> ret) {
        int i;
        String sub;
        
        if (from == s.length()) {
            ret.add(new ArrayList<String>(prefix));
            return;
        }
        
        for (i = from; i < s.length(); ++i) {
            if (isPalindrome[from][i]) {
                sub = s.substring(from, i + 1);
                prefix.add(sub);
                helper(s, i + 1, isPalindrome, prefix, ret);
                prefix.remove(prefix.size() - 1);
            }
        }
    }
}
