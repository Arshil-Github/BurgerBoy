using UnityEngine;

public class CamControl : MonoBehaviour
{

    public float panSpeed;
    public float borderthickness;
    public Vector2 panlimitmax;
    public Vector2 panlimitmin;

    Vector3 direction;
    Vector3 touchStart;
    Vector3 pos;


    public float zoomOutMin = 1;
    public float zoomOutMax = 8;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            pos = transform.position;
            pos += direction;
            transform.position = pos;
        }
    }


    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
