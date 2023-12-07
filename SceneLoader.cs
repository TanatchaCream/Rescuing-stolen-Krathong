using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour

{
    // Update is called once per frame
    void Update()
    {
        // ตรวจสอบว่าปุ่ม ESC ถูกกดหรือไม่
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
