#include <string.h>

bool repeatedSubstringPattern(char* s) {
    int len, i, j, k, flag;
    
    len = strlen(s);
    
    for (i = len / 2; i >= 1; --i) {
        if (! (len % i)) {
            flag = 0;
            for (j = 0; j < i; ++j) {
                for (k = j; k + i < len; ++k) {
                    if (s[k] != s[k + i]) {
                        flag = 1;
                        break;
                    }
                }
                
                if (flag)
                    break;
                else
                    return 1;
            }
        }
    }
    
    return 0;
}
