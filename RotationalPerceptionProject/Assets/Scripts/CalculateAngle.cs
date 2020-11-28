using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CalculateAngle : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Text angleText;
    public float angle ;
    Vector3 direction;
    float sign = 1;



    void Update()
    {

        direction = target.transform.forward- transform.position;

        sign = (direction.x >= 0) ? 1 : -1;

//        angle = Vector3.Angle(Vector3.forward, target.transform.forward) * sign;
		angle=target.transform.rotation.eulerAngles.y;
		if(angle>180)angle=angle-360;

        angleText.text = angle.ToString();
		
       
    }
    private void FixedUpdate()
    {
        Debug.DrawLine(transform.position, target.transform.forward, Color.red);
    }

}
