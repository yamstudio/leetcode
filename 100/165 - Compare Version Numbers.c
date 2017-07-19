#include <ctype.h>

static int parseInt(char **start) {
    char *p = *start;
    int ret = 0;
    
    if (*p != '\0') {
        while (isdigit(*p))
            ret = 10 * ret + (int)(*p++ - '0');

        *start = *p == '\0' ? p : ++p;
    }
    
    return ret;
}

int compareVersion(char* version1, char* version2) {
    int v1, v2;
    
    do {
        v1 = parseInt(&version1);
        v2 = parseInt(&version2);
    } while (v1 == v2 && (*version1 || *version2));

    return v1 > v2 ? 1 : (v1 == v2 ? 0 : -1);
}
