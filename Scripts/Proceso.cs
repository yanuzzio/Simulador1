using UnityEngine;

public class Proceso : MonoBehaviour
{
    public static bool canReproduceAnimation = true; //Booleano para saber cuando una animación se está reproduciendo

    // ---------------------------- IDA ---------------------------------------
    public static int numProceso = 0;

    public static bool descensoIda = false; //MainButtonLeft
    public static bool ascensoIda = false; //MainButtonLeft
    public static bool marchaIda = false;   //TransferAutoIda

    // ---------------------------- VUELTA ---------------------------------------
    public static int numProcesoRev = 0;

    public static bool marchaVuelta = false; //TransferAutoVuelta
    public static bool descensoVuelta = false; //MainButtonRight
    public static bool ascensoVuelta = false; //MainButtonRight

    public static void InitialValues() //Función para forzar los valores iniciales de las variables cuando se reinicia el nivel
    {
        numProceso = 0;
        numProcesoRev = 0;
        descensoIda = false;
        ascensoIda = false;
        marchaIda = false;
        marchaVuelta = false;
        descensoVuelta = false;
        ascensoVuelta = false;
        canReproduceAnimation = true;
    }
}
