using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devilmanager : MonoBehaviour
{
    int frm = 0;
    public Sprite img;
    int getdarkframe = 0;
    public static int dvl=0;
    int nosub1 = 0;
    int differenceframe = 0;
    int endframe = 0;
    public static int withframe = 0;
    public static int decisionframe = 0;
    int afterframe = 0;
    public Sprite sojufail;
    public GameObject UII;
    // Start is called before the first frame update
    void Start()
    {
       
        this.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        frm++;
        if (rspmanager.decision_frame > 0) afterframe++;

        if (rspmanager.frame > 0)
        { differenceframe = frm - rspmanager.frame; }

        if ((frm > handmanager.decision_frame + 100) & (handmanager.decision_frame > 0))
        { if (subgame_soju_manager.p==1)this.GetComponent<SpriteRenderer>().sprite = img;

        }

        if ((frm > handmanager.decision_frame + 200) & (handmanager.decision_frame > 0))
        {dvl = 1;}

        if (dvl == 1)
        { this.GetComponent<SpriteRenderer>().sprite = null;
            
        }
        
        if ((script.devilon==1)&(rspmanager.decision_frame > 0)&(((rspmanager.userrsp==0)&(rspmanager.p==2))|((rspmanager.userrsp==1)&(rspmanager.p==0))|((rspmanager.p==1)&(rspmanager.userrsp==2))))
        { this.GetComponent<SpriteRenderer>().sprite = img; }
        if ((afterframe> rspmanager.decision_frame) && (rspmanager.decision_frame > 0))
        { this.GetComponent<SpriteRenderer>().sprite = null;
            script.aftersub2 = 1;
            
 
        }


        if (GaugeManager.val > 0.66)  nosub1 = 1;
    }
}
