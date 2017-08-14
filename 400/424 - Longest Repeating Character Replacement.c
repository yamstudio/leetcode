#define max(a, b) ((a) > (b) ? (a) : (b))

int characterReplacement(char* s, int k) {
    int ret = 0, i, start = 0, count[26] = {0}, dominant = 0;
    
    for (i = 0; s[i]; ++i) {
        ++count[s[i] - 'A'];
        dominant = max(dominant, count[s[i] - 'A']);
        
        while (i - start + 1 - dominant > k)
            --count[s[start++] - 'A'];
        
        ret = max(ret, i - start + 1);
    }
    
    return ret;
}
