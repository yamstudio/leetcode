public class Solution {
    public String shortestPalindrome(String s) {
        StringBuilder sb = new StringBuilder(s);
        String rev = new StringBuilder(s).reverse().toString();
        int i, j;
        int[] next;
        
        sb.append('*');
        sb.append(rev);
        next = new int[sb.length()];
        
        for (i = 1; i < next.length; ++i) {
            j = next[i - 1];
            while (j > 0 && sb.charAt(i) != sb.charAt(j))
                j = next[j - 1];
            
            next[i] = j == 0 ? (sb.charAt(i) == sb.charAt(0) ? 1 : 0) : j + 1;
        }  
        
        return rev.substring(0, rev.length() - next[next.length - 1]) + s;
    }
}
