using UnityEngine;

public class Gruas_Colliders : MonoBehaviour
{
    public static bool gruaReactorArriba;
    public static bool gruaReactorAbajo;

    public static bool gruaCombustibleArriba;
    public static bool gruaCombustibleAbajo;

    //Si se quiere saber donde se encuentran los colliders con los que se activan los booleanos
    //buscar en el inspector el nombre del objeto mismo

    public static void ResetColliders() //Función para volver los booleanos a 0 (cero) para cuando se reinicia el simulador
    {
        gruaReactorArriba = false;
        gruaReactorAbajo = false;
        gruaCombustibleArriba = false;
        gruaCombustibleAbajo = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GruaReactorArriba")
        {
            gruaReactorArriba = true;
        }
        else if (other.gameObject.name == "GruaReactorAbajo")
        {
            gruaReactorAbajo = true;
        }
        else if(other.gameObject.name == "GruaCombustibleArriba")
        {
            gruaCombustibleArriba = true;
        }
        else if(other.gameObject.name == "GruaCombustibleAbajo")
        {
            gruaCombustibleAbajo = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "GruaReactorArriba")
        {
            gruaReactorArriba = true;
        }
        else if (other.gameObject.name == "GruaReactorAbajo")
        {
            gruaReactorAbajo = true;
        }
        else if (other.gameObject.name == "GruaCombustibleArriba")
        {
            gruaCombustibleArriba = true;
        }
        else if (other.gameObject.name == "GruaCombustibleAbajo")
        {
            gruaCombustibleAbajo = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GruaReactorArriba")
        {
            gruaReactorArriba = false;
        }
        else if (other.gameObject.name == "GruaReactorAbajo")
        {
            gruaReactorAbajo = false;
        }
        else if (other.gameObject.name == "GruaCombustibleArriba")
        {
            gruaCombustibleArriba = false;
        }
        else if (other.gameObject.name == "GruaCombustibleAbajo")
        {
            gruaCombustibleAbajo = false;
        }
    }
}
