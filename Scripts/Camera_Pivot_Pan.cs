using UnityEngine;
using UnityEngine.Playables;

public class Camera_Pivot_Pan : MonoBehaviour
{
    public Camera cam;      
    public PlayableDirector playableDirector; //Playable para restringir el movimiento cuando el timeline está activo
    public Transform targetCameraPivot;        //Target para designar la posición inicial 

    [Header("Limites (act/des)")]      //Textos que aparecerán debajo de las imágenes de los mouse dependiendo de la condición
    public GameObject maxValueTextDerX;
    public GameObject maxValueTextDerY;

    [Header("Movimiento Eje X")]    //Limites en el movimiento sobre el eje X
    public float xMinClamp = -800f;
    public float xMaxClamp = -330f;

    [Header("Movimiento Eje Y")]    //Limites en el movimiento sobre el eje Y
    public float yMinClamp = 0f;
    public float yMaxClamp = 175f;

    Vector3 touchStart;
    float groundZ = 10; // Speed panning
    bool enoughRotation;

    void Start()
    {
        transform.position = targetCameraPivot.transform.position;
    }

    void Update()
    {
        if(!playableDirector.enabled)
        {
            Pan();

            //Limites para restringir el movimiento segun la rotacion de la cámara
            if (cam.transform.rotation.y <= 0.6 && cam.transform.rotation.y >= -0.6) 
                enoughRotation = false;
            else
                enoughRotation = true;

            //Condición para activar los textos en el canvas
            if (transform.position.x == xMinClamp || transform.position.x == xMaxClamp)
            {
                maxValueTextDerX.gameObject.SetActive(true);
            }
            else maxValueTextDerX.gameObject.SetActive(false);

            //Condición para activar los textos en el canvas
            if (transform.position.y == yMinClamp || transform.position.y == yMaxClamp)
            {
                maxValueTextDerY.gameObject.SetActive(true);

            }
            else maxValueTextDerY.gameObject.SetActive(false);
        }
    }

    private void Pan() //Funcipon para el movimiento sobra los ejes X e Y con el click derecho
    {
        if(!enoughRotation)
        {
            if (Input.GetMouseButtonDown(1)){
                touchStart = GetWorldPosition(groundZ);
            }
            if (Input.GetMouseButton(1)){
                Vector3 direction = touchStart - GetWorldPosition(groundZ);
                transform.position += direction;
            }
        
            this.transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMinClamp, xMaxClamp),
                Mathf.Clamp(transform.position.y, yMinClamp, yMaxClamp),
                transform.position.z);
        }
    }
    private Vector3 GetWorldPosition(float z) //Función para obtner la pocisión según el mundo
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0,0,z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
}
