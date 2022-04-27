using UnityEngine;
using UnityEngine.UI;

public class Luz_Lado_Combustible : MonoBehaviour
{
    //Script que se encarga del cambio de color de la luz correspondiente

    Image botonImage;

    private void Start()
    {
        botonImage = GetComponent<Image>();
    }

    void Update()
    {
        if(BaseLP_Colliders.carroEnCombustible)
        {
            botonImage.color = new Color(0f, 0f, 0.7f, botonImage.color.a); //Blue
        }
        else{
            botonImage.color = new Color(1f,1f,1f, botonImage.color.a); //White
        }
    }

}
