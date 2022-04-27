using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestExamen : MonoBehaviour
{
    public Image image;
    public Button button1;
    public Button button2;
    public Button button3;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(LightOon);
        if(2%2==1)
        {
            Debug.Log("asd");
        }
    }

    private void Update()
    {
        button2.onClick.AddListener(LightOon);
    }

   /* private void OnTriggerEnter2D(Collider other)
    {
        button3.onClick.AddListener(LightOon);
    }*/

    void LightOon()
    {
        image.color = Color.green;
    }

}
