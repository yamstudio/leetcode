#include <string.h>

static inline int hash(char c) {
    switch (c) {
        case '(':
            return 0;
        case '[':
            return 1;
        case '{':
            return 2;
        case ')':
            return 3;
        case ']':
            return 4;
        default:
            return 5;
    }
}

bool isValid(char* s) {
    int n, k = 0;
    char *l, *o, c;
    
    n = strlen(s);
    o = malloc(n * sizeof(char));
    l = o;
    while ((c = *s++)) {
        if (hash(c) < 3) {
            *l++ = c;
            ++k;
        } else {
            if ((!k) || hash(*--l) != hash(c) - 3)
                return 0;
            else
                --k;
        }
    }
    free(o);
    return (k == 0);
}
