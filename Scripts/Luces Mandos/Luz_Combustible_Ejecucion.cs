using UnityEngine;
using UnityEngine.UI;

public class Luz_Combustible_Ejecucion : MonoBehaviour
{
    //Script que se encarga del cambio de color de la luz correspondiente

    Image botonImageIzq;
    public RectTransform selectorTransferAuto;

    void Start()
    {
        botonImageIzq = GetComponent<Image>();
    }

    void Update()
    {
        if (selectorTransferAuto.transform.rotation.z <= -0.3f) 
        {
            botonImageIzq.color = new Color(0.7f, 0f, 0f, botonImageIzq.color.a); //Blue
        }
        else
        {
            botonImageIzq.color = new Color(1f, 1f, 1f, botonImageIzq.color.a); //White
        }
    }
}
