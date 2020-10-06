using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;


public class UIController : MonoBehaviour
{
    private double _score;
    [SerializeField] private Text scoreLabel;//<- Объект сцены Reference Text, предназначенный
                                             // для задания свойства text
                                             // Start is called before the first frame update
    
    [SerializeField] private SettingsPopup settingsPopup;

    


    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);//<-объявляем, какой метод отвечает на 
                                                               //на событие ENEMY_HIT
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);//<-При разрушении объекта удаляйте
                                                                  //подписчика, чтобы избежать ошибок.
    }
    void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();


        //Debug.Log(_score.ToString());//<-Присвоение переменной score начального значения 0.

        // settingsPopup.Close();//<- Закрываем всплывающее окно в момент начала игры.
        // УЗНАТЬ В ЧЁМ ПРОБЛЕМА??????????????????????????????????
    }
    private void OnEnemyHit()
    {
        _score += 0.5;
        scoreLabel.text = _score.ToString();
       
    }

    // Update is called once per frame
    //void Update()
    //{
    //   // scoreLabel.text = Time.realtimeSinceStartup.ToString();
    //}

    //public void OnOpenSettings() //<- Метод, вызываемый кнопкой настроек.
    //{
    //   // settingsPopup.Open();// <- Замена отладочный текст методом всплывающего окна. 
    //   // Debug.Log("open settings");
    //} УЗНАТЬ В ЧЁМ ПРОБЛЕМА?????????????????????
    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
    

    
}

