using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldActionScript2 : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject TargetObject;
    public AudioClip MotuSE; //持つSE
    public AudioClip HanasuSE; //離すSE

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Apos = PlayerObject.transform.position;
        Vector3 Bpos = TargetObject.transform.position;
        float dis = Vector3.Distance(Apos, Bpos);
        Debug.Log("Distance : " + dis);

        //左クリックでTargetと親子関係に
        if (Input.GetMouseButtonDown(0) && dis < 4)
        {
            TargetObject.gameObject.transform.parent = PlayerObject.gameObject.transform;
            AudioSource.PlayClipAtPoint(MotuSE, transform.position);
        }
        //右クリックで親子関係を解消
        if (Input.GetMouseButtonDown(1) && dis < 4)
        {
            this.gameObject.transform.parent = null;
            AudioSource.PlayClipAtPoint(HanasuSE, transform.position);
        }

    }
    //  当たり判定を取得
    /*public void OnCollisionStay(Collision collision)
    {
        //"Player"tagを取得
        if (collision.gameObject.CompareTag("Target"))
        {

            //左クリックでTargetと親子関係に
            if (Input.GetMouseButtonDown(0))
            {
                this.gameObject.transform.parent = collision.gameObject.transform;
                Debug.Log("AAA");
                
            }
            if (Input.GetMouseButtonDown(1))
            {
                this.gameObject.transform.parent = null;
                Debug.Log("BBB");

            }
            //当たり判定の確認
            Debug.Log("HEllo");
        }
    }*/
}
