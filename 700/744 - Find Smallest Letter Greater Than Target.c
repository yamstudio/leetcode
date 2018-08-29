char nextGreatestLetter(char* letters, int lettersSize, char target) {
    for (int i = 0; i < lettersSize; ++i) {
        char c = letters[i];
        
        if (c > target) {
            return c;
        }
    }
    
    return letters[0];
}