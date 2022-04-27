using UnityEngine;
using UnityEngine.UI;

public class Luz_Lado_Reactor_CarroTrans : MonoBehaviour
{
    //Script que se encarga del cambio de color de la luz correspondiente

    public Animator eje_cesta_animator;
    Image botonImage;

    private void Start()
    {
        botonImage = GetComponent<Image>();
    }

    private void LateUpdate()
    {
        //Condición para cuando la animación de Desplazamiento se encuentra ocurriendo
        if (eje_cesta_animator.GetCurrentAnimatorStateInfo(0).IsTag("Desplazamiento"))
        {
            botonImage.color = new Color(0f, 0f, 1f, botonImage.color.a); //Blue
        }
        else
        {
            botonImage.color = new Color(1f, 1f, 1f, botonImage.color.a); //White
        }
    }
}
