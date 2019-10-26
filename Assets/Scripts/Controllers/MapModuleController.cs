using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModuleController : MonoBehaviour
{
    public Transform leftBoundPoint;
    public Transform rightBoundPoint;
    // Start is called before the first frame update
    Vector3 GetLeftBoundPoint()
    {
        return leftBoundPoint.position;
    }
    Vector3 GetRightBoundPoint()
    {
        return rightBoundPoint.position;
    }
}
