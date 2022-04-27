using UnityEngine;
using UnityEngine.UI;

public class Posicio_Carro_Vuelta : MonoBehaviour
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
    public void posicion_carro()
    {
        if(Proceso.canReproduceAnimation)
        {
            #region Condiciones para cuando el elemento se encuentra en el contenedor y se sigue el camino de ida o vuelta de la secuencia

            if (Proceso.numProcesoRev == numDeProcesoRev && Proceso.marchaVuelta
                && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.combustibleVolteadorAbajo)
            {
                SelectorRotation();

                Proceso.numProcesoRev++;

                Tutorial.consejo10 = true; //Tutorial

                mainAnimatorController.Desplazamiento_Vuelta(); //Función para disparar el respectivo trigger de la animación
            }
            else if(!Tutorial.canDoTutorial)
            {
                //Condición contraria del botón "Posicio_Carro_Ida"
                if (Proceso.numProceso == (2 + 1) && Proceso.marchaVuelta
                    && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.combustibleVolteadorAbajo)
                {
                    SelectorRotation();

                    Proceso.numProceso--;

                    mainAnimatorController.Desplazamiento_Vuelta(); //Función para disparar el respectivo trigger de la animación
                }
                #endregion

                #region Condiciones para cuando el elemento NO SE ENCUENTRA en la base y se sigue un camino libre
                else if (BaseLP_Colliders.combustibleVolteadorAbajo && Proceso.marchaVuelta)
                {
                    SelectorRotation();

                    mainAnimatorController.SE_Desplazamiento_Vuelta(); //Función para disparar el respectivo trigger de la animación
                }
                #endregion

                //Condiciones de RESTRICCION
                else if (!Proceso.marchaVuelta && BaseLP_Colliders.combustibleVolteadorAbajo)
                {
                    string descriptionAction = "Transferimiento automático no activado";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 0);
                }
                else if (BaseLP_Colliders.carroEnCombustible && !BaseLP_Colliders.combustibleVolteadorAbajo)
                {
                    string descriptionAction = "La cesta no se encuentra en posición horizontal";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 2);
                }
                else if (!BaseLP_Colliders.carroEnCombustible)
                {
                    string descriptionAction = "El carro no se encuentra en el lado combustible";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 3);
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
