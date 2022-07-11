using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float hAxis;
    private float vAxis;
    private bool walkDown;
    
    private Vector3 moveVec;

    private Animator anim;
    
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // "Horizontal" 값은 프로젝트 Input Settings에 정의되어 있음
        hAxis = Input.GetAxisRaw("Horizontal"); // horizon 값을 정수로 반환
        vAxis = Input.GetAxisRaw("Vertical");
        walkDown = Input.GetButton("Walk"); // left shift 누르고 있을 때 walkDown을 true로 변경

        // 움직임 정의
        moveVec = new Vector3(hAxis, 0, vAxis).normalized; 
        // 위, 왼쪽 같이 누르면 (1, 0, 1)인데, 이 경우 대각선은 2^(1/2)가 됨.
        // 대각선으로 움직일 때 속도가 빨라진다? 말이 안 됨 -> normalized로 해결

        transform.position += moveVec * speed * Time.deltaTime;
        
        anim.SetBool("isRun", moveVec != Vector3.zero); // 움직이지 않을 때 isRun이 false
        anim.SetBool("isWalk", walkDown);
    }
}
