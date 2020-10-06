using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{

    public float speed = 3.0f;
    public float maxZ = 16.0f; //<- Объект движется между этими точками.
    public float minZ = -16.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    private int _direction = 1; //<- В каком направлении объект движется в данный момент?

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, _direction * speed * Time.deltaTime);
        bool bounced = false;
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            _direction = -_direction; //<- Меняем направление на противоположное.
            bounced = true;
        }
        if (bounced)
        { //<- Делаем дополнительное движение в этом кадре, если объект поменял направление.
            transform.Translate(0, 0, _direction * speed * Time.deltaTime);
        }
    }
}
