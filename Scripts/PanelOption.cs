using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelOption : MonoBehaviour
{
    public void RestartLevel() //Función de reset level llamado en el botón de "Si" de ResetPanel
    {
        SceneManager.LoadScene("Simulador");
    }

    public void ExitGame() //Función de reset level llamado en el botón de "Si" de ExitGame
    {
        Application.Quit();
    }
}
