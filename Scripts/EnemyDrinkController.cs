using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrinkController : MonoBehaviour
{
    //private int overms = 0;
    private float speed;                            //movement speed (the faster, the harder)
    private float destroyThreshold = -6.5f;         //if position is passed this value, the game is over.
    private int num;
    public Material drink1, drink2, drink3, drink4, drink5;
    public Material drink6, drink7, drink8, drink9, drink10;
    public static int dr1 = 0;
    public static int dr2 = 0;
    public static int dr3 = 0;
    public static int dr4 = 0;
    public static int dr5 = 0;
    public static int dr6 = 0;
    public static int dr7 = 0;
    public static int dr8 = 0;
    public static int dr9 = 0;
    public static int dr10 = 0;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4.0f, 7.0f);
        transform.Rotate(Vector3.forward, 180);
        num = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (num == 0)
        {
            GetComponent<MeshRenderer>().material = drink1;
            dr1 = 1;
        }
        else if (num == 1)
        {
            GetComponent<MeshRenderer>().material = drink2;
            dr2 = 1;
        }
        else if (num == 2)
        {
            GetComponent<MeshRenderer>().material = drink3;
            dr3 = 1;
        }
        else if (num == 3)
        {
            GetComponent<MeshRenderer>().material = drink4;
            dr4 = 1;
        }
        else if (num == 4)
        {
            GetComponent<MeshRenderer>().material = drink5;
            dr5 = 1;
        }
        else if (num == 5)
        {
            GetComponent<MeshRenderer>().material = drink6;
            dr6 = 1;
        }
        else if (num == 6)
        {
            GetComponent<MeshRenderer>().material = drink7;
            dr7 = 1;
        }
        else if (num == 7)
        {
            GetComponent<MeshRenderer>().material = drink8;
            dr8 = 1;
        }
        else if (num == 8)
        {
            GetComponent<MeshRenderer>().material = drink9;
            dr9 = 1;
        }
        else if (num == 9)
        {
            GetComponent<MeshRenderer>().material = drink10;
            dr10 = 1;
        }

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
