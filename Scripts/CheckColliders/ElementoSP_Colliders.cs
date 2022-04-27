using UnityEngine;

public class ElementoSP_Colliders : MonoBehaviour
{
    //Script encargado de checkear las coliciones del ELEMENTO para identificar cual es su comportamiento y posición actual
    //Colliders en Escenarios > Colliders > EjeCesta_Check_Colliders

    //Si se quiere saber donde se encuentran los colliders con los que se activan los booleanos
    //buscar en el inspector el nombre del objeto mismo

    public static bool elementoEnGruaIzq;
    public static bool elementoEnGruaDer;
    public static bool elementoEnContenedor;
    public static bool combustibleVolteadorArriba;
    public static bool reactorVolteadorArriba;

    public static void ResetColliders() //Función para volver los booleanos a 0 (cero) para cuando se reinicia el simulador
    {
        elementoEnGruaIzq = false;
        elementoEnGruaDer = false;
        elementoEnContenedor = false;
        combustibleVolteadorArriba = false;
        reactorVolteadorArriba = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GruaIzq")
        {
            elementoEnGruaIzq = true;
        }
        else if (other.gameObject.name == "GruaDer")
        {
            elementoEnGruaDer = true;
        }
        else if(other.gameObject.name == "ElementoEnContenedor")
        {
            elementoEnContenedor = true;
        }
        else if (other.gameObject.name == "ReactorVolteadorArriba")
        {
            reactorVolteadorArriba = true;
        }
        else if (other.gameObject.name == "CombustibleVolteadorArriba")
        {
            combustibleVolteadorArriba = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "GruaIzq")
        {
            elementoEnGruaIzq = true;
        }
        else if (other.gameObject.name == "GruaDer")
        {
            elementoEnGruaDer = true;
        }
        else if (other.gameObject.name == "ElementoEnContenedor")
        {
            elementoEnContenedor = true;
        }
        else if (other.gameObject.name == "ReactorVolteadorArriba")
        {
            reactorVolteadorArriba = true;
        }
        else if (other.gameObject.name == "CombustibleVolteadorArriba")
        {
            combustibleVolteadorArriba = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GruaIzq")
        {
            elementoEnGruaIzq = false;
        }
        else if (other.gameObject.name == "GruaDer")
        {
            elementoEnGruaDer = false;
        }
        else if (other.gameObject.name == "ElementoEnContenedor")
        {
            elementoEnContenedor = false;
        }
        else if (other.gameObject.name == "ReactorVolteadorArriba")
        {
            reactorVolteadorArriba = false;
        }
        else if (other.gameObject.name == "CombustibleVolteadorArriba")
        {
            combustibleVolteadorArriba = false;
        }
    }
}
