using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    //Script que se encarga del funcionamiento del timeline

    //La pocisión de la cámara cambia porque se activa otra que la reemplaza durante el timeline

    public GameObject[] instrucciones;  //Array con las viñeteas de las instrucciones

    PlayableDirector playableDirector;
    bool instruccionesOn = true;        //Booleano que se activa en el cartel de instrucciones o desde el panel de opciones
    int number = 0;                     //Número entero que aumenta luego de apretar continuar en cada vileta

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    private void LateUpdate()
    {
        if(instruccionesOn)
        {
            //Bucle para que las instrucciones se vayan activando conforme se presione el botón TimeReset
             for (int i = 0; i < instrucciones.Length; i++)
             {
                if (instrucciones[i].activeSelf && i == number) 
                {
                    Time.timeScale = 0f;
                }
             }
        }

        if (!playableDirector.enabled)
        {
            instruccionesOn = false;
            number = 0;
        }
    }

    public void Continuar() //Función que se llama en el botón de Continuar de cada viñeta
    {
        Time.timeScale = 1f;
        number++;
    }

    public void Play() //Función que se llama al activar las intrucciones mediante el cartel o desde el panel de opciones
    {
        instruccionesOn = true;

        if(!playableDirector.enabled) playableDirector.enabled = true;
        playableDirector.Play();
    }

    public void Stop() //Función que se llama al "Saltar intrucciones" y al terminar la última viñeta
    {
        instruccionesOn = false;

        playableDirector.time = 0f;
        playableDirector.Stop();

        playableDirector.enabled = false;
        Time.timeScale = 1f;
    }
}
