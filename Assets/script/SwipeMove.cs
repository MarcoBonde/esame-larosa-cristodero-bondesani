using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour {

    //posizione iniziale del touch
    private Vector2 startTouchPosition;

    //posizione finale del touch
    private Vector2 endTouchPosition;

    // Update is called once per frame
    private void Update()
    {
        //Controllo se c'è un input e lo salvo nella variabile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        //Controllo la fine dell'input per mettere la endposition
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            // swipe a sinistra
            if (endTouchPosition.x < startTouchPosition.x) {
                //DAFARE arma precedente
            }

            // swipe a destra
            if (endTouchPosition.x > startTouchPosition.x) {
                //DAFARE arma successiva
            }    
        }
    }    
}
