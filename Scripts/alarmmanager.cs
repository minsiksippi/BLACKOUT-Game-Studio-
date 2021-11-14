using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmmanager : MonoBehaviour
{
    public Sprite girl;
	public static int frame;
	int a = 0;
	int a2 = 0;
	public static int nosub1 = 0;
	public static int getdarkframe = 0;
	public static int getdarkframe2 = 0;
	public enum Page { PLAY, PAUSE }
    private Page currentPage = Page.PLAY;
	// Start is called before the first frame update
	//public Sprite[] hand;
	public AudioSource letssulgame;
	public static bool soju = false;
	public GameObject bgm;

	
    void Start()
    {
        PauseManager.isPaused= false;
        Time.timeScale = 1.0f;
		letssulgame = GetComponent<AudioSource>();
		//letssulgame.Play();
	}

    // Update is called once per frame
    void Update()
    { frame++;

		if ((GaugeManager.val > 0.33) & (a == 0)&(devilmanager.dvl < 1))
		{
			
			a++;
			getdarkframe = frame;
			this.GetComponent<AudioSource>().Play();
			PauseGame();
		}
		if (getdarkframe == frame) { letssulgame.Play(); }
		if ((getdarkframe + 100 > frame) & (getdarkframe < frame) & (getdarkframe > 0))
		{ this.GetComponent<SpriteRenderer>().sprite = girl;
			
		}
		else if (getdarkframe + 100 < frame) this.GetComponent<SpriteRenderer>().sprite = null;

		if (((devilmanager.dvl == 1)&(nosub1 == 0))|(script.aftersub2==1))
		{ UnPauseGame();
		
		}


		if((GaugeManager.val>0.66)&(a2==0))
		{ getdarkframe2 = frame;
			a2++; this.GetComponent<AudioSource>().Play();
			Debug.Log("girl");
			PauseGame(); }
		if (getdarkframe2 == frame) { letssulgame.Play(); }
		if ((getdarkframe2 + 100 > frame) & (getdarkframe2 < frame) & (getdarkframe2 > 0))
		{
			this.GetComponent<SpriteRenderer>().sprite = girl;

		}
	}
	void PauseGame()
	{

		PauseManager.isPaused = true;
		Time.timeScale = 0;
	
		 bgm.GetComponent<AudioSource>().volume=0;
		currentPage = Page.PAUSE;
	}

	void UnPauseGame()
	{
	
		PauseManager.isPaused = false;
		Time.timeScale = 1.0f;
		bgm.GetComponent<AudioSource>().volume = 0.1f;
		currentPage = Page.PLAY;
		nosub1 = 1;
	}
}

