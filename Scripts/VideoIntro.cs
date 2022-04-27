using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoIntro : MonoBehaviour
{
    //Script para iniciar la scena del simulador luego de terminar el video de introducción

    private void Start()
    {
        StartCoroutine(WaitForIntro());
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Simulador");
    }
}
