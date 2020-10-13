using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public GameObject Car;
    private bool carmove;
    private bool countbool;
    private float countup = 0.0f;
    public AudioClip CarSE;
    // Start is called before the first frame update
    void Start()
    {
        carmove = false;
        countbool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (carmove == true)
        {
            Vector3 velocity=gameObject.transform.rotation*new Vector3(5,0,0);
            gameObject.transform.position += velocity *countup* Time.deltaTime;
            AudioSource.PlayClipAtPoint(CarSE, transform.position);
            
            //transform.position += new Vector3(0, 0, 5 * countup * Time.deltaTime);
        }
        if (countbool == true)
        {
            countup += Time.deltaTime;
        }

    }
    //  当たり判定を取得
    public void OnCollisionStay(Collision collision)
    {
        //"Player"tagを取得
        if (collision.gameObject.CompareTag("Player"))
        {

            //左クリックでTargetと親子関係に
            if (Input.GetMouseButtonDown(0))
            {
                this.gameObject.transform.parent = collision.gameObject.transform;
                Debug.Log("AAA");
                countbool = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                this.gameObject.transform.parent = null;
                carmove = true;
                countbool = false;

            }
            //当たり判定の確認
            Debug.Log("HEllo");
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        carmove = false;
    }
}
