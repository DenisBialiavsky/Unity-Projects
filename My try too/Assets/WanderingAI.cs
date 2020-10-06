using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    [SerializeField] private GameObject fireballPrefab; //<- Эти два поля добавляются
    // перед любыми методами, как и в сценарии SceneController
    private GameObject _fireball;
    public  float baseSpeed = 3.0f;// - Базовая скорость, меняемая 
                                        //в соответствии с положением ползунка

    public float speed = 3.0f; //<- Значения для скорости движения и расстояния
    //с которого начинается реакция на препятствие
    public float obstacleRange = 5.0f;

    private bool _alive;//<-Логическая переменная для слежения за состоянием персонажа.


    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime); //<- Непрерывно движемся
                                                               //вперед в каждом кадре, несмотря на повороты
        }




        Ray ray = new Ray(transform.position, transform.forward); //<- Луч находится
        // в том же положении и нацеливается в том же направлении, что и персонаж

        RaycastHit hit;

        //if (Physics.SphereCast(ray, 0.75f, out hit))
        //{//<-Бросаем луч с описанной вокруг него окружностью
        //    if (hit.distance < obstacleRange)
        //    {
        //        float angle = Random.Range(-110, 110); //<- Поворот с наполовину
        //        // случайным выбором нового направления.
        //        transform.Rotate(0, angle, 0);
        //    }
        //}

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {//<- Игрок распознается тем же спсобом, что и мишень в сценарии RayShooter
                if (_fireball == null)
                { //<- Та же самая логика с пустым игровым объектом, что и в сценарии SceneController.
                    _fireball = Instantiate(fireballPrefab) as GameObject; //Метод
                    // Instantiate() работает так же, как и в сценарии SceneController.
                    _fireball.transform.position = //<- Поместим огненный шар в перед врагом
                                              // и нацелим в направлении его движения
                    transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);

            }
        }
    }
    public void SetAlive(bool live)//<-Открытый метод, позволяющий внешнему коду
        // воздействовать на "живое" состояние.
    {
        _alive = live;
    }
   
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)//<- Метод, объявленный в подписчике для 
                                            //события SPEED CHANGED
    {
        speed = baseSpeed * value;
    }
}
