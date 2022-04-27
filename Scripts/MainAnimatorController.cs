using UnityEngine;

public class MainAnimatorController : MonoBehaviour
{
    //Script encargado de controlar, principalmente, loos disparadores de los triggers de los botones

    public Animator[] panelesAnimators;
    public Animator[] allAnimators;
    [Space]
    public Tutorial tutorial;
    public SelectorController selectorController;

    private void Awake()
    {
        ResetAllParameters(); //Función para asegurar los valores iniciales 
    }
    void Update()
    {
        //Condiciones para testeo
        if(Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 3;
            Debug.Log("ScaleChange");
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Time.timeScale = 0.2f;
        }

        Debug.Log("NumProceso: " + Proceso.numProceso);
        Debug.Log("CanReproduceAnimation: " + Proceso.canReproduceAnimation);
        Debug.Log("NumProcesoRev: " + Proceso.numProcesoRev);
    }

    #region Funciones llamadas desde los botones correspondientes que disparan los triggers de las animaciones CON EL ELEMENTO

    //Funciones en orden secuencial
    public void Descenso_Ida()
    {
        TriggerController("Descenso_Trigger");
    }
    public void Volteo_DescensoIda()
    {
        TriggerController("Volteo_Trigger");
    }
    public void Desplazamiento_Ida()
    {
        TriggerController("Desplazamiento_Trigger");
    }
    public void Volteo_AscensoVuelta()
    {
        TriggerController("Volteo_2_Trigger");
    }
    public void Ascenso_Vuelta()
    {
        TriggerController("Ascenso_Trigger");
    }
    public void Descenso_Vuelta()
    {
        TriggerController("Ascenso_Trigger_Reverse");
    }
    public void Volteo_DescensoVuelta()
    {
        TriggerController("Volteo_2_Trigger_Reverse");
    }
    public void Desplazamiento_Vuelta()
    {
        TriggerController("Desplazamiento_Trigger_Reverse");
    }
    public void Volteo_AscensoIda()
    {
        TriggerController("Volteo_Trigger_Reverse");
    }
    public void Ascenso_Ida()
    {
        TriggerController("Descenso_Trigger_Reverse");
    }
    #endregion

    #region Funciones llamadas desde los botones correspondientes que disparan los triggers de las animaciones SIN EL ELEMENTO
    //Funciones en orden secuencial
    public void SE_Descenso_Ida()
    {
        TriggerControllerSE("Descenso_Trigger");
    }
    public void SE_Volteo_DescensoIda()
    {
        TriggerControllerSE("Volteo_Trigger");
    }
    public void SE_Desplazamiento_Ida()
    {
        TriggerControllerSE("Desplazamiento_Trigger");
    }
    public void SE_Volteo_AscensoVuelta()
    {
        TriggerControllerSE("Volteo_2_Trigger");
    }
    public void SE_Ascenso_Vuelta()
    {
        TriggerControllerSE("Ascenso_Trigger");
    }
    public void SE_Descenso_Vuelta()
    {
        TriggerControllerSE("Ascenso_Trigger_Reverse");
    }
    public void SE_Volteo_DescensoVuelta()
    {
        TriggerControllerSE("Volteo_2_Trigger_Reverse");
    }
    public void SE_Desplazamiento_Vuelta()
    {
        TriggerControllerSE("Desplazamiento_Trigger_Reverse");
    }
    public void SE_Volteo_AscensoIda()
    {
        TriggerControllerSE("Volteo_Trigger_Reverse");
    }
    public void SE_Ascenso_Ida()
    {
        TriggerControllerSE("Descenso_Trigger_Reverse");
    }
#endregion

    public void StartTutorial() //Función llamada desde el botón "SI" del cartel warning_GuiaDeFuncionamiento
    {
        ResetAllParameters();

        //Posición inicial de los botones con selectores
        selectorController.InitialPositionButton(false, true);

        //Dispara el trigger en todos los animators
        TriggerController("Idle");
    }
    public void StartInstructions() //Función llamada desde el botón "SI" del cartel warning_GuiaDeInstrucciones
    {
        //Se dispara el boooleano para que los sliders se oculten (en caso que esten abiertos) cuando se inicia las instrucciones
        for (int i = 0; i < panelesAnimators.Length; i++)
        {
            if(panelesAnimators[i].GetCurrentAnimatorStateInfo(0).IsTag("0"))
            {
                panelesAnimators[i].SetBool("Slider", false);
            }
        }
    }
    public void ResetAllAnimation(bool reset) //Función para resetear los valores de los parámetros de todos los animators
    {
        //For para entrar en todos los animator del array
        //Con el foreach entra toma cada uno de los triggers de cada animator y los resetea, es decir, los pasa a false
        //Luego dispara el trigger Reset de cada uno de los animator para que vuelva a la animación inicial una vez que se termine la secuencia del simulador
        for (int i = 0; i < allAnimators.Length; i++)
        {
            foreach (AnimatorControllerParameter trigger in allAnimators[i].parameters)
            {
                if (trigger.type == AnimatorControllerParameterType.Trigger)
                {
                    allAnimators[i].ResetTrigger(trigger.name); //Resetea todos los parámetros que sean Triggers
                }
            }

            //Dispara todos los triggers Reset para que se pueda volver a comenzar
            //Sólo para cuando se termina la secuencia del simulador y se vuelve a empezar sin reiniciarlo
            if (reset) allAnimators[i].SetTrigger("Reset"); 
        }
    }
    void ResetAllParameters() //Función para asegurar el reseteo de todos lo valores cuando se reinicia el simulador
    {
        //Reset booleanos de los colliders
        BaseLP_Colliders.ResetColliders();
        ElementoSP_Colliders.ResetColliders();
        Gruas_Colliders.ResetColliders();

        //Reset booleanos e int del Proceso
        Proceso.InitialValues();
        //Reset booleanos e int del Tutorial
        tutorial.ResetTutorial();

        //Reset de los triggers de todas los animators
        ResetAllAnimation(false);
    }
    void TriggerController(string triggerName) //Función para disparar los triggers, según el string, en todas las animaciones
    {
        for (int i = 0; i < allAnimators.Length; i++)
        {
            allAnimators[i].SetTrigger(triggerName);
        }
    }
    void TriggerControllerSE(string triggerName) //Función para disparar los triggers excepto en la animación del ElementoSP
    {
        //i comenzando desde el valor 1
        for (int i = 1; i < allAnimators.Length; i++)
        {
            allAnimators[i].SetTrigger(triggerName);
        }
    }
}
