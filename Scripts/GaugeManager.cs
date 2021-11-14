using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour
{
    [SerializeField]
    public Slider gauge;
    public static float val;
    int win_subgame1 = 0;
    public static int win_subgame2 = 0;
    public static int standard1 = 0;
    public static int standard2 = 0;
    int nosub1 = 0;
    // Start is called before the first frame update
    void Start()
    {
        gauge.value = 0;
    }

    // Update is called once per frame
    void Update()
    { //if ((script.aftersub2==1)|((PlayerManager.scoremss > 0) & ((PlayerManager.scoremss<33)|((devilmanager.dvl==1)&(nosub1==0)))))

      if(((PlayerManager.scoremss < 33) &(devilmanager.dvl == 0))|((devilmanager.dvl==1) &(nosub1==0))|(standard2==1))
            PlayerManager.scoremss= PlayerManager.scoremss-(float)0.05;

        if ((subgame_soju_manager.p==1) & (win_subgame1 == 0)&(devilmanager.dvl==1)&(standard1==1))
        {
            PlayerManager.scoremss = PlayerManager.scoremss + 5;

            win_subgame1 = 1;
        }
        if ((((rspmanager.userrsp==0)&(rspmanager.p==2))|((rspmanager.userrsp==1)&(rspmanager.p==0))|((rspmanager.userrsp==2)&(rspmanager.p==1))) & (win_subgame2==1)&(standard2==1))
        { PlayerManager.scoremss = PlayerManager.scoremss + 5;
            win_subgame2 = 1;
        }
        val = (float)PlayerManager.scoremss / (float)100;
        gauge.value = val;
        //if (val >= 1)
        //{ GameController.gameOver = true; }
        if (val > 0.66)
        { nosub1 = 1; }
    }
}
