using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform _camera;

    Vector3 firstPoint;
    Vector3 secondPoint;

    float xAngle;
    float yAngle;

    float xAngleTemp;
    float yAngleTemp;

    public float XAngleMinRotation;
    public float XAngleMaxRotation;


    public float YAngleMinRotation;
    public float YAngleMaxRotation;

    public Transform ShotPoint;

    public GameObject BulletPrefab;

    public float bulletSpeed;

    public float RechargeTime;
    private float Timer;

    public static bool Loose = false;

    // Start is called before the first frame update
    void Start()
    {
        xAngle = transform.localRotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Loose) return;

        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                firstPoint = touch.position;

                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                secondPoint = touch.position;

                xAngle = xAngleTemp - (secondPoint.y - firstPoint.y) * 90 / Screen.height;
                yAngle = yAngleTemp + (secondPoint.x - firstPoint.x) * 180 / Screen.width;

                xAngle = Mathf.Clamp(xAngle, XAngleMinRotation, XAngleMaxRotation);
                yAngle = Mathf.Clamp(yAngle, YAngleMinRotation, YAngleMaxRotation);

                transform.rotation = Quaternion.Euler(0, yAngle, 0);
                _camera.rotation = Quaternion.Euler(xAngle, yAngle, 0);
            }
        }
    }

    public void Shot()
    {
        GameObject H = Instantiate(BulletPrefab, ShotPoint.position, ShotPoint.rotation);

        H.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(bulletSpeed, 0, 0));
    }
}
