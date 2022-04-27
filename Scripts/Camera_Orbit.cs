using UnityEngine;
using UnityEngine.Playables;

public class Camera_Orbit : MonoBehaviour
{
    public Transform target;        //Target (camera pivot) para que la cámara rote sobre él
    public PlayableDirector playableDirector; //Playable para restringir el movimiento cuando el timeline está activo

    [Header ("Limites (act/des)")]      //Textos que aparecerán debajo de las imágenes de los mouse dependiendo de la condición
    public GameObject maxValueTextMid;  
    public GameObject maxValueTextIzqY;
    public GameObject maxValueTextIzqX;

    [Header("Velocidad de Rotación")]     //Velocidad de rotación en los ejes X e Y
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
 
    [Header("Rotación Eje X")]     //Limites en la rotación sobre el eje X
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    [Header("Rotación Eje Y")]      //Limites en la rotación sobre el eje Y
    public float xMinLimit = -80f;
    public float xMaxLimit = 80f;

    [Header("Movimiento Eje Z")] //Limites en el movimiento sobre el eje Z
    public float zMinValue;
    public float zMaxValue;

    [Header("--Rieles")]        //GameObject que se activarán/desactivarán cuando la cámara se acerque lo suficiente al respectivo objeto
    public GameObject leftRiel;
    public GameObject rightRiel;
    public GameObject rightRiel2;
 
    float x = 0.0f;
    float y = 0.0f;
    float distance;
 
    bool orbitable;   //Booleano para cuando se apreta y se suelta el click izquierdo
    bool onWall;      //Booleano para saber cuando la cámara colisiona con las paredes de tag "Box"
    bool onSphere;    //Booleano para saber cuando la cámara entra en trigger con la esferas colliders (Escenarios>Colliders>LimitesCamara)

    void Start()
    {
        InitialCamaraPosition(); 
    }
    void LateUpdate()
    {
        if(!playableDirector.enabled)
        {
            distance = Vector3.Distance(target.transform.position, this.transform.position);

            if(Input.GetAxisRaw("Mouse ScrollWheel") != 0)
            {
                //Condición para que se el scroll se pueda mover libremente
                if (transform.localPosition.z <= zMaxValue && transform.localPosition.z >= zMinValue
                    && transform.localPosition.y <= 490f 
                    && !onWall && onSphere)  
                {
                    MaxScrollEnable(false);
                }
                //Condición para cuando sobrepasa los limites en Z y en Y+, sin tocar las paredes y manteniendose dentro de las esferas
                else if(transform.localPosition.z >= zMaxValue || transform.localPosition.z <= zMinValue || transform.localPosition.y >= 490 && !onWall && onSphere)
                {
                    maxValueTextMid.gameObject.SetActive(true);

                    //Condición para cuando esté en el máximo zoom sólo pueda hacer scroll hacia atrás
                    if ((transform.localPosition.z >= zMaxValue && Input.mouseScrollDelta == new Vector2(0.0f, -1.0f) && !onWall))
                    {
                        MaxScrollEnable(true);
                    }
                    // Condición para cuando esté en el mínimo zoom ó en la máxima altura, sólo pueda hacer scroll hacia delante
                    else if ((transform.localPosition.z <= zMinValue || transform.localPosition.y >= 490f) && Input.mouseScrollDelta == new Vector2(0.0f, 1.0f))
                    {
                        MaxScrollEnable(true);
                    }
                }
                //Condición para que cuando toque alguna pared o salga de las esfereas
                else if ((onWall || !onSphere))
                {
                    maxValueTextMid.gameObject.SetActive(true);

                    //Condición para que cuando esté en los límites sólo pueda hacer scroll hacia delante
                    if(Input.mouseScrollDelta == new Vector2(0.0f, 1.0f))
                    {
                        transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * 100f);
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
                orbitable = true;
            else if (Input.GetMouseButtonUp(0))
                orbitable = false;

            if (orbitable) { 
                if (target)
                {
                    x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                    y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
 
                    y = ClampAngle(y, yMinLimit, yMaxLimit);

                    x = ClampAngle(x, xMinLimit, xMaxLimit);

                    Quaternion rotation = Quaternion.Euler(y, x, 0);
 
                    Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
                    Vector3 position = rotation * negDistance + target.position;
 
                    transform.rotation = rotation;
                    transform.position = position;

                    if (transform.rotation.y >= 0.7 || transform.rotation.y <= -0.7)
                    {
                        maxValueTextIzqY.gameObject.SetActive(true);
                    }
                    else maxValueTextIzqY.gameObject.SetActive(false);


                    if (transform.rotation.x <= -0.17f || transform.rotation.x >= 0.64f)
                    {
                        maxValueTextIzqX.gameObject.SetActive(true);
                    }
                    else maxValueTextIzqX.gameObject.SetActive(false);
                }
            }
        }
    }
 
    void MaxScrollEnable(bool maxValue) //Función para el scroll del mouse
    {
        maxValueTextMid.gameObject.SetActive(maxValue);

        transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * 100f);
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
    public void InitialCamaraPosition() //Función para la posición inicial de la cámara
    {
        this.transform.position = new Vector3(transform.position.x, 65f, -600);

        distance = target.transform.position.z - this.transform.position.z;

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    //Paredes
    #region Collision's
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box") onWall = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Box")
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            onWall = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    #endregion

    //Esferas y Rieles
    #region Trigger's
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Limit")
        {
            onSphere = false;
        }
        if(other.gameObject.name == "ColliderRielLeft") //Rieles desaparecen al acercarse la camara
        {
            leftRiel.gameObject.SetActive(false);
        }
        if (other.gameObject.name == "ColliderRielRight") // Rieles desaparecen al acercarse la camara
        {
            rightRiel.gameObject.SetActive(false);
            rightRiel2.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Limit")
        {
            onSphere = true;
        }
        if (other.gameObject.name == "ColliderRielLeft") // Rieles desaparecen al acercarse la camara
        {
            leftRiel.gameObject.SetActive(false);
        }
        if (other.gameObject.name == "ColliderRielRight") // Rieles desaparecen al acercarse la camara
        {
            rightRiel.gameObject.SetActive(false);
            rightRiel2.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Limit")
        {
            onSphere = false;
        }
        if (other.gameObject.name == "ColliderRielLeft") // Rieles aparecen al acercarse la camara
        {
            leftRiel.gameObject.SetActive(true);
        }
        if (other.gameObject.name == "ColliderRielRight") // Rieles aparecen al acercarse la camara
        {
            rightRiel.gameObject.SetActive(true);
            rightRiel2.gameObject.SetActive(true);
        }
    }
    #endregion
}
