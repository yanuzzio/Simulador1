using UnityEngine;
using UnityEngine.UI;

public class MainButtonLeft : MonoBehaviour
{
    [Header("-- Descenso")]
    public int numDeProceso; //Valores por el cual el botón se acciona (modificado desde el inspector)
    [Space]

    [Header("-- Ascenso")]
    public int numDeProcesoRev; //Valores por el cual el botón se acciona (modificado desde el inspector)

    [Space]
    [Space]

    public Image selector; //Selector propio del objeto para cambiar de rotación cuando se acciona

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

            if (!Proceso.descensoIda && Proceso.numProceso == numDeProceso
                && ElementoSP_Colliders.elementoEnGruaIzq && BaseLP_Colliders.reactorVolteadorArriba) //Descenso
            {
                SelectorRotation();

                Proceso.descensoIda = true;
                Proceso.numProceso++;

                Tutorial.consejo1 = true; //Tutorial

                mainAnimatorController.Descenso_Ida(); //Función para disparar el respectivo trigger de la animación
            }
            else if(Proceso.numProcesoRev == numDeProcesoRev
                && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.reactorVolteadorArriba) //Ascenso
            {
                SelectorRotation();

                Proceso.numProcesoRev++;
                Proceso.ascensoIda = true;

                Tutorial.consejo12 = true;  //Tutorial

                mainAnimatorController.Ascenso_Ida(); //Función para disparar el respectivo trigger de la animación
            }
            else if(!Tutorial.canDoTutorial)
            {
                //Condición para volver a realizar la acción de ascenso
                if (Proceso.descensoIda && Proceso.numProceso == (numDeProceso + 1)
                    && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.reactorVolteadorArriba) //Ascenso
                {
                    SelectorRotation();

                    Proceso.numProceso--;
                    Proceso.descensoIda = false;

                    mainAnimatorController.Ascenso_Ida(); //Función para disparar el respectivo trigger de la animación
                }
                #endregion

                //Condiciones de RESTRICCION
                else if (!ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.reactorVolteadorArriba 
                    && !ElementoSP_Colliders.elementoEnGruaIzq)
                {
                    string descriptionAction = "El elemento no se encuentra en el contenedor";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 1);
                }
                else if (ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.carroEnReactor 
                    && !BaseLP_Colliders.reactorVolteadorArriba && !ElementoSP_Colliders.elementoEnGruaIzq)
                {
                    string descriptionAction = "La cesta no se encuentra en forma vertical";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 2);
                }
                else if (ElementoSP_Colliders.elementoEnContenedor && !BaseLP_Colliders.carroEnReactor
                    && !ElementoSP_Colliders.elementoEnGruaIzq)
                {
                    string descriptionAction = "El carro no se encuentra en el lado reactor";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 3);
                }
                else if (!ElementoSP_Colliders.reactorVolteadorArriba && !ElementoSP_Colliders.elementoEnGruaIzq)
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

    void SelectorRotation() //Función para que el selector cambie su rotación según su actual rotación
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
