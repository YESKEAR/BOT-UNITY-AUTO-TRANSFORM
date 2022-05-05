using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControler : MonoBehaviour
{

    public int Power;
    public int MaxSteerAngle;
    public WheelCollider[] Wheels;
    
    public Transform Target;
    void Start()
    {
    }

    void FixedUpdate()
    {
        Drive();
        Steer();
    }

    void Drive()
    {
        Wheels[2].motorTorque = Power;
        Wheels[3].motorTorque = Power;
    }
    void Steer()
    {
        Vector3 RelativeVector = transform.InverseTransformPoint(Target.position);
        float NewSteer = (RelativeVector.x / RelativeVector.magnitude) * MaxSteerAngle;

        Wheels[0].steerAngle = Mathf.Lerp(Wheels[0].steerAngle, NewSteer, 3 * Time.deltaTime);
        Wheels[1].steerAngle = Mathf.Lerp(Wheels[1].steerAngle, NewSteer, 3 * Time.deltaTime);
    }
}
