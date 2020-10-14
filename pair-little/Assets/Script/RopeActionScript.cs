using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeActionScript : MonoBehaviour
{
    public GameObject Target;
    public FixedJoint fixedJoint;
    public bool Jointflag = false;
    public AudioClip MotuSE; //持つSE
    public AudioClip HanasuSE; //離すSE
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            Destroy(fixedJoint);
            AudioSource.PlayClipAtPoint(HanasuSE, transform.position);
            
            Debug.Log("AAA");
            Jointflag = false;

        }
        

    }

    //  当たり判定を取得
    public void OnCollisionStay(Collision collision)
    {
        //"Player"tagを取得
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //左クリックでPlayerとJointに
            if (Input.GetMouseButtonDown(0))
            {
                fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                Jointflag = true;
                AudioSource.PlayClipAtPoint(MotuSE, transform.position);
                
            }
            //右クリックでJointを解消
            if (Input.GetMouseButtonDown(1))
            {
                
                Destroy(fixedJoint);
                AudioSource.PlayClipAtPoint(HanasuSE, transform.position);
                //this.gameObject.transform.parent = null;
                Debug.Log("AAA");
                Jointflag = false;

            }
            
            //当たり判定の確認
            Debug.Log("HEllo");
        }
    }

}

