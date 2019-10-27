using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModuleController : MonoBehaviour
{
    public Transform leftBoundPoint;
    public Transform rightBoundPoint;
    // Start is called before the first frame update
    public Vector3 GetLeftBoundPoint()
    {
        return leftBoundPoint.position;
    }
    public Vector3 GetRightBoundPoint()
    {
        return rightBoundPoint.position;
    }
    
    //this can be used to get the total length of the map module 
    public float GetBondsLenghts()
    {

        return Vector3.Distance(leftBoundPoint.position, rightBoundPoint.position);
    }

    public Vector3 GetNextRightInstantiationPoint(){
        Vector3 point = GetRightBoundPoint();
        return point = new Vector3 (
            point.x + (GetBondsLenghts() / 2),
            transform.position.y,
            point.z
        );
        
    }
}
