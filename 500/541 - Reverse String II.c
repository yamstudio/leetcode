#include <string.h>

char* reverseStr(char* s, int k) {
    int len, i = 0, left, right;
    char temp;
    
    len = strlen(s);
    
    for (i = 0; i < len; i += 2 * k) {
        left = i;
        right = i + k >= len ? len - 1 : i + k - 1;
        
        while (left < right) {
            temp = s[left];
            s[left++] = s[right];
            s[right--] = temp;
        }
    }
    
    return s;
}
