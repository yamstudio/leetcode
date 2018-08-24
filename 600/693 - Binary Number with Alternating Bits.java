class Solution {
    public boolean hasAlternatingBits(int n) {
        String s = Integer.toBinaryString(n);
        return s.indexOf("00") == -1 && s.indexOf("11") == -1;
    }
}