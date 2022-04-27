using UnityEngine;

public class ImageFade : MonoBehaviour
{
    //Fade que ocurre para "ocultar" la repocisión de los objetos (EjeCesta, ElementoSP, etc)

    public void EnableImage() //Función que se llama al final de la animación del GameObject ImagenFade
    {
        this.gameObject.SetActive(false);
    }
}
