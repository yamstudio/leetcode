#include <ctype.h>

char* licenseKeyFormatting(char* S, int K) {
    int group, len = 0, dashes = 0, char_len, ret_len, count = 0;
    char *ret, c;
    
    for (ret = S; *ret; ++ret) {
        ++len;
        if (*ret == '-')
            ++dashes;
    }
    
    char_len = len - dashes;
    ret_len = char_len + char_len / K + 1;
    group = char_len % K;
    if (! group)
        group = K;
    ret = (char *)malloc(ret_len * sizeof(char));
    
    while ((c = *S++) != '\0') {
        if (c == '-')
            continue;
        
        if (! group) {
            ret[count++] = '-';
            group = K;
        }
        
        if (isdigit(c) || isupper(c)) {
            ret[count++] = c;
            --group;
        } else if (islower(c)) {
            ret[count++] = toupper(c);
            --group;
        }
    }
    
    ret[count++] = '\0';
    return ret;
}
