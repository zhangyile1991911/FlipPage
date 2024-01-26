using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMesh : MonoBehaviour
{
    private void Update()
    {
        UpdateMatrix();
    }

    private void UpdateMatrix() 
    {
        var matrix = CalcCanvas2LocalMatrix();
        Material material = GetComponent<Image>().material;
        material.SetMatrix("_Canvas2Local", matrix);
        material.SetMatrix("_Local2Canvas", matrix.inverse);
    }

    private Matrix4x4 CalcCanvas2LocalMatrix()
    {
        var canvaslist = GetComponentsInParent<Canvas>();
        int parentIndex = canvaslist.Length - 1;
        return transform.worldToLocalMatrix * canvaslist[parentIndex].transform.localToWorldMatrix;
    }
}
