using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 3.0f; //<-Объявление общедоступной
    //переменной для скорости вращения

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0, Space.World); //<- Поместите сюда команду Rotate,
        //чтобы она запускалась в каждом кадре
        
    }
}
