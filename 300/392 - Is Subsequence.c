bool isSubsequence(char* s, char* t) {
    while (*s && *t) {
        if (*t++ == *s)
            ++s;
    }
    
    return ! *s;
}
