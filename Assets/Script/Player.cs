using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float hAxis;
    private float vAxis;
    private Vector3 moveVec;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // "Horizontal" 값은 프로젝트 Input Settings에 정의되어 있음
        hAxis = Input.GetAxisRaw("Horizontal"); // horizon 값을 정수로 반환
        vAxis = Input.GetAxisRaw("Vertical");

        // 움직임 정의
        moveVec = new Vector3(hAxis, 0, vAxis).normalized; 
        // 위, 왼쪽 같이 누르면 (1, 0, 1)인데, 이 경우 대각선은 2^(1/2)가 됨.
        // 대각선으로 움직일 때 속도가 빨라진다? 말이 안 됨 -> normalized로 해결

        transform.position += moveVec * speed * Time.deltaTime;
    }
}
