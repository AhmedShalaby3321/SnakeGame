using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SwipeDirection
{
    none,
    up,
    down,
    right,
    left
}
public enum TouchState
{
    None,
    Tap,
    Hold,
    Swipe
}
public class ScreenTouchInputs : MonoBehaviour
{

    [SerializeField] SnakeMovement snakeMovement;
    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;
    public bool detectSwipeAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPos = touch.position;
                fingerDownPos = touch.position;
            }

            //Detects Swipe while finger is still moving on screen
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeAfterRelease)
                {
                    snakeMovement.canHaveInputs = true;
                    fingerDownPos = touch.position;
                    DetectSwipe();
                }
            }

            //Detects swipe after finger is released from screen
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPos = touch.position;
                snakeMovement.canHaveInputs = false;
                //DetectSwipe();
            }
        }
    }

    void DetectSwipe()
    {

        if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
        {
            Debug.Log("Vertical Swipe Detected!");
            if (fingerDownPos.y - fingerUpPos.y > 0)
            {
                OnSwipeUp();
            }
            else if (fingerDownPos.y - fingerUpPos.y < 0)
            {
                OnSwipeDown();
            }
            fingerUpPos = fingerDownPos;

        }
        else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
        {
            Debug.Log("Horizontal Swipe Detected!");
            if (fingerDownPos.x - fingerUpPos.x > 0)
            {
                OnSwipeRight();
            }
            else if (fingerDownPos.x - fingerUpPos.x < 0)
            {
                OnSwipeLeft();
            }
            fingerUpPos = fingerDownPos;

        }
        else
        {
            Debug.Log("No Swipe Detected!");
        }
    }

    float VerticalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    float HorizontalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }

    void OnSwipeUp()
    {

    }

    void OnSwipeDown()
    {


    }

    void OnSwipeLeft()
    {
        snakeMovement.movementDir = Vector3.left;
        snakeMovement.rotationDir = -1;
    }

    void OnSwipeRight()
    {
        snakeMovement.movementDir = Vector3.right;
        snakeMovement.rotationDir = 1;
    }
}

#region disabled

// [Header("Input State")]
// public TouchState touchState = TouchState.None;
// public SwipeDirection swipeDirection;

// [Header("Input Direction")]
// public Vector3 dir;
// private Vector3 startPos, endPos;

// [Header("Swipe Settings")]
// public float minSwiptTime, maxSwipeTime, swipeDistance = 0;
// private float startSwipeTime, endSwiptTime;
// bool resetInputs;
// public static ScreenTouchInputs Instance;
// void Start()
// {
//     Instance = this;
// }
// // Update is called once per frame
// void Update()
// {
//     CheckPlayerInputs();
// }

// public void CheckPlayerInputs()
// {
//     swipeDirection = SwipeDirection.none;
//     touchState = TouchState.None;
//     if (EventSystem.current.currentSelectedGameObject != null)
//         return;
//     if (Input.touchCount > 0)
//     {
//         Touch touch = Input.GetTouch(0);
//         if (touch.phase == TouchPhase.Began)
//         {
//             startPos = touch.position;
//             startSwipeTime = Time.time;
//         }
//         if (touch.phase == TouchPhase.Ended)
//         {
//             endPos = touch.position;
//             endSwiptTime = Time.time;

//             float timeRange = endSwiptTime - startSwipeTime;
//             float distance = (endPos - startPos).magnitude;


//             if (timeRange <= minSwiptTime && distance < swipeDistance)
//             {
//                 touchState = TouchState.Tap;
//                 CharacterMovement.Instance.Fly();
//             }

//             else if (timeRange > minSwiptTime && timeRange <= maxSwipeTime && distance > swipeDistance)
//             {
//                 touchState = TouchState.Swipe;
//                 CheckSwipeDirection(startPos, endPos);

//                 dir = (endPos - startPos).normalized;
//                 if (swipeDirection == SwipeDirection.up)
//                     CharacterMovement.Instance.Jump();
//                 else if (swipeDirection == SwipeDirection.down)
//                     CharacterMovement.Instance.FlyDown();
//             }
//         }
//         //Debug.Log(touchState.ToString() + " " + swipeDirection.ToString());
//     }

// }
// void CheckSwipeDirection(Vector3 startPos, Vector3 endPos)
// {
//     float xDifferance = Mathf.Abs(endPos.x) - Mathf.Abs(startPos.x);
//     float yDifferance = Mathf.Abs(endPos.y) - Mathf.Abs(startPos.y);
//     float xyDifferance = xDifferance - yDifferance;

//     if (yDifferance > 0)
//         swipeDirection = SwipeDirection.up;
//     else if (yDifferance < 0)
//         swipeDirection = SwipeDirection.down;
//     else
//         swipeDirection = SwipeDirection.none;
// }
// IEnumerator ResetInputs()
// {
//     if (resetInputs)
//         yield break;

//     resetInputs = true;
//     yield return new WaitForEndOfFrame();
//     touchState = TouchState.None;
//     resetInputs = false;
// }
#endregion