char* intToRoman(int num) {
    int k[13] = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1}, i;
    char v[] = "M\0\0CM\0D\0\0CD\0C\0\0XC\0L\0\0XL\0X\0\0IX\0V\0\0IV\0I\0\0";
    char *str = (char *)malloc(256), *s = (char *)str, *c;
    
    for (i = 0; i < 13; ++i) {
        c = v + 3 * i;
        while (num / k[i]) {
            *s++ = *c;
            if (strlen(c) > 1)
                *s++ = c[1];
            num -= k[i];
        }
    }
    *s = '\0';
    return str;
}