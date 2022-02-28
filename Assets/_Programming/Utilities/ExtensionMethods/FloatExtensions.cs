using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions 
{
    public static float SignedValueTo1(this float testedFloat)
    {
        if (testedFloat < 0)
            testedFloat = -1;
        else if (testedFloat > 0)
            testedFloat = 1;

        return testedFloat;
    }
}