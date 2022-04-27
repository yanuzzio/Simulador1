using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    //Script encargado de la guía de funcionamiento (tutorial)

    public static bool canDoTutorial = false;          //Booleano para poder hacer el tutorial o no (modificado desde el cartel de tutorial o desde opciones)
    public GameObject botonActivarTutorial;     //Casilla que se encuentra en opciones (Tutorial _). Por si se acepta hacer el tutorial desde el cartel inicial y así cambia solo
    public GameObject botonDesactivarTutorial;  //Casilla que se encuentra en opciones (Tutorial _). Por si se acepta hacer el tutorial desde el cartel inicial y así cambia solo

    [Space]

    public GameObject tutorialCompletado;       //Cartel de tutorial completado
    public GameObject warningGuíaActiva;        //GameObject que avisa que la guía de funcionamiento está activa
    public GameObject saltarTutorial;

    public GameObject[] consejosTutorial;  //Array de los consejos (viñetas) de los paneles (Orden cronológico)
    public GameObject[] botonesTutorial;  //Array de los botones secundarios que se muestran en el tutorial (Orden cronológico)
    public GameObject tips;               //Array de los consejos (viñetas) del panel izquierdo
    int index;                            //Int para controlar el bucle For una vez que se pasa de consejo
    bool canWait = true;                  //Booleano para controlar el comienzo y el final de la corrutina 

    [Space]
    [Space]

    public GameObject openTutorialIzquierdo;        //Cartel para abrir el panel izquierdo
    public SliderMenuAnim panelIzquierdo;           //Script del slider para saber cuando el panel se encuentra abierto o cerrado

    [Space]
    [Space]
    
    public GameObject openTutorialDerecho;          //Cartel para abrir el panel derechp
    public SliderMenuAnim panelDerecho;             //Script del slider para saber cuando el panel se encuentra abierto o cerrado

    [Space]
    [Space]

    //Botones de los sliders para que se activen cuando el panel correspondiente se cierra
    public GameObject leftSlider;
    public GameObject rightSlider;

    //Los boleanos cambian en las acciones (click) de los botones (script)
    #region Booleanos condicionantes
    public static bool consejo1 = false;
    public static bool consejo2 = false;
    public static bool consejo3 = false;
    public static bool consejo4 = false;
    public static bool consejo5 = false;
    public static bool consejo6 = false;
    public static bool consejo7 = false;
    public static bool consejo8 = false;
    public static bool consejo9 = false;
    public static bool consejo10 = false;
    public static bool consejo11 = false;
    public static bool consejo12 = false;
    #endregion

    void Update()
    {
        if(canDoTutorial)
        {
            //Cartel de que el tutorial está ON
            warningGuíaActiva.gameObject.SetActive(true);
            //Cartel para saltar el tutorial ON
            saltarTutorial.gameObject.SetActive(true);

            //Se cambia las casillas del panel de opciones
            botonActivarTutorial.gameObject.SetActive(true);
            botonDesactivarTutorial.gameObject.SetActive(false);

            //Index que cambia cuando se da continuar a las viñetas
            if(index <= 3 || index > 9)
            {
                //Condición si el panel correspondiente está abierto
                if(panelIzquierdo.canShowTutorialIzquierdo)
                {
                    //Cuando se cierra el panel correspondiente
                    openTutorialIzquierdo.gameObject.SetActive(false);
                    leftSlider.SetActive(false);

                    //Viñetas de los consejos
                    tips.gameObject.SetActive(true);

                    ShowTips();
                }
                else if(!panelIzquierdo.canShowTutorialIzquierdo)
                {
                    //Cuando se cierra el panel correspondiente
                    openTutorialIzquierdo.gameObject.SetActive(true);
                    leftSlider.gameObject.SetActive(true);

                    //Viñetas de los consejos
                    tips.gameObject.SetActive(false);
                }
            }
            else if(index > 3 || index <= 9)
            {
                //Condición si el panel correspondiente está abierto
                if (panelDerecho.canShowTutorialDerecho)
                {
                    //Cuando se cierra el panel correspondiente
                    openTutorialDerecho.gameObject.SetActive(false);
                    rightSlider.gameObject.SetActive(false);

                    //Viñetas de los consejos
                    tips.gameObject.SetActive(true);
                    
                    ShowTips();
                }
                else if (!panelDerecho.canShowTutorialDerecho)
                {
                    //Cuando se cierra el panel correspondiente
                    openTutorialDerecho.gameObject.SetActive(true);
                    rightSlider.gameObject.SetActive(true);

                    //Viñetas de los consejos
                    tips.gameObject.SetActive(false);
                }
            }

            Progreso();
        }
        else
        {
            //Cartel de que el tutorial está OFF
            warningGuíaActiva.gameObject.SetActive(false);
            //Cartel para saltar el tutorial OFF
            saltarTutorial.gameObject.SetActive(false);

            //Se cambia las casillas del panel de opciones
            botonActivarTutorial.gameObject.SetActive(false);
            botonDesactivarTutorial.gameObject.SetActive(true);
        }
    }

    void ShowTips() //Función que se encarga de mostrar los botones y las viñetas según el index actual
    {
        if (canWait)
        {
            tips.gameObject.SetActive(true);

            //Bucle para recorrer las viñetas de los concejos
            for (int i = 0; i < consejosTutorial.Length; i++) 
            {
                if (i == index)
                {
                    consejosTutorial[i].SetActive(true);
                }
                else
                {
                    consejosTutorial[i].SetActive(false);
                }
            }

            //Bucle para recorrer los botones
            for (int i = 0; i < botonesTutorial.Length; i++)
            {
                if(i == index)
                {
                    botonesTutorial[i].SetActive(true);
                }
                else
                {
                    botonesTutorial[i].SetActive(false);
                }
            }
        }
        else
        {
            tips.gameObject.SetActive(false);
        }
    }
    void Progreso() //Función para el aumento de index dependiendo de los booleanos en cada botón
    {
        if(index == 0)
        {
            if (consejo1) index++;
        }
        else if(index == 1)
        {
            if (consejo2) index++;
        }
        else if(index == 2)
        {
            if (consejo3) index++;
        }
        else if(index == 3)
        {
            if (consejo4) index++;
        }
        else if(index == 4)
        {
            if (consejo5) index++;
        }
        else if(index == 5)
        {
            if (consejo6) index++;
        }
        else if(index == 6)
        {
            if (consejo7) index++;
        }
        else if(index == 7)
        {
            if (consejo8) index++;
        }
        else if (index == 8)
        {
            if (consejo9) index++;
        }
        else if (index == 9)
        {
            if (consejo10) index++;
        }
        else if (index == 10)
        {
            if (consejo11) index++;
        }
        else if (index == 11)
        {
            if (consejo12)
            {
                index++;
                StartCoroutine(WaitForTheEnd());
            }
        }
    }

    public void CanDoTutorial(bool _canDoTutorial) //Función llamada desde los botones de "Quieres hacer el tutorial" y en el panel de opciones al habilitar la guía
    {
        canDoTutorial = _canDoTutorial;
    }

    /// Función llamada en cada botón original involucrados en el tutorial
    /// <param name="waitTime">Parámentro que cambia desde el botón original de cada uno (inspector)</param>
    /// <returns></returns>
    public void CorrutineButton(float waitTime)
    {
        //Si no se está haciendo el tutorial la condición no se cumple
        if (canDoTutorial)
        {
            StartCoroutine(WaitForTheAnother(waitTime));
        }
    }

    public void ResetTutorial() //Función para resetear el tutorial una vez que se termina
    {
        canDoTutorial = false;

        index = 0;

        consejo1 = false;
        consejo2 = false;
        consejo3 = false;
        consejo4 = false;
        consejo5 = false;
        consejo6 = false;
        consejo7 = false;
        consejo8 = false;
        consejo9 = false;
        consejo10 = false;
        consejo11 = false;
        consejo12 = false;

    }
    public void DisableAllSecundaryButtons()  //Función para desactivar los botones que reemplazan a los originales durante el tutorial cuando se desactiva el tutorial desde opciones
    {
        for (int i = 0; i < botonesTutorial.Length; i++)
        {
            botonesTutorial[i].gameObject.SetActive(false);
        }

        leftSlider.gameObject.SetActive(false);
        rightSlider.gameObject.SetActive(false);
        openTutorialDerecho.gameObject.SetActive(false);
        openTutorialIzquierdo.gameObject.SetActive(false);

        tips.gameObject.SetActive(false);
    }
    IEnumerator WaitForTheEnd() //Corrutina que muestra el fin de la guía
    {
        yield return new WaitForSeconds(10f); //Duración de la animación de ascender
        tutorialCompletado.gameObject.SetActive(true);

        ResetTutorial();

        yield return new WaitForSeconds(6f); //Tiempo en lo que el cartel está activo
        tutorialCompletado.gameObject.SetActive(false);
    }
    IEnumerator WaitForTheAnother(float waitTime) //Corrutina para esperar entre viñeta y viñeta.
    {
        canWait = false;
        yield return new WaitForSeconds(waitTime);
        canWait = true;
    }
}
