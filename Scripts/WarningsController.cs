using System.Collections;
using UnityEngine;
using TMPro;

public class WarningsController : MonoBehaviour
{
    //Script que se encarga de mostrar los carteles (MaquinariasOn, BotónIncorrecto y AcciónRestringida)

    public GameObject clickImages; //GameObject de las imagenes de los mouse

    [Space]

    //GameObject de los carteles en pantalla
    [Header ("--Warnings")]
    public GameObject warningMachineryOn;
    public GameObject warningWrongButton;
    public GameObject warningRestrictedAction;
    public GameObject warningTutorialActivo;
    public TextMeshProUGUI text_WarningRestrictedAction;

    [Space]

    //GameObject que contienen el scrript de Outline
    [Header("--OutlineObjetcs")]
    public Transform elementoSP;
    public Transform cestaSP;
    public Transform carroSP;
    Outline outline;

    //Booleanos para controlar que la corrutina termine primero antes de iniciar nuevamente
    bool enableCorrutine = true; 
    bool enableCorrutine2 = true;
    bool enableCorrutine3 = true;

    public void CorrutineWarningMachinaryOn() //Función para cuando se quiere activar un botón y hay una animación en proceso
    {
        if(enableCorrutine)
        {
            StartCoroutine(WaitForWarningMachinaryOn());
        }
    }
    public void CorrutineWarningWrogButton() //Función para cuando se pulsa un botón que no corresponde en la secuencia
    {
        if(enableCorrutine2)
        {
            StartCoroutine(WaitForWarningWrongButton());
        }
    }

    public void CorrutineWarningRestrictedAction(string descriptionAction, int typeObject) //Función para cuando se pulsa un botón y la acción esa restringida
    {
        if(enableCorrutine3)
        {
            //Outline: resalta el borde de la mesh que contenga el script

            if (typeObject == 0) //Objeto nulo
            {
                outline = null;
            }
            else if(typeObject == 1) //Objeto elemento
            {
                outline = elementoSP.GetComponent<Outline>();
            }
            else if(typeObject == 2) //Objeto cesta
            {
                outline = cestaSP.GetComponent<Outline>();
            }
            else if(typeObject == 3) //Objeto carro
            {
                outline = carroSP.GetComponent<Outline>();
            }

            text_WarningRestrictedAction.text = descriptionAction; //Texto del cartel que se modifica desde el botón llamado

            StartCoroutine(WaitForWarningRestrictedAction(outline));
        }
    }

    IEnumerator WaitForWarningMachinaryOn()  //Corrutina para cuando la maquinaria está funcionando
    {
        enableCorrutine = false; //Booleano para que no se active otra corrutina del mismo tipo hasta que esta termina

        warningMachineryOn.gameObject.SetActive(true); //Activa el cartel correspondiente
        clickImages.gameObject.SetActive(false); //Desactiva las imagenes de los mouse que se encuentra en el fondo

        yield return new WaitForSeconds(2f);

        warningMachineryOn.gameObject.SetActive(false);
        clickImages.gameObject.SetActive(true);
        enableCorrutine = true;
    }
    IEnumerator WaitForWarningWrongButton() //Corrutina para cuando el botón es incorrecto (principalmente en tutorial)
    {
        enableCorrutine2 = false; //Booleano para que no se active otra corrutina del mismo tipo hasta que esta termina

        if (Tutorial.canDoTutorial) warningTutorialActivo.gameObject.SetActive(true); //Si se apreta un botón incorrecto durante el tutorial

        warningWrongButton.gameObject.SetActive(true); //Activa el cartel correspondiente
        clickImages.gameObject.SetActive(false); //Desactiva las imagenes de los mouse que se encuentra en el fondo

        yield return new WaitForSeconds(2f);

        if (Tutorial.canDoTutorial) warningTutorialActivo.gameObject.SetActive(false);

        warningWrongButton.gameObject.SetActive(false);
        clickImages.gameObject.SetActive(true);

        enableCorrutine2 = true;
    }
    IEnumerator WaitForWarningRestrictedAction(Outline actualOutline) //Corrutina para cuando la acción seleccionada esta restringida
    {
        enableCorrutine3 = false; //Booleano para que no se active otra corrutina del mismo tipo hasta que esta termina

        if (actualOutline != null) actualOutline.enabled = true; //Activa el script de Outline del objecto

        warningRestrictedAction.gameObject.SetActive(true); //Activa el cartel correspondiente
        clickImages.gameObject.SetActive(false); //Desactiva las imagenes de los mouse que se encuentra en el fondo

        yield return new WaitForSeconds(3f);

        if (actualOutline != null) actualOutline.enabled = false;

        warningRestrictedAction.gameObject.SetActive(false);
        clickImages.gameObject.SetActive(true);

        enableCorrutine3 = true;
    }
}
