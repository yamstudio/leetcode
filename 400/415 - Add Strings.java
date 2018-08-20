class Solution {
    public String addStrings(String num1, String num2) {
        int i = num1.length() - 1, j = num2.length() - 1;
        StringBuilder sb = new StringBuilder();
        int carry = 0;
        
        while (i >= 0 || j >= 0) {
            int c1 = 0, c2 = 0, sum = 0;

            if (i >= 0) {
                c1 = num1.charAt(i--) - '0';
            }
            
            if (j >= 0) {
                c2 = num2.charAt(j--) - '0';
            }
            
            sum = c1 + c2 + carry;
            if (sum >= 10) {
                sum -= 10;
                carry = 1;
            } else {
                carry = 0;
            }
            
            sb.append(sum);
        }
        
        if (carry == 1) {
            sb.append('1');
        }
        
        return sb.reverse().toString();
    }
}