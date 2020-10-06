using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    void OnGUI()
    { //<-Функция вызывается в каждом кадре после того, как все остальное уже визуализировано.
     
        if (GUI.Button(new Rect(10, 10, 40, 20), "Test"))
        { //<-Параметры: положение по оси X, положение по оси Y, ширина, высота, текстовая подпись.
                        Debug.Log("Test button");
         }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
