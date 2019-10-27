using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	
	[Header("Character physics reference")]
	public float velocidade;
	public float forcaDoPulo;
	private Rigidbody2D rb2d;

	[Header("ground check reference")]
	public Transform checkDeChao;// o grandioso check de chao
	public float checkRadiando;//check de chao
	public LayerMask layerChao;//mascara de layer para funfar o check de chao
    private bool touchGround; // Tocando o chão.
	
	[Header("character statuses")]
	public CharacterStatus characterStatus;//struct

	[Header("Character graphics elements")]
	public GameObject jumpDust;//guarda um gameobject e seta falso quando no ar e true quando no chao, contem animação de poerinha
	private AudioSource stepSound;
	//private Animator anim;
	


	
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		//anim = gameObject.GetComponent<Animator>();
		stepSound = gameObject.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	public void Move (float moveDirection) {

        //animaçoes do jogador
        //MoveAnimations(rb2d.velocity.x);

        //bloqueio do movimento do character
        if (characterStatus.characterLocker)
        {
            rb2d.velocity = Vector2.zero;
            return;
        }

        //movimentação do character
        characterStatus.noChao = Physics2D.OverlapCircle (checkDeChao.position, checkRadiando, layerChao);

        //if (rb2d.velocity.y != 0 && characterStatus.noChao)
        //{
        //    // touchGround = true;
        //    
        //}

        if (touchGround)
        {
            if (characterStatus.noChao)
            {
                rb2d.velocity = Vector2.zero;
            }
            touchGround = false;
        }

        //set da poeira do player
        if (jumpDust != null)
		{
			jumpDust.SetActive(characterStatus.noChao);

		}
		
		//movimentando o jogador
		rb2d.velocity = new Vector2 (moveDirection * velocidade, rb2d.velocity.y);
		
		//subindo e descendo ladeiras
		if (characterStatus.noChao) {
			RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, Mathf.Infinity, layerChao);
			if (hit && Mathf.Abs (hit.normal.x) > 0.1f && !hit.collider.isTrigger) {
				float newVelX = rb2d.velocity.x - hit.normal.x * 1.025f;
				rb2d.velocity = new Vector2 (newVelX, rb2d.velocity.y);
				float newPosY =  transform.position.y - (hit.normal.x * Mathf.Abs(rb2d.velocity.x) * Time.deltaTime * (rb2d.velocity.x-hit.normal.x>0?1:-1));
				transform.position = new Vector3 (transform.position.x, newPosY, transform.position.z);
			}
		}
		
		//modificando variaveis de caida
		if (rb2d.velocity.y < 0 && !characterStatus.noChao) {
			characterStatus.goingDown = true;
		} else {
			characterStatus.goingDown = false;
		}
		
	}
    void MoveAnimations(float moveDirection)
    {
        //setando animações
        //anim.SetFloat("CurrentVelocityX", moveDirection);
        if (moveDirection != 0)
        {
            characterStatus.moving = true;
            //anim.SetFloat("LastVelocityX", moveDirection);
        }
        else
        {
            characterStatus.moving = false;
        }

        //anim.SetBool("Moving", characterStatus.moving);
        //anim.SetBool("NoChao", characterStatus.noChao);
        //anim.SetBool("GoingDown", characterStatus.goingDown);
    }

    public void Jump()
	{
        //bloqueio do movimento do character
        if (characterStatus.characterLocker)
        {
            return;
        }

        //pulo do jogador
        if (characterStatus.noChao)
		{
			rb2d.velocity = Vector2.up * forcaDoPulo;
		}
	}
	
	public void PlayStepSound()
	{
		stepSound.Play();
  
		print("tuk tuk");
	}

	
	
	public struct CharacterStatus
	{
		public bool goingDown;
		public bool noChao;
		public bool moving;
        public bool characterLocker;
	}

}
