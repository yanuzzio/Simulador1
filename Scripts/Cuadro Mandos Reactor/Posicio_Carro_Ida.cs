using UnityEngine;
using UnityEngine.UI;

public class Posicio_Carro_Ida : MonoBehaviour
{
    [Header("-- Acci�n")]
    public int numDeProceso; //Valores por el cual el bot�n se acciona (modificado desde el inspector)

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
    public void volteador_Abajo()
    {
        if(Proceso.canReproduceAnimation)
        {
            #region Condiciones para cuando el elemento se encuentra en el contenedor y se sigue el camino de ida o vuelta de la secuencia

            if (Proceso.numProceso == numDeProceso && Proceso.marchaIda
                && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.reactorVolteadorAbajo)
            {
                SelectorRotation();

                Proceso.numProceso++;

                Tutorial.consejo4 = true; //Tutorial

                mainAnimatorController.Desplazamiento_Ida(); //Funci�n para disparar el respectivo trigger de la animaci�n
            }
            else if(!Tutorial.canDoTutorial)
            {
                //Condici�n contraria del bot�n "Posicio_Carro_Vuelta"
                if (Proceso.numProcesoRev == (3 + 1) && Proceso.marchaIda
                    && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.reactorVolteadorAbajo)
                {
                    SelectorRotation();

                    Proceso.numProcesoRev--;

                    mainAnimatorController.Desplazamiento_Ida(); //Funci�n para disparar el respectivo trigger de la animaci�n
                } 
                #endregion

                #region Condiciones para cuando el elemento NO SE ENCUENTRA en la base y se sigue un camino libre
                else if (BaseLP_Colliders.reactorVolteadorAbajo && Proceso.marchaIda)
                {
                    SelectorRotation();

                    mainAnimatorController.SE_Desplazamiento_Ida(); //Funci�n para disparar el respectivo trigger de la animaci�n
                }
                #endregion

                //Condiciones de RESTRICCION
                else if(!Proceso.marchaIda && BaseLP_Colliders.reactorVolteadorAbajo)
                {
                    string descriptionAction = "Transferimiento autom�tico no activado";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 0);
                }
                else if(BaseLP_Colliders.carroEnReactor && !BaseLP_Colliders.reactorVolteadorAbajo)
                {
                    string descriptionAction = "La cesta no se encuentra en posici�n horizontal";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 2);
                }
                else if (!BaseLP_Colliders.carroEnReactor)
                {
                    string descriptionAction = "El carro no se encuentra en el lado reactor";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 3);
                }
            }
            else if (Proceso.numProceso != numDeProceso)
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
