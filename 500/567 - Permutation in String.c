#include <string.h>

bool checkInclusion(char* s1, char* s2) {
    int dict[26] = {0}, i, j, len1, len2, flag;
    
    len1 = strlen(s1);
    len2 = strlen(s2);
    if (len1 > len2)
        return 0;
    
    for (i = 0; i < len1; ++i) {
        dict[s1[i] - 'a']++;
        dict[s2[i] - 'a']--;
    }
    
    do {
        flag = 1;
        for (j = 0; j < 26; ++j) {
            if (dict[j]) {
                flag = 0;
                break;
            }
        }

        if (flag)
            return 1;
        
        if (! s2[i])
            break;
        
        dict[s2[i - len1] - 'a']++;
        dict[s2[i++] - 'a']--;
    } while (1);
    
    return 0;
}
