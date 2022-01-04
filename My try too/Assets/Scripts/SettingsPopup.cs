using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider speedSlider;
   
    public void Open()
    {
        gameObject.SetActive(true); //<-Активируйте этот объект, чтобы открыть окно
    }
    public void Close()
    {
        gameObject.SetActive(false);//<- Деактивируйте объект, чтобы закрыть окно
    }
    void Start()
    {
        gameObject.SetActive(false);
       
        //speedSlider.value = PlayerPrefs.GetFloat("speed", 3);
    }
    public void OnSubmitName(string name)//<-Этот метод срабатывает в момент начала ввода данных
    {                                   //начала ввода данных в текстовое поле
       
        Debug.Log("Name:" + name);

    }
    public void OnSpeedValue(float speed) //<-Этот метод срабатывает при изменении положения ползуна
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);//<-Значение, заданное 
                                                                   //положением ползунка, рассылается как событие <float>
        
       
        Debug.Log("Speed:" + speed);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
