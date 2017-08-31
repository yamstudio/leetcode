public class Solution {
    
    int index;
    
    public String decodeString(String s) {
        this.index = 0;
        return helper(s, s.length());
    }
    
    private String helper(String s, int len) {
        StringBuilder sb = new StringBuilder();
        String t;
        char c;
        int times;
        
        while (this.index < len && (c = s.charAt(this.index)) != ']') {
            if (c < '0' || c > '9') {
                sb.append(c);
                this.index++;
            } else {
                times = 0;
                while (this.index < len && (c = s.charAt(this.index)) >= '0' && c <= '9') {
                    times = 10 * times + (int)(c - '0');
                    this.index++;
                }
                this.index++;
                
                t = helper(s, len);
                while (times-- > 0)
                    sb.append(t);
                
                this.index++;
            }
        }
        
        return sb.toString();
    }
}