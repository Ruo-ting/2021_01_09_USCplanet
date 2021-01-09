using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlTypeTest
{
    mouseControl,
    touchControl,
}

public class MouseFollowRotation : MonoBehaviour
{
    public ControlTypeTest controlType;
    public Transform rotTarget;

    //鼠標滾輪拉近拉遠
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;

    //旋转速度加成系数
    public float rotSpeedScalar = 20f;
    private float currentSpeed = 0;
    private void Start()
    {
        float a = float.Parse("-0.1994895");
        Debug.Log(a);
        
    }
    void Update()
    {
        if (controlType == ControlTypeTest.mouseControl)
        {
            //鼠標操作
            if (Input.GetMouseButton(0))
            {
                //拖動时速度
                //鼠標或手指在該帧移動的距離*deltaTime為手指移動的速度,此处为Input.GetAxis("Mouse X") / Time.deltaTime
                //不同帧率下lerp的第三个参数(即混合比例)也应根据帧率而不同--
                //考每秒2帧和每秒100帧的情况，如果此参数为固定值，那么在2帧的情况下，一秒后达到目标速度的0.75,而100帧的情况下，一秒后则基本约等于目标速度
                currentSpeed = Mathf.Lerp(currentSpeed, Input.GetAxis("Mouse X") / Time.deltaTime, 0.5f * Time.deltaTime);
            }
            else
            {
                //放開時速度
                currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.5f * Time.deltaTime);
            }
        }
        else if (controlType == ControlTypeTest.touchControl)
        {

            //触摸操作
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //在安卓設備上也可以用Mouse X,根據實驗，touch[0].deltaPosition.x的值總是比Mouse X的值大很多，所以此處使用Mouse X
                currentSpeed = Mathf.Lerp(currentSpeed, Input.touches[0].deltaPosition.x / Time.deltaTime / 15, 0.5f * Time.deltaTime);
                Debug.Log(1111);
            }
            else
            {
                //放開时速度
                currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.5f * Time.deltaTime);
            }
        }
        rotTarget.Rotate(Vector3.down, Time.deltaTime * currentSpeed * rotSpeedScalar);

        //控制攝影機拉近拉遠
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }

}


