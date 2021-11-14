using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYakController : MonoBehaviour
{
    //private int overms = 0;
    private float speed;                            //movement speed (the faster, the harder)
    private float destroyThreshold = -6.5f;         //if position is passed this value, the game is over.

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.6f, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, Time.deltaTime *
                                                 GameController.moveSpeed *
                                                 speed);
        if (transform.position.z < destroyThreshold)
        {
           // overms++;
            //if(overms>5)
            //{
           // GameController.gameOver = true;
            Destroy(gameObject);
            //}

        }
    }
}
