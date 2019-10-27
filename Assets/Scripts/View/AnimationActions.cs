using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActions : MonoBehaviour
{
    // Start is called before the first frame update

    public Player playerRef;
    public Enemy enemyRef;
 
    public void Atack()
    {
        //if theres a player script in here than we are in the player
        if(playerRef != null)
            playerRef.Shot();

        //if theres a enemy script in here than we are in the enemy
        if(enemyRef != null){}
            //enemy atack function

    }

}
