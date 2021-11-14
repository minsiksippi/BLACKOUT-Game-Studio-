using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handmanager : MonoBehaviour
{
    int i = 0;
    public Sprite[] img;
    public static int decision_frame = 0;
    int fr = 0;
    int a = 0;
    int getdarkframe = 0;
    int nosub1 = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        fr++;
        if ((GaugeManager.val > 0.33) & (a == 0)&(nosub1==0))
        {
            a++;
            getdarkframe = fr;
        }
        if((fr>getdarkframe+100)&(getdarkframe>0)&(nosub1==0))
        {
            this.GetComponent<SpriteRenderer>().sprite = img[0];
            if ((Input.GetMouseButtonDown(0)) & (i == 0))
            { i = 1; decision_frame = fr; }
            if (i == 1)
            { this.GetComponent<SpriteRenderer>().sprite = img[1]; }
            if ((i == 1) & (fr > decision_frame + 100)&(subgame_soju_manager.p==1))
            { this.GetComponent<SpriteRenderer>().sprite = null; }
            if ((i == 1) & (fr > decision_frame + 200) & (subgame_soju_manager.p == 0))
            {
                this.GetComponent<SpriteRenderer>().sprite = null;
                    }

        }

   



    }
}
