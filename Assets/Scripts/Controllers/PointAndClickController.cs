using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickController : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementTime = 5;
    float lerpValue = 0;
    bool aiming;
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray))
                //currentPlaceClicked = Input.mousePosition;
        }

    }

            //lerpValue += Time.deltaTime / movementTime;
            //transform.position = Vector3.Lerp(from.position, to.position, lerpValue);

}
