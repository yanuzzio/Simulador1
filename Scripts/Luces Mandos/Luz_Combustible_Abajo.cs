using UnityEngine;
using UnityEngine.UI;

public class Luz_Combustible_Abajo : MonoBehaviour
{
    //Script que se encarga del cambio de color de la luz correspondiente

    Image botonImage;
    void Start()
    {
        botonImage = GetComponent<Image>();
    }

    void Update()
    {
        if(BaseLP_Colliders.combustibleVolteadorAbajo)
        {
            botonImage.color = new Color(0f, 0.7f, 0f, botonImage.color.a); //Green
        }
        else{
            botonImage.color = new Color(1f, 1f, 1f, botonImage.color.a); //White
        }
    }
}
