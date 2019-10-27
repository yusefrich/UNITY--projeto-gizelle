using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public GameObject[] mapModule;
    public int mapLength;
    public GameObject lastInstantiatedObject;
    // Start is called before the first frame update
    void Start()
    {
        lastInstantiatedObject = Instantiate(mapModule[0], transform.position, transform.rotation);
        
        //instantiate all the maps prefabs
        for (int i = 0; i < mapLength; i++)
        {
            Vector3 newInstantiationPoint = lastInstantiatedObject.GetComponent<MapModuleController>().GetNextRightInstantiationPoint();
            //instantiathe the new room
            lastInstantiatedObject = Instantiate(mapModule[Random.Range(1, mapModule.Length)], newInstantiationPoint, lastInstantiatedObject.transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
