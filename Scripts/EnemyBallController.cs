using UnityEngine;
//using UnityEngine.Random;
using System.Collections;

public class EnemyBallController : MonoBehaviour {

    /// <summary>
    /// This class moves enemyballs in survival mode to the bottom of the screen.
    /// The game is over if any enemyball reach to the botttom.
    /// </summary>
    private int overms = 0;
	private float speed;							//movement speed (the faster, the harder)
	private float destroyThreshold = -6.5f;         //if position is passed this value, the game is over.



    void Start() {
		//set a random speed for each enemyball
		speed = Random.Range(4.0f, 7.0f);
        transform.Rotate(Vector3.forward, 180);
        
	}

	void Update()
    {

        



        //move the enemyball down
        transform.position -= new Vector3(0, 0, Time.deltaTime * 
		                                 		GameController.moveSpeed * 
		                                 		speed);
		//check for possible gameover
		if (transform.position.z < destroyThreshold) {
            overms++;
            //if(overms>5)
            //{
              //  GameController.gameOver = true;
                Destroy(gameObject);
            //}
			
		}
	}
}
