using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toonbackmanager : MonoBehaviour
{
    int i = 0;
    public Sprite back;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = back;
    }

    // Update is called once per frame
    void Update()
    { if (Input.GetMouseButtonDown(0)) i++;

        if (i >= 4)
            this.GetComponent<SpriteRenderer>().sprite = null;

        
    }
}
