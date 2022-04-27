using UnityEngine;
using UnityEngine.UI;

public class Proximidad_Volteador_Abajo : MonoBehaviour
{
    WarningsController warnings;
    public Image selector;

    private void Start()
    {
        warnings = GameObject.FindGameObjectWithTag("Warning").GetComponent<WarningsController>();
    }
    public void volteador_Arriba(){

        if(Proceso.numProcesoRev == 2 && Proceso.marchaVuelta && Proceso.canReproduceAnimation){
            if (selector.transform.rotation.z >= 0.3) // Valor de z para poder controlar cuando la perilla esta hacia un lado o hacia el otro
            {
                selector.transform.eulerAngles = new Vector3(selector.transform.eulerAngles.x, selector.transform.eulerAngles.y, 405);
            }
            else if (selector.transform.rotation.z <= -0.3)
            {
                selector.transform.eulerAngles = new Vector3(selector.transform.eulerAngles.x, selector.transform.eulerAngles.y, 315);
            }

            Proceso.numProcesoRev++;

            Tutorial.consejo11 = true;
        }
        else if(!Proceso.canReproduceAnimation)
        {
            warnings.CorrutineWarningMachinaryOn();
        }
        else if(Proceso.numProcesoRev != 3 || !Proceso.marchaVuelta)
        {
            warnings.CorrutineWarningWrogButton();
        }
    }
}
