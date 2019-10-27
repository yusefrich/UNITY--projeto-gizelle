using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {


    [Header("input de personagem")]
    private float inputDeMovimento;
	
	[Header("CharacterController")]
	private CharacterController myController;

	public int points = 0;

	[Header("Attack Equip items")]
	public GameObject muzzle;
	public GameObject bullet;
	public GameObject muzzleRightPos;// set the muzzle position and rotation to the muzzle right pos
	public GameObject muzzleLeftPos;// set the muzzle position and rotation to the muzzle left pos


	//switch camera pos
	

	// Use this for initialization
	void Start ()
	{
		myController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		//get inputs
		GetGlobalInput();
		// getting camera bounds
		

	}
	void FixedUpdate(){

		//input de movimento
		inputDeMovimento = Input.GetAxisRaw("Horizontal");

		myController.Move(inputDeMovimento);
		if(inputDeMovimento != 0){
			MuzzleDirection(inputDeMovimento);
		}
    }
    void GetGlobalInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            myController.Jump();
        }
		if (Input.GetKeyDown(KeyCode.Space)){
			Shot();
		}
    }

	void Shot(){
		Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
	}

	void MuzzleDirection(float direction){
		if(direction == 1f){
			muzzle.transform.position = muzzleRightPos.transform.position;
			muzzle.transform.rotation = muzzleRightPos.transform.rotation;
		}else {
			muzzle.transform.position = muzzleLeftPos.transform.position;
			muzzle.transform.rotation = muzzleLeftPos.transform.rotation;

		}
	}

}
