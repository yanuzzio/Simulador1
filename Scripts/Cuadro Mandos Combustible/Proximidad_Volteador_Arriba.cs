using UnityEngine;
using UnityEngine.UI;

public class Proximidad_Volteador_Arriba : MonoBehaviour
{
    [Header("-- Acción")]
    public int numDeProcesoRev; //Valores por el cual el botón se acciona (modificado desde el inspector)

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
    public void volteador_Arriba()
    {
        if(Proceso.canReproduceAnimation)
        {
            #region Condiciones para cuando el elemento se encuentra en el contenedor y se sigue el camino de ida o vuelta de la secuencia

            if (Proceso.numProcesoRev == numDeProcesoRev && Proceso.marchaIda
                && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.reactorVolteadorAbajo)
            {
                SelectorRotation();

                Proceso.numProcesoRev++;

                Tutorial.consejo11 = true; //Tutorial

                mainAnimatorController.Volteo_AscensoIda(); //Función para disparar el respectivo trigger de la animación
            }
            else if(!Tutorial.canDoTutorial)
            {
                //Condición contraria del botón "Proximidad_Volteador_Abajo"
                if (Proceso.numProceso == (1 + 1) && Proceso.marchaIda
                    && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.reactorVolteadorAbajo)
                {
                    SelectorRotation();

                    Proceso.numProceso--;

                    mainAnimatorController.Volteo_AscensoIda(); //Función para disparar el respectivo trigger de la animación
                }
                #endregion

                #region Condiciones para cuando el elemento NO SE ENCUENTRA en la base y se sigue un camino libre
                else if (Proceso.marchaIda && BaseLP_Colliders.reactorVolteadorAbajo)
                {
                    SelectorRotation();

                    mainAnimatorController.SE_Volteo_AscensoIda(); //Función para disparar el respectivo trigger de la animación
                }
                #endregion

                //Condiciones de RESTRICCION
                else if (!Proceso.marchaIda && BaseLP_Colliders.reactorVolteadorAbajo)
                {
                    string descriptionAction = "Transferimiento automático no activado";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 0);
                }
                else if (!Proceso.marchaIda && !BaseLP_Colliders.reactorVolteadorAbajo)
                {
                    string descriptionAction = "Transferimiento automático no activado";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 0);
                }
                else if (Proceso.marchaIda && !BaseLP_Colliders.reactorVolteadorAbajo)
                {
                    string descriptionAction = "La cesta no se encuentra en posición horizontal";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 2);
                }
            }
            else if (Proceso.numProcesoRev != numDeProcesoRev)
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
        if (selector.transform.rotation.z >= 0.3f) // Valor de z para poder controlar cuando la perilla esta hacia un lado o hacia el otro
        {
            selector.transform.eulerAngles = new Vector3(selector.transform.eulerAngles.x, selector.transform.eulerAngles.y, 405);
        }
        else if (selector.transform.rotation.z <= -0.3f)
        {
            selector.transform.eulerAngles = new Vector3(selector.transform.eulerAngles.x, selector.transform.eulerAngles.y, 315);
        }
    }
}
