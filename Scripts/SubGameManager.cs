using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SubGameManager : MonoBehaviour
{
    private int num;
    private int cal = 0;
    public static int oppp=0;
    public GameObject com, user;
    public Material r1, s1, p1;
    public Text scoretext;

    // int you = 0;					// 가위바위보(가위:1, 바위:2, 보:3)
   // int com = 0;
    //int scMy = 0;					// 승패 점수 
    //int scCom = 0;


    void Start()
    {
        num = Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update()
    {
        if (num == 0)
        {
            com.GetComponent<MeshRenderer>().material = r1;
            //scoretext.text = cal;
        }
        else if (num == 1)
        {
            com.GetComponent<MeshRenderer>().material = s1;
            //scoretext.text = cal;
        }
        else
        {
            com.GetComponent<MeshRenderer>().material = p1;
            //scoretext.text = cal;
        }


        if(oppp==0)
        {
            user.GetComponent<MeshRenderer>().material = s1;
        }
        else if(oppp==1)
        {
            user.GetComponent<MeshRenderer>().material = r1;
        }
        else
        {
            user.GetComponent<MeshRenderer>().material = p1;
        }
    }

    public void ClickScissors()
    {
        oppp = 0;
        
    }

    public void ClickRock()
    {
        oppp = 1;
    }


    public void ClickPaper()
    {
        oppp = 2;

    }

}



    /*


    //--------------------------------
    // 승패 처리
    //--------------------------------
    void CheckScore(int myHand)
    {
        com = Random.Range(1, 4);       // 1~3의 난수
        objCom.GetComponent<Image>().sprite = Resources.Load<Sprite>("Game_" + com) as Sprite;
        objMy.GetComponent<Image>().sprite = Resources.Load<Sprite>("Game_" + myHand) as Sprite;

        // 승패 판정
        int k = myHand - com;

        if (k == 0)
        {
            txtScore.text = "비겼습니다";
        }
        else if (k == 1 || k == -2)
        {
            txtScore.text = "당신이 이겼습니다";
            scMy++;
        }
        else
        {
            txtScore.text = "컴퓨터가 이겼습니다";
            scCom++;
        }

        txtMy.text = "당신 : " + scMy;
        txtCom.text = "컴퓨터 : " + scCom;

        myHand = 0;
    }

    //--------------------------------
    // 화면 처리 
    //--------------------------------
    */

    
    



