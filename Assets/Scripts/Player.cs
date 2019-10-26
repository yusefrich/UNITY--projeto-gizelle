using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {


    [Header("input de personagem")]
    private float inputDeMovimento;



	
	[Header("CharacterController")]
	private CharacterController myController;

	// Use this for initialization
	void Start ()
	{
		myController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		//get inputs
		GetGlobalInput();
	}


	void FixedUpdate(){

		//input de movimento
		inputDeMovimento = Input.GetAxisRaw("Horizontal");

		myController.Move(inputDeMovimento);

    }


    void GetGlobalInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            myController.Jump();
        }

/*         //input de abrir e fechar inventario
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject.FindWithTag("ItemInventory").GetComponent<ItemInventory>().ActivateItemsInventory();
        }
	    if (Input.GetKeyUp(KeyCode.LeftControl))
	    {
		    GameObject.FindWithTag("ItemInventory").GetComponent<ItemInventory>().DeactivateItemsInventory();
	    }
		//use Item
	    if (Input.GetKeyDown(KeyCode.J))
	    {
		    GameObject.FindWithTag("ItemInventory").GetComponent<ItemInventorySelector>().UseSelectedItem();
	    }
 */

    }

}
