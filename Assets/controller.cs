using UnityEngine;

public class controller : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4]; 
    public float speed;
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

        if (Input.GetKey(KeyCode.Space))
        {
            wheels[2].brakeTorque = Mathf.Lerp(wheels[2].brakeTorque, 3000, Time.deltaTime * 5);
            wheels[3].brakeTorque = Mathf.Lerp(wheels[3].brakeTorque, 3000, Time.deltaTime * 5);
            wheels[1].brakeTorque = Mathf.Lerp(wheels[2].brakeTorque, 3000, Time.deltaTime * 5);
            wheels[0].brakeTorque = Mathf.Lerp(wheels[3].brakeTorque, 3000, Time.deltaTime * 5);
            
            Debug.Log("Brake Torque: " + wheels[2].brakeTorque);
        }
        else
        {   wheels[0].brakeTorque = 0;
            wheels[1].brakeTorque = 0;
        
            wheels[2].brakeTorque = 0;
            wheels[3].brakeTorque = 0;
        }

        if (accel != 0 && getSpeed() < 80)
        {
            wheels[0].motorTorque = accel * speed;
            wheels[1].motorTorque = accel * speed;
            wheels[2].motorTorque = accel * speed;
            wheels[3].motorTorque = accel * speed;
        }
        else
        {
            wheels[0].motorTorque = 0;
            wheels[1].motorTorque = 0;
            wheels[2].motorTorque = 0;
            wheels[3].motorTorque = 0;
        }
    }

    private float getSpeed(){
        float speed = wheels[0].radius * wheels[0].rpm * Mathf.PI * 60 / 1000;
        Debug.Log("Speed: " + speed);
        return speed; }

}
