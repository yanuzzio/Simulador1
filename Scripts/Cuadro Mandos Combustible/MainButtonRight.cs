using UnityEngine;
using UnityEngine.UI;

public class MainButtonRight : MonoBehaviour
{
    [Header("-- Descenso")]
    public int numDeProcesoRev; //Valores por el cual el botón se acciona (modificado desde el inspector)
    [Space]

    [Header("-- Ascenso")]
    public int numDeProceso; //Valores por el cual el botón se acciona (modificado desde el inspector)

    [Space]
    [Space]

    public Image selector;
    public TransferAuto_Vuelta RightTransferAuto_Vuelta;

    WarningsController warnings;
    MainAnimatorController mainAnimatorController;

    private void Start()
    {
        warnings = GameObject.FindGameObjectWithTag("Warning").GetComponent<WarningsController>();
        mainAnimatorController = GameObject.FindGameObjectWithTag("Warning").GetComponent<MainAnimatorController>();
    }
    public void volteador_Arriba()
    {
        if(Proceso.canReproduceAnimation)
        {
            #region Condiciones para cuando el elemento se encuentra en el contenedor y se sigue el camino de ida o vuelta de la secuencia

            if (!Proceso.ascensoVuelta && Proceso.numProceso == numDeProceso
                && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.combustibleVolteadorArriba) //Ascenso
            {
                SelectorRotation();

                Proceso.ascensoVuelta = true;

                RightTransferAuto_Vuelta.ResetButton(); //Función para resetear el Selector de RightTransferAuto una vez que se eleve el elemento

                Tutorial.consejo6 = true; //Tutorial
                 
                mainAnimatorController.Ascenso_Vuelta(); //Función para disparar el respectivo trigger de la animación
            }
            else if (!Proceso.descensoVuelta && Proceso.numProcesoRev == numDeProcesoRev
                && ElementoSP_Colliders.elementoEnGruaDer && BaseLP_Colliders.combustibleVolteadorArriba) //Descenso
            {
                SelectorRotation();

                Proceso.descensoVuelta = true;
                Proceso.numProcesoRev++;

                Tutorial.consejo7 = true; //Tutorial

                mainAnimatorController.Descenso_Vuelta(); //Función para disparar el respectivo trigger de la animación
            }
            else if (!Tutorial.canDoTutorial)
            {
                if (Proceso.descensoVuelta && Proceso.numProcesoRev == (numDeProcesoRev + 1)
                    && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.combustibleVolteadorArriba) //Ascenso
                {
                    SelectorRotation();

                    Proceso.numProcesoRev--;

                    Proceso.descensoVuelta = false;

                    mainAnimatorController.Ascenso_Vuelta(); //Función para disparar el respectivo trigger de la animación
                }
                #endregion

                //Condiciones de RESTRICCION
                else if (!ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.combustibleVolteadorArriba
                    && !ElementoSP_Colliders.elementoEnGruaDer)
                {
                    string descriptionAction = "El elemento no se encuentra en el contenedor";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 1);
                }
                else if (ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.carroEnCombustible 
                    && !BaseLP_Colliders.combustibleVolteadorArriba && !ElementoSP_Colliders.elementoEnGruaDer)
                {
                    string descriptionAction = "La cesta no se encuentra en forma vertical";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 2);
                }
                else if (ElementoSP_Colliders.elementoEnContenedor && !BaseLP_Colliders.carroEnCombustible
                    && !ElementoSP_Colliders.elementoEnGruaDer)
                {
                    string descriptionAction = "El carro no se encuentra en el lado combustible";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 3);
                }
                else if (!ElementoSP_Colliders.combustibleVolteadorArriba && !ElementoSP_Colliders.elementoEnGruaDer) 
                {
                    string descriptionAction = "El elemento no se encuentra al alcance de la grúa";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 1);
                }
            }
            else if (Proceso.numProceso != numDeProceso || Proceso.numProcesoRev != numDeProcesoRev)
            {
                warnings.CorrutineWarningWrogButton();
            }
        }
        else if (!Proceso.canReproduceAnimation)
        {
            warnings.CorrutineWarningMachinaryOn();
        }
    }

    void SelectorRotation() //Función llamada al evelar el elemento desde el lado derecho
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
