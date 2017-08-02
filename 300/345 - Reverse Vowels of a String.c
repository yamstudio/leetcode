char* reverseVowels(char* s) {
    int v[256] = {0}, i;
    char *left = s, *right = s, temp, vowels[10] = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
    
    if (! (s && *s))
        return s;
    
    for (i = 0; i < 10; ++i)
        v[vowels[i]] = 1;
    
    while (*(right + 1))
        ++right;
    
    while (left < right) {
        if (! v[*left])
            ++left;
        else if (! v[*right])
            --right;
        else {
            temp = *left;
            *left++ = *right;
            *right-- = temp;
        }
    }
    
    return s;
}
