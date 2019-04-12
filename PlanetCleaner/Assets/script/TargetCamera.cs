using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // スムーズにする係数(1の場合は1秒で指定の位置まで移動、5の場合は0.2秒で指定の位置まで移動)
    [SerializeField]
    private float smoothing = 5f;

    private Vector3 offset;

    private void Start()
    {
        this.offset = this.transform.position - this.target.position;
    }

    private void FixedUpdate()
    {
        Vector3 currentPosition = this.target.transform.position + this.offset;
        currentPosition = currentPosition + new Vector3(0.0f,11.0f,8.0f);
        this.transform.position = Vector3.Lerp(this.transform.position, currentPosition, Time.deltaTime * this.smoothing);

    }

}
