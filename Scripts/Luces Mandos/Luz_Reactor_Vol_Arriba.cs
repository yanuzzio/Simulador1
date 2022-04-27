using UnityEngine;
using UnityEngine.UI;

public class Luz_Reactor_Vol_Arriba : MonoBehaviour
{
    //Script que se encarga del cambio de color de la luz correspondiente

    Image botonImage;
    void Start()
    {
        botonImage = GetComponent<Image>();
    }

    void Update()
    {
        if(BaseLP_Colliders.reactorVolteadorArriba)
        {
            botonImage.color = new Color(1f, 0.7f, 0.016f, botonImage.color.a); ; //Yellow
        }
        else
        {
            botonImage.color = new Color(1f, 1f, 1f, botonImage.color.a); //White
        }
    }
}
