using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public LayerMask mask;

    void Ray()
    {
        //rayの作成
        Ray ray = new Ray(transform.position, transform.forward);
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //rayが衝突したコライダーの情報を得る
        RaycastHit hit;
        //rayが衝突したかどうか
        if(Physics.Raycast(ray,out hit, 10.0f, mask))
        {
            //rayの原点から衝突地点までの距離を得る
            float dis = hit.distance;
            //衝突したオブジェクトのコライダーを非アクティブにする
            hit.collider.enabled = false;
        }

        if (Physics.SphereCast(ray, 5.0f, out hit, 10.0f)){ }

        //rayの可視化
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);

    }
}
