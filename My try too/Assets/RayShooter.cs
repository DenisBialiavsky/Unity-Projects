using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();// Доступ к другим компонентам,
                                         //присоединенным к этому же объекту.
        

    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*"); // Команда GUI.Label()
        //отображает на экране символ.
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
        }
        if (Input.GetMouseButtonDown(0)) // Реакция на нажатие кнопки мыши.
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            // Середина экрана — это половина его ширины и высоты.

            Ray ray = _camera.ScreenPointToRay(point); //Создание в этой точке луча
            // методом ScreenPointToRay().

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))//Испущенный луч заполняет информацией
            {                               // переменную, на которую имеется ссылка.


                //StartCoroutine(SphereIndicator(hit.point));
                GameObject hitObject = hit.transform.gameObject; // Получаем объект,
                //в который попал луч.
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                { // Проверяем наличие у этого объекта компонента ReactiveTarget.
                    target.ReactToHit(); // Вызов метода для мишени
                    //вместо генерации отладочного сообщения
                    Messenger.Broadcast(GameEvent.ENEMY_HIT);//<-К реакции на попадания 
                                                             //добавлена рассылка сообщения
                }

                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }

    }
    private IEnumerator SphereIndicator(Vector3 pos)
    { // Сопрограммы пользуются функциями IEnumerator.
     GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
     sphere.transform.position = pos;

     yield return new WaitForSeconds(1); // Ключевое слово 
      //yield указывает сопрограмме,когда следует остановиться.

     Destroy(sphere); // Удаляем этот GameObject и очищаем память.    
    }
    
}
