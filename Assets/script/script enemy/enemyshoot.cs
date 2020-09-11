
using UnityEngine;
using UnityEngine.UI;

public class Enemyshoot : MonoBehaviour 
{
    
    private float timer;
    private bool is_seeking;
    private int score;
    public Transform bullet_gun;
    public Transform gun;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {

            score += 1;
            timer = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
                if (score %2 == 0)

                    {

                        is_seeking = true;
                
                    }
                if (is_seeking == true )

                    {

                        Instantiate(bullet_gun, gun);

                    }

            if (score % 2 == 1)
            {
                is_seeking = false;
            }
        }
 
    }
}