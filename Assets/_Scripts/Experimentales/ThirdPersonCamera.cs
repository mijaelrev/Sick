using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] float sens;//sensivilidad

    [SerializeField] Transform target;

    Vector3 mouseDelta = Vector3.zero;
    Vector3 amount = Vector3.zero;

    [SerializeField] Vector3 addPos;

    RaycastHit hit;
    [SerializeField] float hitDistances;

    float tanFOV;

    Camera _camera;
    Vector3 lookAt = Vector3.zero;

    Vector3 cameraPos = Vector3.zero;
    Vector3 cameraPosOcc = Vector3.zero;
    Quaternion cameraRot = Quaternion.identity;

    Vector3 screenCenter = Vector3.zero;
    Vector3 up = Vector3.zero;
    Vector3 right = Vector3.zero;

    Vector3[] corners = new Vector3[5];

    void Start()
    {
        _camera = Camera.main;

        float HalfFOV = _camera.fieldOfView * 0.5f * Mathf.Deg2Rad;

        tanFOV = Mathf.Tan(HalfFOV) * _camera.nearClipPlane;
    }

    void Update()
    {
        screenCenter = (cameraRot * Vector3.forward) * _camera.nearClipPlane;
        up = (cameraRot * Vector3.up) * tanFOV;
        right = (cameraRot * Vector3.right) * tanFOV * _camera.aspect;

        corners[0] = cameraPos + screenCenter - up - right;
        corners[1] = cameraPos + screenCenter + up - right;
        corners[2] = cameraPos + screenCenter + up + right;
        corners[3] = cameraPos + screenCenter - up + right;
        corners[4] = cameraPos + screenCenter;

        hitDistances = 100000;

        for (int i = 0; i < 5; i++)
        {
            if (Physics.Linecast(target.transform.position + addPos, corners[i], out hit))
            {
                Debug.DrawLine(target.transform.position + addPos, corners[i], Color.red);

                Debug.DrawRay(hit.point, Vector3.up * 0.5f, Color.green);

                hitDistances = Mathf.Min(hitDistances, hit.distance);
            }
            else Debug.DrawLine(target.transform.position + addPos, corners[i], Color.blue);
        }

        if(hitDistances > 9999)
        {
            hitDistances = 0;
        }
    }

    private void LateUpdate()
    {

        mouseDelta.Set(Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y"),
            Input.GetAxisRaw("Mouse ScrollWheel"));

        amount += -mouseDelta * sens;
        amount.z = Mathf.Clamp(amount.z , 50, 100);
        amount.y = Mathf.Clamp(amount.y , 10, 89);

        cameraRot = Quaternion.AngleAxis(-amount.x, Vector3.up) * 
            Quaternion.AngleAxis(amount.y, Vector3.right);

        lookAt = cameraRot * Vector3.forward;

        cameraPos = target.transform.position + addPos - lookAt * amount.z * 0.1f;

        cameraPosOcc = target.transform.position + addPos - lookAt * hitDistances;

        if (hitDistances < _camera.nearClipPlane * 2.5f)
        {
            cameraPosOcc -= lookAt * _camera.nearClipPlane;
        }

        _camera.transform.rotation = cameraRot;

        if(hitDistances > 0)
        {
            _camera.transform.position = cameraPosOcc;
        }
        else
        {
            _camera.transform.position = cameraPos;
        }
    }
}
