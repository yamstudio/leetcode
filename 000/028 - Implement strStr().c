#include <string.h>

int strStr(char* haystack, char* needle) {
    int len = strlen(needle);
    char *p = haystack;
    
    if (! len)
        return 0;
    
    while (*p && strncmp(p, needle, len))
        ++p;
    
    return (*p ? (int)(p - haystack) : -1);
}
