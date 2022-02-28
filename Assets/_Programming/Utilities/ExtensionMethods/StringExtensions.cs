using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensions
{
    #region Hash Methods
    
    public static int[] StringArrayToHash(this string[] s)
    {
        int[] hashArray = new int[s.Length];

        if (s.Length == 0)
            return hashArray;

        int count = 0;

        while (count < s.Length)
        {
            hashArray[count] = s[count].GetHashCode();
            count++;
        }

        return hashArray;
    }

    #endregion
}
