using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldActionScript : MonoBehaviour
{
    public GameObject Target;
    private FixedJoint fixedJoint;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)&&flag==true)
        {
            Destroy(fixedJoint);
            flag = false;
            //this.gameObject.transform.parent = null;


        }

    }

    //  当たり判定を取得
    public void OnCollisionStay(Collision collision)
    {
        //"Player"tagを取得
        if (collision.gameObject.CompareTag("Target"))
        {
            //左クリックでTargetとJointに
            if (Input.GetMouseButtonDown(0))
            {
                fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                flag = true;
                //this.gameObject.transform.parent = collision.gameObject.transform;
            }
            //右クリックでJointを解消
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(fixedJoint);
                //this.gameObject.transform.parent = null;
                Debug.Log("AAA");
                
            }
            //当たり判定の確認
            Debug.Log("HEllo");
        }
    }

}

