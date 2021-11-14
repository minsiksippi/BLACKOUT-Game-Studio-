using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputTextManager : MonoBehaviour
{
    public InputField input;
    //public InputField text;
    public Text text;
    public Text memo;
    public GameObject back;
    public Material back2;
    private float buttonAnimationSpeed = 9.0f;	//button scale animation speed
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(touchManager2());
    }

    public void Test(Text text)
    {
        text.text = input.text;
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
                case "Btn-Mode-02":
                    //UnPauseGame();
                    StartCoroutine(animateButton(objectHit));
                    yield return new WaitForSeconds(1.0f);
                    SceneManager.LoadScene("Menu");
                    break;

                case "Btn-Mode-01":
                    //UnPauseGame();
                    StartCoroutine(animateButton(objectHit));
                    yield return new WaitForSeconds(1.0f);
                    back.GetComponent<MeshRenderer>().material = back2;
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