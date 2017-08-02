char* removeDuplicateLetters(char* s) {
    char *ret, c;
    int len, count[256] = {0}, visited[256] = {0}, i, r_len;
    
    if ((len = strlen(s)) == 0)
        return "";
    ret = (char *)malloc(len * sizeof(char));
    *ret = 'a' - 1;
    r_len = 1;
    
    for (i = 0; i < len; ++i)
        count[s[i]]++;
    
    for (i = 0; i < len; ++i) {
        c = s[i];
        count[c]--;
        
        if (visited[c])
            continue;
        
        while (c < ret[r_len - 1] && count[ret[r_len - 1]])
            visited[ret[--r_len]] = 0;

        ret[r_len++] = c;
        visited[c] = 1;
    }
    
    ret[r_len] = '\0';
    return ret + 1;
}
