int countSegments(char* s) {
    int ret = 0;
    
    while (*s) {
        if (*s == ' ') {
            s++;
            continue;
        }
        ++ret;
        
        while (*s && *s != ' ')
            ++s;
    }
    
    return ret;
}
