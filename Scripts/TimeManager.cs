using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    public Slider time;
    int nosub1 = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        time.value = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(((GaugeManager.val<0.33)&(devilmanager.dvl==0))|((devilmanager.dvl==1)&(GaugeManager.val<0.66)&(script.aftersub2==0))|(script.aftersub2==1))
        { time.value = (float)time.value - (float)0.0001; }
        
        if(time.value <=0)
        {
            GameController.gameFail = true;
        }
    }
}
