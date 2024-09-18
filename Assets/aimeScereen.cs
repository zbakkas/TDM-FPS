using UnityEngine;
using UnityEngine.EventSystems;

public class aimeScereen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


  
    public Vector2 TouchDist;

   public Vector2 pointerOld;

    int pointerId;

    bool Pressed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            if (pointerId >= 0 && pointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[pointerId].position - pointerOld;
                pointerOld = Input.touches[pointerId].position;
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointerOld;
                pointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        pointerId = eventData.pointerId;
        pointerOld = eventData.position;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
