using UnityEngine;
using UnityEngine.UI;

public class BotonCamera : MonoBehaviour
{
    //Script que se encarga de modifcar el alpha segun cual botón (1 o 2) se selecciona al clickear en la minicamera
    //Canvas > MiniCamera > Edge > BotonCamera1/BotonCamera2

    public void CameraColorAplhaOne(Image image) //Función llamada en el botón que se selecciona
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    public void CameraColorAplhaHalf(Image image) //Función llamada en el botón que se selecciona
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);
    }
}
