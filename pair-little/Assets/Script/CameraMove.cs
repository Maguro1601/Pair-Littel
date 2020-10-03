using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField]
    private Transform pivot;    //キャラクターの中心にある空のオブジェクトを選択してください

    

    void Start()
    {
        //エラーが起きないようにNullだった場合、それぞれ設定

        if (pivot == null)
            pivot = transform.parent;
    }
    

    
    void Update()
    {
        //マウスのX,Y軸がどれほど移動したかを取得します
        float h1 = Input.GetAxis("Horizontal1");
        float v1 = Input.GetAxis("Vertical1");
        //Y軸を更新します（キャラクターを回転）取得したX軸の変更をキャラクターのY軸に反映します
        // targetの位置のY軸を中心に、回転（公転）する
        pivot.transform.Rotate(0, h1, 0);

        //次はY軸の設定です。

        //最大値、または最小値を超えた場合、カメラをそれ以上動かない用にしています。
        //キャラクターの中身が見えたり、カメラが一回転しないようにするのを防ぎます。

        float maxLimit = 25;
        float minLimit = 360 - maxLimit;
        //X軸回転
        var localAngle = transform.localEulerAngles;
        localAngle.x += v1;
        if (localAngle.x > maxLimit && localAngle.x < 180)
            localAngle.x = maxLimit;
        if (localAngle.x < minLimit && localAngle.x > 180)
            localAngle.x = minLimit;
        transform.localEulerAngles = localAngle;



        //マウスのX,Y軸がどれほど移動したかを取得します
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        //Y軸を更新します（キャラクターを回転）取得したX軸の変更をキャラクターのY軸に反映します
        // targetの位置のY軸を中心に、回転（公転）する
        pivot.transform.Rotate(0, h, 0);

        //次はY軸の設定です。

        //最大値、または最小値を超えた場合、カメラをそれ以上動かない用にしています。
        //キャラクターの中身が見えたり、カメラが一回転しないようにするのを防ぎます。

        
        //X軸回転
    
        localAngle.x += v;
        if (localAngle.x > maxLimit && localAngle.x < 180)
            localAngle.x = maxLimit;
        if (localAngle.x < minLimit && localAngle.x > 180)
            localAngle.x = minLimit;
        transform.localEulerAngles = localAngle;

    }



}
