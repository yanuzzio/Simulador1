using UnityEngine;
using UnityEngine.UI;

public class SliderMenuAnim : MonoBehaviour
{
    Animator animator;
    bool isOpen;        //Booleano para saber cuando el panel está abierto/cerrado

    //Booleanos para saber cuando se puede mostrar las viñetas del tutorial dependiendo si el panel correspondiente está abierto o no
    [HideInInspector]
    public bool canShowTutorialIzquierdo; 
    [HideInInspector]
    public bool canShowTutorialDerecho;

    //Variables para que la imagen de flecha se voltee dependiendo si se abre o se cierra el panel
    public GameObject Slider;
    Vector3 newOrientation = Vector3.one;

    Image[] panels; //Array que recoge los componentes de imagen en los hijos

    private void Start()
    {
        panels = GetComponentsInChildren<Image>();
        animator = GetComponent<Animator>();
    }

    public void ShowHideMenu() //Función llamada en los botones correspondientes de los Sliders
    {
        if(animator != null)
        {
            isOpen = animator.GetBool("Slider");
            animator.SetBool("Slider", !isOpen);

            //Condición para que la imagen cambie de dirección cuando se acciona el slider
            if(isOpen || !isOpen)
            {
                newOrientation *= -1;
            }

            Slider.transform.localScale = newOrientation;
        }
    }

    #region Funciones para cuando el cursor entra y sale de los paneles
    public void PointerEnter()
    {
        foreach (Image child in panels)
        {
            child.color = new Color(child.color.r, child.color.g, child.color.b, 1f);
        }
    }

    public void PointerExit()
    {
        foreach (Image child in panels)
        {
            child.color = new Color(child.color.r, child.color.g, child.color.b, 0.15f);
        }
    }
    #endregion

    #region Eventos llamados en las respectivas animaciones de los sliders para saber cuando estan abiertos o cerrados
    public void TutorialIzquierdoEnable()
    {
        canShowTutorialIzquierdo = true;
    }

    public void TutorialIzquierdoDisable()
    {
        canShowTutorialIzquierdo = false;
    }

    public void TutorialDerechoEnable()
    {
        canShowTutorialDerecho = true;
    }

    public void TutorialDerechoDisable()
    {
        canShowTutorialDerecho = false;
    }
    #endregion
}
