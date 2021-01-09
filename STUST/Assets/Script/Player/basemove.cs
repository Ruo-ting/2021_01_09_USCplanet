using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using Photon.Pun.Demo.PunBasics;

public class basemove : MonoBehaviourPun
{
    public static basemove instance;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Animator animator;
    private bool Running = false;
    public float time = 5;
    public float jumpSpeed = 10;
    public GameObject cam;
    private Rigidbody rb;

    bool IsGround;
    public bool isTalking = false ;//移動中無法說話

    public Text nametext;

    void Awake()
    {
        //if (photonView.IsMine)
        //{
        //    nametext.text = PhotonNetwork.NickName;
        //}
        //else
        //{
        //    //nametext.text = photonView.Owner.NickName;
        //}
        if (instance == null)
            instance = this;
        else if (instance != this)
           Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); //獲取自身AI组件
        animator = GetComponent<Animator>();     //動畫组件
        rb = GetComponent<Rigidbody>();
        CameraWork _cameraWork =
        cam.gameObject.GetComponent<CameraWork>();

        if (_cameraWork != null)
        {
            if (photonView.IsMine)
            {
               _cameraWork.OnStartFollowing();
           }
        }
        else
        {
            Debug.LogError("playerPrefab- CameraWork component 遺失",
                this);
        }

    }

    void Update()
    {
        //if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        //{
            if (isTalking)
            {
                if (Input.GetKey(KeyCode.W)) //前
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    animator.SetBool("walk", true);
                    transform.Translate(Vector3.forward * time * Time.deltaTime);
                    //animator.SetBool("Idle", false);

                    if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
                        animator.SetBool("Run", true);
                    else
                    {
                        animator.SetBool("Run", false);
                        animator.SetBool("walk", true);
                    }
                }
                else if (Input.GetKey(KeyCode.S)) //后
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    animator.SetBool("walk", true);
                    transform.Translate(Vector3.forward * time * Time.deltaTime);
                    //animator.SetBool("Idle", false);

                    if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
                        animator.SetBool("Run", true);
                    else
                    {
                        animator.SetBool("Run", false);
                        animator.SetBool("walk", true);
                    }
                }
                else if (Input.GetKey(KeyCode.D)) //左
                {
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    animator.SetBool("walk", true);
                    transform.Translate(Vector3.forward * time * Time.deltaTime);
                    //animator.SetBool("Idle", false);

                    if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
                        animator.SetBool("Run", true);
                    else
                    {
                        animator.SetBool("Run", false);
                        animator.SetBool("walk", true);
                    }
                }
                else if (Input.GetKey(KeyCode.A)) //右
                {
                    transform.eulerAngles = new Vector3(0, 270, 0);
                    animator.SetBool("walk", true);
                    transform.Translate(Vector3.forward * time * Time.deltaTime);
                    //animator.SetBool("Idle", false);

                    if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
                        animator.SetBool("Run", true);
                    else
                    {
                        animator.SetBool("Run", false);
                        animator.SetBool("walk", true);
                    }
                }
                else
                {
                    animator.SetBool("walk", false);
                    animator.SetBool("Run", false);
                    //animator.SetBool("Idle", true);
                }
            }
            else
                rb.velocity = Vector3.zero;     
        //}
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            animator.SetBool("Jump", true);
            
            rb.AddForce(Vector3.up * jumpSpeed);
            IsGround = false;
            rb.velocity = new Vector3(0, 5, 0); //新增加速度
            //rb.AddForce(Vector3.up * jumpSpeed); //給剛體一個向上的力，力的大小為Vector3.up*mJumpSpeed
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        }
        else
            animator.SetBool("Jump", false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Plane")
            IsGround = true;
    }
}
