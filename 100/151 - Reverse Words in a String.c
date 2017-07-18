#include <ctype.h>

static void reverseWord(char *from, char *to) {
    char temp;
    
    while (from < to) {
        temp = *from;
        *from++ = *to;
        *to-- = temp;
    }
}

void reverseWords(char *s) {
    char *curr, *start, *end, *from;
    
    if (! s)
        return;
    
    start = s;
    while (isspace(*start))
        ++start;
    
    if (! *start) {
        *s = '\0';
        return;
    }
    curr = start;
    from = start;
    
    while (*curr) {
        if (isspace(*curr)) {
            if (from) {
                end = curr - 1;
                reverseWord(from, end);
                from = NULL;
            }
        } else {
            if (! from)
                from = curr;
        }
            
        ++curr;
    }
    if (from) {
        end = curr - 1;
        reverseWord(from, end);
    }
    
    reverseWord(start, end);
    
    curr = s;
    do {
        if (! (isspace(*start) && isspace(*(start - 1))))
            *curr++ = *start;
        ++start;
    } while (start <= end);

    *curr = '\0';
}
