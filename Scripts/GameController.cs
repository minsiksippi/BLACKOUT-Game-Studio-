using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	///***********************************************************************
	/// Main GameController Class.
	/// It supports two different modes: "Escape" & "Survival"
	/// in escape mode, user must escape through various mazes.
	/// in survival mode, user must avoid enemyballs reaching the bottom of the screen.
	/// 
	/// This class clones the maze and enemyball objects in the game.
	/// It also manages the difficulty steep of the game, by increasing the movement speed of the elements.
	///***********************************************************************0

	static int gameMode = 0; 				//escape by default
											//index[0] = escape
											//index[1] = survival

	//Difficulty variables
	public static float moveSpeed; 			//Global speed of moving items (mazes)
	public static float cloneInterval; 		//clone maze and enenmyball every N seconds
	
	//leveling vars
	public static int currentLevel = 1;		//Start from easy settings (1 = very easy ---> 10 = very hard)	
	private float levelJump = 15.0f; 		//increase the level every N seconds

	private Vector3 startPoint;				//starting point of the clones object
	private float levelPassedTime;			//passed time since we started the game
	private float levelStartTime;			//time of starting the game
	
	//Gamevver state
	public static bool gameOver;			//Gameover plane object
	private bool gameOverFlag;              //Run the gameover sequence just once

    public static bool gameEnd;            //Gameover plane object
    private bool gameEndFlag;              //Run the gameover sequence just once

    public static bool gameFail;

    //AudioClips
    public AudioClip levelAdvanceSfx;
	public AudioClip gameoverSfx;
	
	//maze & enemyball creation flag
	private bool createMaze;				//can we clone a new maze?
	private bool createEnemyBall;			//can we clone a new enemyball?
    private bool createEnemyYak;
    private bool createEnemyDrink;

	//maze types
	public GameObject[] maze;				//Array of all available mazes
	public GameObject enemyBall;			//reference to the only enemyball object
    public GameObject yak;
    public GameObject drink;
	
	//Game finish variables
	public GameObject gameOverPlane;		//reference to gameover plane (activates when we hit a maze)
	public GameObject mainBackground;		//reference to the main background object (to modify its color)
	public GameObject player;				//Reference to main ball object	
	
	
	///***********************************************************************
	/// Init everything here
	///***********************************************************************
	void Awake() {

		gameOverPlane.SetActive(false);				//hide the gameover plane
		mainBackground.GetComponent<Renderer>().material.color = new Color(1, 1, 1);	//set the background color to default
		gameMode = PlayerPrefs.GetInt("GameMode");	//check game mode

		createMaze = true;			//allow maze creation
		createEnemyBall = true;		//allow enemyball creation
        createEnemyYak = true;
        createEnemyDrink = true;

		currentLevel = 1;				
		levelPassedTime = 0;
		levelStartTime = 0;
		moveSpeed = 1.2f;
		cloneInterval = 1.0f;
		gameOver = false;
		gameOverFlag = false;
        gameEnd = false;
        gameEndFlag = false;
        gameFail = false;
        
        
    }
	
	
	///***********************************************************************
	/// Main FSM
	///***********************************************************************
	void Update() {

		//If we have lost the set
		if(gameOver) {

			if(!gameOverFlag) {
				gameOverFlag = true;
				playSfx(gameoverSfx);
				//show gameover menu
				processGameover();
			}

			return;
		}

        if(gameEnd)
        {
            processGameEnd();
            //TimeManager.time.value = 1;

        }

        if(gameFail)
        {
            processGameFail();
        }

		//Escape or Survival modes ?
		if(gameMode == 0) {
			//if we are allowed to spawn a maze
			if(createMaze) 
				cloneMaze(); 
		} else 
        {
			//if we are allowed to spawn enemyBall
			if(createEnemyBall)
            {
                cloneEnemyBall();
                //cloneEnemyYak();
            }
            if(createEnemyYak)
            {
                cloneEnemyYak();
            }
            if(createEnemyDrink)
            {
                cloneEnemyDrink();
            }
				
		}
		
		//if the game is not yet finished, make it harder and harder by increasing the objects movement speed
		modifyLevelDifficulty();
		
	}
	
	///***********************************************************************
	/// Clone Maze item based on a simple chance factor
	///***********************************************************************
	void cloneMaze() {
		createMaze = false;
		startPoint = new Vector3( Random.Range(-1.0f, 1.0f) , 0.5f, 7);
		Instantiate(maze[Random.Range(0, maze.Length)], startPoint, Quaternion.Euler( new Vector3(0, 0, 0)));	
		StartCoroutine(reactiveMazeCreation());
	}


	///***********************************************************************
	/// Clone a new enemyball object and let them have random sizes
	///***********************************************************************
	void cloneEnemyBall() {
		createEnemyBall = false;
		startPoint = new Vector3( Random.Range(-10f, 10f) , 0.5f, 7);
		GameObject eb = Instantiate(enemyBall, startPoint, Quaternion.Euler( new Vector3(0, 0, 0))) as GameObject;
        eb.name = "enemyBall";

        float scaleModifier = 0.25f;
		eb.transform.localScale = new Vector3(eb.transform.localScale.x + scaleModifier,
		                                      eb.transform.localScale.y,
		                                      eb.transform.localScale.z + scaleModifier);


        StartCoroutine(reactiveEnemyBallCreation());
	}

    
    void cloneEnemyYak()
    {
        createEnemyYak = false;
        startPoint = new Vector3(Random.Range(-10f, 10f), 0.5f, 7);
        GameObject eb2 = Instantiate(yak, startPoint, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        eb2.name = "enemyYak";

        float scaleModifier = -0.4f;
        eb2.transform.localScale = new Vector3(eb2.transform.localScale.x + scaleModifier, eb2.transform.localScale.y, eb2.transform.localScale.z + scaleModifier);

        StartCoroutine(reactiveEnemyYakCreation());
    }

    void cloneEnemyDrink()
    {
        createEnemyDrink = false;
        startPoint = new Vector3(Random.Range(-10f, 10f), 0.5f, 7);
        GameObject eb3 = Instantiate(drink, startPoint, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        eb3.name = "enemyDrink";

        float scaleModifier = 0.3f;
        eb3.transform.localScale = new Vector3(eb3.transform.localScale.x + scaleModifier, eb3.transform.localScale.y, eb3.transform.localScale.z + scaleModifier);

        StartCoroutine(reactiveEnemyDrinkCreation());
    }


    //enable this controller to be able to clone maze objects again
    IEnumerator reactiveMazeCreation() {
		yield return new WaitForSeconds(cloneInterval);
		createMaze = true;
	}


	//enable this controller to be able to clone enemyball objects again
	IEnumerator reactiveEnemyBallCreation() {
		yield return new WaitForSeconds(0.35f);
        
        createEnemyBall = true;
	}
    
    IEnumerator reactiveEnemyYakCreation()
    {
        yield return new WaitForSeconds(0.5f);

        createEnemyYak = true;
    }

    IEnumerator reactiveEnemyDrinkCreation()
    {
        yield return new WaitForSeconds(30f);

        createEnemyDrink = true;
    }



    ///***********************************************************************
    /// Here can increase gameSpeed and decrease itemCloneInterval values to 
    /// make the game harder.
    ///***********************************************************************
    void modifyLevelDifficulty() {

		levelPassedTime = Time.timeSinceLevelLoad;
		if(levelPassedTime > levelStartTime + levelJump) {

			//increase level difficulty (but limit it to a maximum level of 10)
			if(currentLevel < 10) {

				currentLevel += 1;

				//let the player know what happened to him/her
				playSfx(levelAdvanceSfx);

				//increase difficulty by increasing movement speed
				moveSpeed += 0.6f;

				//clone items faster
				cloneInterval -= 0.18f; //very important!!!
				print ("cloneInterval: " + cloneInterval);
				if(cloneInterval < 0.3f) cloneInterval = 0.3f;

				levelStartTime += levelJump;

				//Background color correction (fade to red)
				float colorCorrection = currentLevel / 10.0f;
				//print("colorCorrection: " + colorCorrection);
				mainBackground.GetComponent<Renderer>().material.color = new Color(1, 
								                                                   1 - colorCorrection, 
								                                                   1 - colorCorrection);
			}
		}
	}
	
	
	///***********************************************************************
	/// Game Over routine
	///***********************************************************************
	void processGameover() {
		gameOverPlane.SetActive(true);
	}

    void processGameEnd()
    {
        SceneManager.LoadScene("Ending");
        //break;
    }

    void processGameFail()
    {
        SceneManager.LoadScene("Lose");
    }

	///***********************************************************************
	/// Play audioclips
	///***********************************************************************
	void playSfx(AudioClip _sfx) {
		GetComponent<AudioSource>().clip = _sfx;
		if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
	}	

}