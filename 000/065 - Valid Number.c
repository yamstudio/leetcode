#include <ctype.h>

bool isNumber(char* s) {
    char c;
    int frac = 0;
    
    do
        c = *s++;
    while (isspace(c));
    
    if (c == '+' || c == '-')
        c = *s++;
    
    if (c == '.') {
        frac = 1;
        c = *s++;
    }
    
    if (! isdigit(c))
        return 0;
    
    while (isdigit(c))
        c = *s++;
    
    if (c == '.') {
        if (frac)
            return 0;
        c = *s++;
        while (isdigit(c))
            c = *s++;
    }
        
    if (c == 'e') {
        c = *s++;
        if (c == '-' || c == '+')
            c = *s++;
        if (! isdigit(c))
            return 0;
        while (isdigit(c))
            c = *s++;
    }

    while (isspace(c))
        c = *s++;

    return c == '\0';
}
