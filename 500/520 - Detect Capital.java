class Solution {
    public boolean detectCapitalUse(String word) {
        return word.matches("^([A-Z]+)|([A-Z][a-z]+)|([a-z]+)$");
    }
}
