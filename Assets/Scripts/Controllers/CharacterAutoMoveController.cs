using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAutoMoveController : MonoBehaviour
{ 
    // Start is called before the first frame update
    public GameObject maxLength;
    public GameObject minLength;
    public GameObject objectsLength;
    private Vector3 maxLengthObjectsFixedPos;
    private Rigidbody2D rb2d;
    private CharacterController myCharacterController; 

    float moveDir =0;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        myCharacterController = GetComponent<CharacterController>();
        maxLengthObjectsFixedPos = objectsLength.transform.position;

        //starting moving of the player
        moveDir = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x >= maxLength.transform.position.x){
            moveDir =-1f;
        }else if(transform.position.x <= minLength.transform.position.x){
            moveDir =1f;
        }

        myCharacterController.Move(moveDir);
    }

    private void FixedUpdate() {
        objectsLength.transform.position = maxLengthObjectsFixedPos;
    }
}
