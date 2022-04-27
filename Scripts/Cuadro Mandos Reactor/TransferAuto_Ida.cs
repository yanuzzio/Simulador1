using UnityEngine;
using UnityEngine.UI;

public class TransferAuto_Ida : MonoBehaviour
{
    [Header("-- Acción")]
    public int numDeProceso; //Valores por el cual el botón se acciona (modificado desde el inspector)

    [Space]
    [Space]

    public Image selector;
    WarningsController warnings;

    private void Start()
    {
        warnings = GameObject.FindGameObjectWithTag("Warning").GetComponent<WarningsController>();
    }
    public void bomba_Hidraulica()
    {
        if(Proceso.canReproduceAnimation)
        {
            #region Condiciones para cuando el elemento se encuentra en el contenedor y se sigue el camino de ida o vuelta de la secuencia

            if (Proceso.numProceso == numDeProceso && !Proceso.marchaIda)
            {
                SelectorRotation();

                Tutorial.consejo2 = true; //Tutorial
            }
            else if (!Tutorial.canDoTutorial)
            {
                if (Proceso.numProceso == numDeProceso && Proceso.marchaIda)
                {
                    SelectorRotation();
                }
                #endregion

                #region Condiciones para cuando el elemento NO SE ENCUENTRA en la base y se sigue un camino libre
                else if (BaseLP_Colliders.carroEnReactor)
                {
                    SelectorRotation();
                }
                #endregion

                //Condiciones de RESTRICCION
                else if(!BaseLP_Colliders.carroEnReactor)
                {
                    string descriptionAction = "El carro no se encuentra en el lado reactor";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 3);
                }
                else if (BaseLP_Colliders.carroEnReactor && !BaseLP_Colliders.reactorVolteadorArriba)
                {
                    string descriptionAction = "La cesta no se encuentra en posición vertical";
                    warnings.CorrutineWarningRestrictedAction(descriptionAction, 2);
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

    void SelectorRotation() //Función para que el selector cambie su rotación según su actual rotación
    {
        if (selector.transform.rotation.z >= 0.3f) // Valor de z para poder controlar cuando la perilla esta hacia un lado o hacia el otro
        {
            selector.transform.eulerAngles = new Vector3(selector.transform.eulerAngles.x, selector.transform.eulerAngles.y, 405);

            Proceso.marchaIda = true;
        }
        else if (selector.transform.rotation.z <= -0.3f)
        {
            selector.transform.eulerAngles = new Vector3(selector.transform.eulerAngles.x, selector.transform.eulerAngles.y, 315);

            Proceso.marchaIda = false;
        }
    }
}
