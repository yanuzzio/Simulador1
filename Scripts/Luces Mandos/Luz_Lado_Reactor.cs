using UnityEngine;
using UnityEngine.UI;

public class Luz_Lado_Reactor : MonoBehaviour
{
    //Script que se encarga del cambio de color de la luz correspondiente

    Image botonImageIzq;

    void Start()
    {
        botonImageIzq = GetComponent<Image>();
    }

    void Update()
    {
        if(BaseLP_Colliders.carroEnReactor){
            botonImageIzq.color = new Color(0f, 0f, 0.7f, botonImageIzq.color.a); //Blue
        }
        else
        {
            botonImageIzq.color = new Color(1f, 1f, 1f, botonImageIzq.color.a); //White
        }
    }
}
