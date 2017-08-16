#include <string.h>

int findSubstringInWraproundString(char* p) {
    int count[26] = {0}, ret = 0, prev_len, i, c;
    
    if (! (p && *p))
        return 0;
    
    c = *p++ - 'a';
    count[c] = 1;
    prev_len = 1;
    
    for (; *p; ++p) {
        if ((c + 1) % 26 == *p - 'a')
            ++prev_len;
        else
            prev_len = 1;

        if (prev_len > count[*p - 'a'])
            count[*p - 'a'] = prev_len;
        
        c = *p - 'a';
    }
    
    for (i = 0; i < 26; ++i)
        ret += count[i];
    
    return ret;
}
