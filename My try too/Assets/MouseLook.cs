using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)//<- Проверяем,существует ли этот компонент.
        {
            body.freezeRotation = true;
        }
    }

public enum RotatiomAxes
{// <- Объявляем структуру данных enum, которая будет 
 //сопоставлять имена с параметрами
    MouseXAndY = 0,
    MouseX = 1,
    MouseY = 2
}
    public RotatiomAxes axes = RotatiomAxes.MouseXAndY;//<- Объявляем
    //общедоступную переменную, которая появится в редакторе Unity

    public float sensitivityHor = 9.0f; //<- Объявляем
    //переменную для скорости вращения
    public float sensitivityVert = 9.0f;// <- Объявляем
    //переменные, задающие поворот в вертикальной плоскости

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;// <- Объявляем
    //закрытую переменную для угла поворота по вертикали

    // Update is called once per frame
    void Update()
    {
        if (axes == RotatiomAxes.MouseX )
        {
            //Это поворот в горизонтальной плоскости

            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            //<-Rotate для запуска в каждом кадре.
            //Метод GetAxis() получает данные, вводимые с помощью мыши
            
        }
        else  if (axes == RotatiomAxes.MouseY)
        {
            //Это повотор в вертикальной плоскоти

            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            //<- Увеличиваем угол поворота по вертикали в соответствии
            //с пермещениями указателя мыши.

            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            //Фиксируем угол поворота по вертикали в диапазоне, заданном
            //минимальным и максимальным значениями.

            float rotationY = transform.localEulerAngles.y;
            //Сохраняем одинаковый угол поворота вокруг оси Y(т.е.
            //вращение с горизонтальной плоскости отсутствуют)

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            //Создаем новый вектор из сохраненных значений поворота
       
        }
        else
        {
            //это комбинированный поворот

            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;// <- Приращение
            // угла поворота через значение delta

            float rotationY = transform.localEulerAngles.y + delta;//<- Значение 
            // delta - жто величина изменения угла поворота 

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
