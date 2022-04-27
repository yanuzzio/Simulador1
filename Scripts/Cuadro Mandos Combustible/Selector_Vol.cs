using UnityEngine;
using UnityEngine.UI;

public class Selector_Vol : MonoBehaviour
{
    [Header("-- Descenso")]
    public int numDeProceso; //Valores por el cual el bot�n se acciona (modificado desde el inspector)
    [Space]

    [Header("-- Ascenso")]
    public int numDeProcesoRev; //Valores por el cual el bot�n se acciona (modificado desde el inspector)

    [Space]
    [Space]

    public Image selector;

    WarningsController warnings;
    MainAnimatorController mainAnimatorController;

    private void Start()
    {
        warnings = GameObject.FindGameObjectWithTag("Warning").GetComponent<WarningsController>();
        mainAnimatorController = GameObject.FindGameObjectWithTag("Warning").GetComponent<MainAnimatorController>();
    }
    public void selector_volteo()
    {
        if(Proceso.canReproduceAnimation)
        {
            #region Condiciones para cuando el elemento se encuentra en el contenedor y se sigue el camino de ida o vuelta de la secuencia

            if (Proceso.numProceso == numDeProceso && Proceso.numProcesoRev == 0 
                && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.combustibleVolteadorAbajo) //Asceso
            {
                SelectorRotation();

                Proceso.numProceso ++;
                Proceso.numProcesoRev++;

                Tutorial.consejo5 = true; //Tutorial

                mainAnimatorController.Volteo_AscensoVuelta(); //Funci�n para disparar el respectivo trigger de la animaci�n

            }
            else if(Proceso.numProcesoRev == numDeProcesoRev && Proceso.marchaVuelta
                && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.combustibleVolteadorArriba) //Descenso
            {
                SelectorRotation();

                Proceso.numProcesoRev++;

                Tutorial.consejo9 = true; //Tutorial

                mainAnimatorController.Volteo_DescensoVuelta(); //Funci�n para disparar el respectivo trigger de la animaci�n
            }
            else if (!Tutorial.canDoTutorial)
            {
                if (Proceso.numProceso == (numDeProceso + 1) && Proceso.numProcesoRev == (0 + 1) && Proceso.marchaVuelta
                    && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.combustibleVolteadorArriba) //Descenso
                {
                    SelectorRotation();

                    Proceso.numProceso--;
                    Proceso.numProcesoRev--;

                    mainAnimatorController.Volteo_DescensoVuelta(); //Funci�n para disparar el respectivo trigger de la animaci�n

                }
                else if (Proceso.numProcesoRev == (numDeProcesoRev + 1) && Proceso.marchaVuelta
                    && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.combustibleVolteadorAbajo) //Ascenso
                {
                    SelectorRotation();

                    Proceso.numProcesoRev--;

                    mainAnimatorController.Volteo_AscensoVuelta(); //Funci�n para disparar el respectivo trigger de la animaci�n
                }
                #endregion

                #region Condiciones para cuando el elemento NO SE ENCUENTRA en la base y se sigue un camino libre
                else if(BaseLP_Colliders.combustibleVolteadorAbajo && Proceso.marchaVuelta)
                {
                    SelectorRotation();

                    mainAnimatorController.SE_Volteo_AscensoVuelta(); //Funci�n para disparar el respectivo trigger de la animaci�n
                }
                else if (BaseLP_Colliders.combustibleVolteadorArriba && Proceso.marchaVuelta)
                {
                    SelectorRotation();

                    mainAnimatorController.SE_Volteo_DescensoVuelta(); //Funci�n para disparar el respectivo trigger de la animaci�n
                }
                #endregion

                //Condiciones de RESTRICCI�N
                else if(!BaseLP_Colliders.carroEnCombustible)
                {
                    string descriptionAction = "El carro no se encuentra en el lado combustible";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 3);
                }
                else if (!Proceso.marchaVuelta && BaseLP_Colliders.carroEnCombustible)
                {
                    string descriptionAction = "Transferimiento autom�tico no activado";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 0);
                }
            }
            else if ((Proceso.numProceso != numDeProceso) || Proceso.numProcesoRev != numDeProcesoRev)
            {
                warnings.CorrutineWarningWrogButton();
            }
        }
        else if (!Proceso.canReproduceAnimation)
        {
            warnings.CorrutineWarningMachinaryOn();
        }
    }

    void SelectorRotation() //Funci�n para que el selector cambie su rotaci�n seg�n su actual rotaci�n
    {
        if (selector.transform.rotation.z >= 0.3) // Valor de z para poder controlar cuando la perilla esta hacia un lado o hacia el otro
        {
            selector.transform.eulerAngles = new Vector3(selector.transform.eulerAngles.x, selector.transform.eulerAngles.y, 405);
        }
        else if (selector.transform.rotation.z <= -0.3)
        {
            selector.transform.eulerAngles = new Vector3(selector.transform.eulerAngles.x, selector.transform.eulerAngles.y, 315);
        }
    }
}
