using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
 
   // ����� ��� ������ � ���
    public void QuitGame()
    {
        // ��� ��������� Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // ����� � ��� �� ������������ �������
        #endif
    }

}
