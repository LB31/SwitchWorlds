using UnityEngine;
using UnityEngine.XR;

// Attach this controller to the main camera, or an appropriate
// ancestor thereof, such as the "player" game object.
public class GyroController : MonoBehaviour
{

    void Start() {

        // Make sure orientation sensor is enabled.
        Input.gyro.enabled = true;
    }

    void Update() {
        //if (Input.gyro.enabled) {
        //    print(Input.gyro.attitude.x);
        //    transform.rotation = new Quaternion(transform.rotation.x, 0, 0, 1);
        //}
    }


}
