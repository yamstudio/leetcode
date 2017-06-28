int lengthOfLastWord(char* s) {
    int c = 0;
    char p = ' ';
    while (*s) {
        if (*s != ' ')
            if (p == ' ')
                c = 1;
            else
                ++c;
        p = *s++;
    }
    return c;
}
