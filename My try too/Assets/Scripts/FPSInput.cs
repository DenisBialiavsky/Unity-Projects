using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{

    private CharacterController _charController; //<- Переменная для ссылки на компонент 
    //CharacterController.
    public  float baseSpeed = 6.0f;//<-Это значение отличается от указанного в листинге 6.10

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>(); //<-Доступ к другим 
       //компонентам, присоединённым к этому же объекту
       

    }
    public float speed = 6.0f; //<- Необязательный элемент на случай,
    //если вы захотите увеличить скорость.


    public float gravity = -9.8f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0);//<- Меняем метод Rotate() на метод Translate()

        float deltaX = Input.GetAxis("Horizontal") * speed; //<-"Horizontal" и
        //"Vertical" — это дополнительные  имена для сопоставления с клавиатурой.
        float deltaZ = Input.GetAxis("Vertical") * speed;


        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
        // DeltaTime даёт независимость движения от кадровой частоты

        //улучшенный вариант
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);//<-Ограничим движение
        //по диагонали той же скоростью, что и движение параллельно осям.

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement); //<-Преобразуем вектор
        // движения от локальных к глобальным координатам

        _charController.Move(movement);//<-Заставим этот вектор перемещать компонент 
                                       //CharaсterCintroller
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;//<- Используем значение переменной gravity вместо нуля.
    }

  
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}
