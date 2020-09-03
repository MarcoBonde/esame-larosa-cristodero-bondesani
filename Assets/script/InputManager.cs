using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static InputManager Singleton;

    public float MinSwipeDelta = 1;

    public UnityEvent SwipeUp, SwipeRight, SwipeDown, SwipeLeft, Shoot;

    private void OnEnable()
    {
        Singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TouchFinder());
        StartCoroutine(ClickFinder());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InvokerChooser (Vector2 swipeDelta)
    {
        if (swipeDelta.magnitude > MinSwipeDelta)
        {
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            {
                if (swipeDelta.x > 0)
                {
                    SwipeRight.Invoke();
                }
                else
                {
                    SwipeLeft.Invoke();
                }
            }
            else if (Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y))
            {
                if (swipeDelta.y > 0)
                {
                    SwipeUp.Invoke();
                }
                else
                {
                    SwipeDown.Invoke();
                }
            }
        }
        else
        {
            Shoot.Invoke();
        }
    }
    //per il cellulare
    IEnumerator TouchFinder()
    {
        Vector2 startTouchPosition;
        Vector2 endTouchPosition;
        Vector2 swipeDelta;
        while (true)
        {
            yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
            startTouchPosition = Input.GetTouch(0).position;
            yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended);
            endTouchPosition = Input.GetTouch(0).position;
            swipeDelta = endTouchPosition - startTouchPosition;
            //manda al codice per scegliere l'azione da invocare
            InvokerChooser(swipeDelta);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
    //per il computer
    IEnumerator ClickFinder()
    {
        Vector2 startTouchPosition;
        Vector2 endTouchPosition;
        Vector2 swipeDelta;
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            startTouchPosition = Input.mousePosition;
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            endTouchPosition = Input.mousePosition;
            swipeDelta = endTouchPosition - startTouchPosition;
            //manda al codice per scegliere l'azione da invocare
            InvokerChooser(swipeDelta);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}
