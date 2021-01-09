using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offsetPosition;//位置偏移
    private Transform player;
    public float distance = 0;
    public float scrollspeed = 10;//滑鼠滾輪拉近拉遠的速度
    private bool isRotating = false;
    public float rotateSpeed = 2F;//攝像機繞著角色旋轉時的旋轉速度

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
        offsetPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offsetPosition + player.position;

        //處理視野的旋轉
        RotateView();
        //處理視野的拉近和拉遠效果
        ScrollView();//這裡的RotateView呼叫要放在SCrollView()前面，如果要放置在後面，則ScrollSpeed要設定很大，因為ScrollView和RotateView都在Update函式中，相對於一幀的時間，這兩個函式的執行時間間隔小很多，在SCrollView的重置offsetPosition語句offsetPosition = offsetPosition.normalized * distance;執行後，很快就輪到RotateView的offsetPosition = transform.position - player.position，這句話取消了ScrollView的效果，使得我們有效的滑鼠滑輪滑動時間變得很短，所以如果要將函式ScrollView放前面，則將ScrollSpeed設定很大。



    }


    void ScrollView()
    {
        //滑輪向前滑動(用於拉近視野)返回正值，向後滑動（用於拉遠視野）返回負值
        distance = offsetPosition.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollspeed;
        distance = Mathf.Clamp(distance, 5, 18);//Clamp函式控制distance的距離在5到18之間
        offsetPosition = offsetPosition.normalized * distance;
    }


    void RotateView()
    {
        //Input.GetAxis("Mouse X");//得到滑鼠在水平方向的滑動,向左時返回負數，向右返回正數
        //Input.GetAxis("Mouse Y");//得到滑鼠在垂直方向的滑動,向下時返回負數，向上返回正數


        if (Input.GetMouseButtonDown(1))//你需要在Update方法中呼叫這個方法，此後每一幀重置狀態時，它將不會返回true除非使用者釋放這個滑鼠按鈕然後重 	//新按下它。按鈕值設定為 0對應左鍵 ， 1對應右鍵 ， 2對應中鍵。
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }


        if (isRotating)
        {                           //某位置           //某軸            //旋轉度數
            transform.RotateAround(player.position, transform.up, rotateSpeed * Input.GetAxis("Mouse X"));//簡單的說，在世界座標的某位置的某軸按照旋轉度數旋轉呼叫這個函式的物體。
            Vector3 originalPos = transform.position; Quaternion originalRotation = transform.rotation;
            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));//影響本物體transform的屬性有兩個，一個是position 一個是rotation
            float x = transform.eulerAngles.x;
            if (x < 10 || x > 80)//垂直方向角度限制:不論怎麼旋轉都限制在10到80度之間
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
            x = Mathf.Clamp(x, 10, 80);//限制x的值在10和80之間， 如果x小於10，返回10。 如果x大於80，返回80，否則返回value 
            transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);//測試過之後發現上面兩句的沒什麼影響，可能是因為有了下面transform.LookAt(player);這句的存在
        }
        offsetPosition = transform.position - player.position;//因為旋轉後相對位置變了，要保持相對位置，原來的offsetposition已經不適用
        transform.LookAt(player);//保證不論怎麼旋轉都是角色在攝像機視野的正中心,如果去掉則會出現角色不在正中心的現象
    }
}
