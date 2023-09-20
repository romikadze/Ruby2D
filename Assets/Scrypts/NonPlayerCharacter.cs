using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        timer = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                dialogBox.SetActive(false);

            }
        }
        
    }

    public void showDialog()
    {
        timer = displayTime;
        dialogBox.SetActive(true);

    }
}
