int countBinarySubstrings(char* s) {
    int ret = 0, curr = 0, prev = 0;
    char c, pc = *s;
    
    while (c = *s++) {
        if (c == pc) {
            curr++;
        } else {
            ret += curr > prev ? prev : curr;
            prev = curr;
            curr = 1;
        }
        pc = c;
    }
    
    return ret + (curr > prev ? prev : curr);
}