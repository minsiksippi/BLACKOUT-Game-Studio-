using UnityEngine;
using System.Collections;



public class PlayerManager : MonoBehaviour {
	
	/// <summary>
	/// Main Player manager class.
	/// We check all player collisions here.
	/// We also calculate the score in this class. 
	/// </summary>
	
	public static int playerScore;			//player score
    public static float scorems;
    public static float scoremss=0;
    public GameObject scoreTextDynamic;     //gameobject which shows the score on screen
	int subgame_win = 0;

	void Awake() {
		playerScore = 0;
        scoremss = 0;							
		//Disable screen dimming on mobile devices
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		//Playe the game with a fixed framerate in all platforms
		Application.targetFrameRate = 60;
	}
	
	
	void Update() {
		if(!GameController.gameOver)
			calculateScore();
		if ((devilmanager.dvl == 1)&(subgame_win==0)) { playerScore = playerScore + 30;subgame_win = 1; }
	}
	
	
	///***********************************************************************
	/// calculate player's score
	/// Score is a combination of gameplay duration (while player is still alive) 
	/// and a multiplier for the current level.
	///***********************************************************************
	void calculateScore() {
		if(!PauseManager.isPaused) {
			playerScore += (int)( GameController.currentLevel * Mathf.Log(GameController.currentLevel + 1, 2) );
            //scorems++;
            scoreTextDynamic.GetComponent<TextMesh>().text = scoremss.ToString();
            //scoreTextDynamic.GetComponent<TextMesh>().text = 0;
        }
	}


	///***********************************************************************
	/// Collision detection and management
	///***********************************************************************
	void OnCollisionEnter(Collision c) {

		//collision with mazes and enemyballs leads to a sudden gameover

		if(c.gameObject.tag == "Maze") {
			print ("Game Over");
			GameController.gameOver = true;
		}

		if(c.gameObject.tag == "enemyBall") {
			Destroy(c.gameObject);
            PlayerManager.scoremss = PlayerManager.scoremss + 4;
            if(scoremss>=100) //////////
            {
                //SceneManager.LoadScene("Menu");
                //break;
                GameController.gameEnd = true;
            }
            
        }

        if (c.gameObject.tag == "enemyYak")
        {
            Destroy(c.gameObject);
			if (PlayerManager.scoremss > 0)
			{ PlayerManager.scoremss = PlayerManager.scoremss - 5; }
        }

        if (c.gameObject.tag == "enemyDrink")
        {
            Destroy(c.gameObject);
            PlayerManager.scoremss = PlayerManager.scoremss + 10;
            if (scoremss >= 100) //////////
            {
                //SceneManager.LoadScene("Menu");
                //break;
                GameController.gameEnd = true;
            }
        }
    }
	
	
	void playSfx(AudioClip _sfx) {
		GetComponent<AudioSource>().clip = _sfx;
		if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
	}
}
