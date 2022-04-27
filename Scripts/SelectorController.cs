using UnityEngine;

public class SelectorController : MonoBehaviour
{
    //Script que se encarga de igualar los botones de ambos paneles, teniendo en cuenta su transparencia

    //Panel Izquierdo
    [Header("--Panel Izquierdo--")]
    public RectTransform GuiaManipIzq;
    public RectTransform TransAutoIzq;
    public RectTransform PosCarroIzq;
    public RectTransform SelectorVolIzq;
    public RectTransform SelectorProxAbajoIzq;
    public RectTransform SelectorProxArribaIzq;

    //Panel Derecho
    [Header("--Panel Derecho--")]
    public RectTransform GuiaManipDer;
    public RectTransform TransAutoDer;
    public RectTransform PosCarroDer;
    public RectTransform SelectorVolDer;
    public RectTransform SelectorProxAbajoDer;
    public RectTransform SelectorProxArribaDer;

    //Declaraciones para la posiciones iniciales de los botones
    Quaternion button0;
    Quaternion button1;
    Quaternion button2;
    Quaternion button3;
    Quaternion button4;
    Quaternion button5;

    private void Start()
    {
        InitialPositionButton(true, false); //Recoge la rotación inicial de los selectores
    }

    private void Update()
    {
        if (BaseLP_Colliders.carroEnReactor) 
        {
            GuiaManipDer.rotation = new Quaternion(GuiaManipDer.rotation.x, GuiaManipDer.rotation.y, GuiaManipIzq.rotation.z, GuiaManipDer.rotation.w);
          //  TransAutoDer.rotation = new Quaternion(TransAutoDer.rotation.x, TransAutoDer.rotation.y, TransAutoIzq.rotation.z, TransAutoDer.rotation.w);
            PosCarroDer.rotation = new Quaternion(PosCarroDer.rotation.x, PosCarroDer.rotation.y,PosCarroIzq.rotation.z, PosCarroDer.rotation.w);
            SelectorProxAbajoDer.rotation = new Quaternion(SelectorProxAbajoDer.rotation.x, SelectorProxAbajoDer.rotation.y, SelectorProxAbajoIzq.rotation.z, SelectorProxAbajoDer.rotation.w);
            SelectorProxArribaDer.rotation = new Quaternion(SelectorProxArribaDer.rotation.x, SelectorProxArribaDer.rotation.y, SelectorProxArribaIzq.rotation.z, SelectorProxArribaDer.rotation.w);
        }
        else if(BaseLP_Colliders.carroEnCombustible)
        {
            GuiaManipIzq.rotation = new Quaternion(GuiaManipIzq.rotation.x, GuiaManipIzq.rotation.y, GuiaManipDer.rotation.z, GuiaManipIzq.rotation.w);
          //  TransAutoIzq.rotation = new Quaternion(TransAutoIzq.rotation.x, TransAutoIzq.rotation.y, TransAutoDer.rotation.z, TransAutoIzq.rotation.w);
            SelectorVolIzq.rotation = new Quaternion(SelectorVolIzq.rotation.x, SelectorVolIzq.rotation.y, SelectorVolDer.rotation.z, SelectorVolIzq.rotation.w);
            PosCarroIzq.rotation = new Quaternion(PosCarroIzq.rotation.x, PosCarroIzq.rotation.y, PosCarroDer.rotation.z, PosCarroIzq.rotation.w);
        }
    }


    //Función para restablecer la posición inicial de los botones una vez que el simulador termina
    public void InitialPositionButton(bool initalPosition, bool finalPosition)
    {
        if (initalPosition) //Recoge las rotaciones iniciales de los selectores
        {
            button0 = GuiaManipIzq.rotation;
            button0 = GuiaManipIzq.rotation;
            button1 = TransAutoIzq.rotation;
            button2 = PosCarroIzq.rotation;
            button3 = SelectorVolIzq.rotation;
            button4 = SelectorProxAbajoIzq.rotation;
            button5 = SelectorProxArribaIzq.rotation;
        }

        if(finalPosition) //Iguala las rotaciones iniciales de los selectores con las iniciales
        {
            GuiaManipIzq.rotation = button0;
            TransAutoIzq.rotation = button1;
            PosCarroIzq.rotation = button2;
            SelectorVolIzq.rotation = button3;
            SelectorProxAbajoIzq.rotation = button4;
            SelectorProxArribaIzq.rotation = button5;
        }
    }
}
