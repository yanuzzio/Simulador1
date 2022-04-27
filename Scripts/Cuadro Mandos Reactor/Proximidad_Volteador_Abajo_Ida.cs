using UnityEngine;
using UnityEngine.UI;

public class Proximidad_Volteador_Abajo_Ida : MonoBehaviour
{
    [Header("-- Acción")]
    public int numDeProceso; //Valores por el cual el botón se acciona (modificado desde el inspector)

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
            #region Condiciones para cuando el elemento SE ENCUENTRA en el contenedor y se sigue el camino de ida o vuelta de la secuencia

            if (Proceso.numProceso == numDeProceso && Proceso.marchaIda
                && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.reactorVolteadorArriba)
            {
                SelectorRotation();

                Proceso.numProceso++;

                Tutorial.consejo3 = true; //Tutorial

                mainAnimatorController.Volteo_DescensoIda(); //Función para disparar el respectivo trigger de la animación
            }
            else if (!Tutorial.canDoTutorial)
            {
                //Condición contraria del botón "Proximidad_Volteador_Arriba"
                if (Proceso.numProcesoRev == (4 + 1) && Proceso.marchaIda
                    && ElementoSP_Colliders.elementoEnContenedor && BaseLP_Colliders.reactorVolteadorArriba)
                {
                    SelectorRotation();

                    Proceso.numProcesoRev--;

                    mainAnimatorController.Volteo_DescensoIda(); //Función para disparar el respectivo trigger de la animación
                }
                #endregion

                #region Condiciones para cuando el elemento NO SE ENCUENTRA en la base y se sigue un camino libre
                else if(Proceso.marchaIda && BaseLP_Colliders.reactorVolteadorArriba)
                {
                    SelectorRotation();

                    mainAnimatorController.SE_Volteo_DescensoIda(); //Función para disparar el respectivo trigger de la animación
                }
                #endregion

                //Condiciones de RESTRICCION
                else if (!Proceso.marchaIda && BaseLP_Colliders.reactorVolteadorArriba)
                {
                    string descriptionAction = "Transferimiento automático no activado";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 0);
                }
                else if (!Proceso.marchaIda && !BaseLP_Colliders.reactorVolteadorArriba)
                {
                    string descriptionAction = "Transferimiento automático no activado";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 0);
                }
                else if (Proceso.marchaIda && !BaseLP_Colliders.reactorVolteadorArriba)
                {
                    string descriptionAction = "La cesta no se encuentra en posición vertical";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 2);
                }
            }
            else if (Proceso.numProceso != numDeProceso || !Proceso.marchaIda)
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
