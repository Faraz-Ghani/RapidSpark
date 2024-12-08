using UnityEngine;

public class controller : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4]; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FixedUpdate(){
        float steer = Input.GetAxis("Horizontal");
        float accel = Input.GetAxis("Vertical");

        float finalAngle = steer * 30;
        wheels[0].steerAngle = finalAngle;
        wheels[1].steerAngle = finalAngle;

        if(accel != 0){
            wheels[0].motorTorque = accel * 2000;
            wheels[1].motorTorque = accel * 2000;
            wheels[2].motorTorque = accel * 2000;
            wheels[3].motorTorque = accel * 2000;
        }
    }

}
