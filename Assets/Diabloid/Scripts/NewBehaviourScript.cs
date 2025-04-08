using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void LoadMainScene()
{
    SceneManager.LoadScene("MainScene"); // Завантажуємо основну сцену
}

}
