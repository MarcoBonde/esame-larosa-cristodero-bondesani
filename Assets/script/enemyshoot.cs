

using UnityEngine;
using UnityEngine.UI;

public class enemyshoot : MonoBehaviour 
{
    public Transform prefab;
    private float timer;
    private bool is_seeking;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            is_seeking = true;

            if (is_seeking == true)

                timer += Time.deltaTime;

            if (timer %2 == 0)

            {
                Instantiate(prefab);


                


                //Reset the timer to 0.
                timer = 0;
            }
        }
 
    }
}

