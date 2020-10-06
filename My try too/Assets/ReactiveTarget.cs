using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    { //Метод, вызванный сценарием стрельбы.
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)//<-Проверяем, присоединен ли к персонажу сценарий
                             //WanderingAI; он может и отсутствовать
        {
            behavior.SetAlive(false);
        }
      StartCoroutine(Die());
    }

    private IEnumerator Die()
    { //Опрокидываем врага, ждем 1,5 секунды и уничтожаем его.
        this.transform.Rotate(-150, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject); // Объект может уничтожать сам себя точно
        //так же, как любой другой объект.
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
