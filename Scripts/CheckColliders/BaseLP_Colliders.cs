using UnityEngine;

public class BaseLP_Colliders : MonoBehaviour
{
    //Script encargado de checkear las coliciones de la CESTA para identificar cual es su comportamiento y posición actual
    //Colliders en Escenarios > Colliders > EjeCesta_Check_Colliders

    //Si se quiere saber donde se encuentran los colliders con los que se activan los booleanos
    //buscar en el inspector el nombre del objeto mismo

    [Header("--Lado Reactor")]
    public static bool carroEnReactor;
    public static bool reactorVolteadorArriba;
    public static bool reactorVolteadorAbajo;

    [Header("--Lado Combustible")]
    public static bool carroEnCombustible;
    public static bool combustibleVolteadorArriba;
    public static bool combustibleVolteadorAbajo;

    public static void ResetColliders() //Función para volver los booleanos a 0 (cero) para cuando se reinicia el simulador
    {
        carroEnReactor = false;
        reactorVolteadorArriba = false;
        reactorVolteadorAbajo = false;
        carroEnCombustible = false;
        combustibleVolteadorArriba = false;
        combustibleVolteadorAbajo = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CarroEnReactor")
        {
            carroEnReactor = true;
        }
        else if (other.gameObject.name == "ReactorVolteadorArriba")
        {
            reactorVolteadorArriba = true;
        }
        else if (other.gameObject.name == "ReactorVolteadorAbajo")
        {
            reactorVolteadorAbajo = true;
        }
        else if (other.gameObject.name == "CarroEnCombustible")
        {
            carroEnCombustible = true;
        }
        else if (other.gameObject.name == "CombustibleVolteadorArriba")
        {
            combustibleVolteadorArriba = true;
        }
        else if (other.gameObject.name == "CombustibleVolteadorAbajo")
        {
            combustibleVolteadorAbajo = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "CarroEnReactor")
        {
            carroEnReactor = true;
        }
        else if (other.gameObject.name == "ReactorVolteadorArriba")
        {
            reactorVolteadorArriba = true;
        }
        else if (other.gameObject.name == "ReactorVolteadorAbajo")
        {
            reactorVolteadorAbajo = true;
        }
        else if (other.gameObject.name == "CarroEnCombustible")
        {
            carroEnCombustible = true;
        }
        else if (other.gameObject.name == "CombustibleVolteadorArriba")
        {
            combustibleVolteadorArriba = true;
        }
        else if (other.gameObject.name == "CombustibleVolteadorAbajo")
        {
            combustibleVolteadorAbajo = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CarroEnReactor")
        {
            carroEnReactor = false;
        }
        else if (other.gameObject.name == "ReactorVolteadorArriba")
        {
            reactorVolteadorArriba = false;
        }
        else if (other.gameObject.name == "ReactorVolteadorAbajo")
        {
            reactorVolteadorAbajo = false;
        }
        else if (other.gameObject.name == "CarroEnCombustible")
        {
            carroEnCombustible = false;
        }
        else if (other.gameObject.name == "CombustibleVolteadorArriba")
        {
            combustibleVolteadorArriba = false;
        }
        else if (other.gameObject.name == "CombustibleVolteadorAbajo")
        {
            combustibleVolteadorAbajo = false;
        }
    }
}
