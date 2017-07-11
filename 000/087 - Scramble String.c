#include <string.h>

static int helper(char *s1, char *s2, int len1, int len2) {
    int alpha[26] = {0}, i, ret;

    if (len1 != len2)
        return 0;
    else if (len1 == 1)
        return *s1 == *s2;
    
    for (i = 0; i < len1; ++i) {
        ++alpha[s1[i] - 'a'];
        --alpha[s2[i] - 'a'];
    }
    
    for (i = 0; i < 26; ++i) {
        if (alpha[i])
            return 0;
    }
    
    for (i = 1; i < len1; ++i) {
        ret = (helper(s1, s2, i, i) && helper(s1 + i, s2 + i, len1 - i, len1 - i)) || (helper(s1, s2 + (len1 - i), i, i) && helper(s1 + i, s2, len1 - i, len1 - i));
        if (ret)
            return 1;
    }
    return 0;
}

bool isScramble(char* s1, char* s2) {
    int len, ret;
    
    if (! (s1 && s2))
        return false;
    
    ret = helper(s1, s2, strlen(s1), strlen(s2)); 
    
    return ret;
}
