using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectionManager : MonoBehaviour
{
    private float buttonAnimationSpeed = 9.0f;	//button scale animation speed
    //public Material drink1, drink2, drink3;
    //public Material drink4, drink5, drink6;
    //public Material drink7, drink8, drink9, drink10;
    public Material m1, m2, m3, m4, m5, m6, m7, m8, m9, m10;

    public GameObject col1, col2, col3;
    public GameObject col4, col5, col6;
    public GameObject col7, col8, col9, col10;
    // Start is called before the first frame update


    void Start()
    {

        if (EnemyDrinkController.dr1==1)
        {
            col1.GetComponent<MeshRenderer>().material = m1;
        }
        
        if (EnemyDrinkController.dr2 == 1)
        {
            col2.GetComponent<MeshRenderer>().material = m2;
        }
        if (EnemyDrinkController.dr3 == 1)
        {
            col3.GetComponent<MeshRenderer>().material = m3;
        }
        if (EnemyDrinkController.dr4 == 1)
        {
            col4.GetComponent<MeshRenderer>().material = m4;
        }
        if (EnemyDrinkController.dr5 == 1)
        {
            col5.GetComponent<MeshRenderer>().material = m5;
        }
        if (EnemyDrinkController.dr6 == 1)
        {
            col6.GetComponent<MeshRenderer>().material = m6;
        }
        if (EnemyDrinkController.dr7 == 1)
        {
            col7.GetComponent<MeshRenderer>().material = m7;
        }
        if (EnemyDrinkController.dr8 == 1)
        {
            col8.GetComponent<MeshRenderer>().material = m8;
        }
        if (EnemyDrinkController.dr9 == 1)
        {
            col9.GetComponent<MeshRenderer>().material = m9;

        }
        if (EnemyDrinkController.dr10 == 1)
        {
            col10.GetComponent<MeshRenderer>().material = m10;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(touchManager2());
    }

    private RaycastHit hitInfo;
    private Ray ray;
    IEnumerator touchManager2()
    {

        //Mouse of touch?
        if (Input.touches.Length > 0 && Input.touches[0].phase == TouchPhase.Ended)
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        else if (Input.GetMouseButtonUp(0))
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        else
            yield break;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject objectHit = hitInfo.transform.gameObject;
            switch (objectHit.name)
            {
                case "Btn-Mode-01":
                    //UnPauseGame();
                    StartCoroutine(animateButton(objectHit));
                    yield return new WaitForSeconds(1.0f);
                    SceneManager.LoadScene("Menu");
                    break;

            }
        }
    }
    /*
    void UnPauseGame()
    {
        print("Unpause");
        PauseManager.isPaused = false;
        Time.timeScale = 1.0f;
        AudioListener.volume = 1.0f;
        if (PauseManager.pausePlane)
            PauseManager.pausePlane.SetActive(false);
        PauseManager.currentPage = Page.PLAY;
    }
    */

    IEnumerator animateButton(GameObject _btn)
    {

        Vector3 startingScale = _btn.transform.localScale;
        Vector3 destinationScale = startingScale * 1.1f;
        float t = 0.0f;
        while (t <= 1.0f)
        {
            t += Time.deltaTime * buttonAnimationSpeed;
            _btn.transform.localScale = new Vector3(Mathf.SmoothStep(startingScale.x, destinationScale.x, t),
                                                    _btn.transform.localScale.y,
                                                    Mathf.SmoothStep(startingScale.z, destinationScale.z, t));
            yield return 0;
        }

        float r = 0.0f;
        if (_btn.transform.localScale.x >= destinationScale.x)
        {
            while (r <= 1.0f)
            {
                r += Time.deltaTime * buttonAnimationSpeed;
                _btn.transform.localScale = new Vector3(Mathf.SmoothStep(destinationScale.x, startingScale.x, r),
                                                        _btn.transform.localScale.y,
                                                        Mathf.SmoothStep(destinationScale.z, startingScale.z, r));
                yield return 0;
            }
        }


    }
}
