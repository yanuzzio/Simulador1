using UnityEngine;

public class EjeCestaMove : MonoBehaviour
{
    //Script encargado del valor de canReproduceAnimation a través de eventos llamados en las animaciones del EjeCesta

    SelectorController selectorController;
    MainAnimatorController mainAnimatorController;
    private void Start()
    {
        selectorController = GameObject.FindGameObjectWithTag("Warning").GetComponent<SelectorController>();
        mainAnimatorController = GameObject.FindGameObjectWithTag("Warning").GetComponent<MainAnimatorController>();
    }
    public void CanMove() //Funcion llamada al final de la animación
    {
        Proceso.canReproduceAnimation = true;
    }
    public void CantMove() //Funcion llamada al principio de la animación
    {
        Proceso.canReproduceAnimation = false;
    }

    public void ResetSimulador() //Función llamada en la animación R_Elemento_Descensoo (Animación que se dispara en el botón "Subir Elemento" del panel izquierdo)
    {
        mainAnimatorController.ResetAllAnimation(true);  //Valores iniciales de los parámetros de las animaciones de todos los animators

        Proceso.InitialValues();         //Valores iniciales de los booleanos del simulador

        selectorController.InitialPositionButton(false, true);  //Rotación inicial de los botones con Selector
    }
}
