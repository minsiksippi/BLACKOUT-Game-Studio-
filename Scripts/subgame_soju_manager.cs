using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subgame_soju_manager : MonoBehaviour
{
    public Sprite[] img;
    int i = 0;
    public static int p;
    int getdarkframe=0;
    int f = 0;
    int a = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = null;
        p = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        f++;

        if ((GaugeManager.val > 0.33) & (a == 0))
        {
            a++;
            getdarkframe = f;
        }

        if ((f > getdarkframe + 100)&(getdarkframe>0))
        {
            this.GetComponent<SpriteRenderer>().sprite = img[0];

            if (f > getdarkframe)
            {
                this.GetComponent<SpriteRenderer>().sprite = img[0];

                if ((Input.GetMouseButtonDown(0)) & (i == 0)) i = 1;
                if (i == 1)
                {
                    if (p == 0)
                        this.GetComponent<SpriteRenderer>().sprite = img[1];
                    if (p == 1)
                        this.GetComponent<SpriteRenderer>().sprite = img[2];
                }
                if ((i == 1) & (f > handmanager.decision_frame + 100) & (p == 1))
                    this.GetComponent<SpriteRenderer>().sprite = null;
                else if ((i == 1) & (f > handmanager.decision_frame + 200) & (p == 0))
                    this.GetComponent<SpriteRenderer>().sprite = null; 
            }


  
    }
        
    }
}
