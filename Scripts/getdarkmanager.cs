using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getdarkmanager : MonoBehaviour
{ 
    // Start is called before the first frame update

        public Sprite square;
        private AudioSource theAudio;
    [SerializeField] private AudioClip clip;
    int soju = 0;
    public static int when = -1;
    int control = 0;
    int nosub1 = 0;
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = null;
      //  theAudio = GetComponent<AudioSource>();
        //theAudio.clip = clip;
       // theAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {

  
        soju++;
     
        if (GaugeManager.val > 0.33)
        {
            this.GetComponent<SpriteRenderer>().sprite = square;
             
           
         }

        if((devilmanager.dvl==1)&(nosub1==0))
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
            GaugeManager.standard1 = 1;
        }

        if (GaugeManager.val > 0.66)
        {
            this.GetComponent<SpriteRenderer>().sprite = square;
            nosub1 = 1;
        }
        if (script.aftersub2 == 1)
        {   this.GetComponent<SpriteRenderer>().sprite = null;
            GaugeManager.standard2 = 1;
        }

    }
}
