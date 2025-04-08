using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
 
   // Метод для виходу з гри
    public void QuitGame()
    {
        // Для редактора Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // Вихід з гри на побудованому додатку
        #endif
    }

}
