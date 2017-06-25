#define max(a, b) a > b ? a : b

char* longestPalindrome(char* s) {
    int i, j, flag_odd, flag_even, len_odd, len_even, m = 1;
    char *c, *c_max = s, *ans;
    for (i = 0; ; i++) {
        c = s + i;
        if (! *c)
            break;
        flag_odd = 1;
        flag_even = (*c == c[1]);
        len_odd = 1;
        len_even = flag_even * 2;
        for (j = 1; j <= i && (flag_odd || flag_even); ++j) {
            if (flag_odd) {
                if (c[-j] != c[j])
                    flag_odd = 0;
                else
                    len_odd += 2;
                if (! c[j])
                    flag_odd = 0;
            }
            if (flag_even) {
                if (c[-j] != c[j + 1])
                    flag_even = 0;
                else
                    len_even += 2;
                if (! c[j + 1])
                    flag_even = 0;
            }
        }
        if (len_odd > m) {
            c_max = c - len_odd / 2;
            m = len_odd;
        }
        if (len_even > m) {
            c_max = c - len_even / 2 + 1;
            m = len_even;
        }
    }
    ans = (char *)malloc(m + 1);
    memcpy(ans, c_max, m);
    ans[m] = '\0';
    return ans;
}
