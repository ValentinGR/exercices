using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public string RaycastCheckTag(Vector3 position, Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(position, direction, out hit, 1.1f))
        {
            return hit.transform.tag;
        }

        return null;
    }

    public Vector3 RaycastCheckPosition(Vector3 position, Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(position, direction, out hit, 1))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}
