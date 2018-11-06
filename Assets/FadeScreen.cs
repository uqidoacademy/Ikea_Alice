using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour {

    // This has to be attached to a camera

    GameObject plane = null;
    
    public float AnimationDuration = 4;

    void FadeEffectNow()
    {
        GameObject planeInstance = GetPlaneInFront();
        Material material = planeInstance.GetComponent<Renderer>().material;
        material.color = Color.clear;

        Sequence seq = DOTween.Sequence();
        seq.Append(material.DOColor(Color.black, AnimationDuration / 3));
        seq.AppendInterval(AnimationDuration / 3);
        seq.OnComplete(() =>
        {
            material.DOColor(Color.clear, AnimationDuration / 3);
        });
    }

    GameObject GetPlaneInFront()
    {
        Transform CameraTransform = GetComponent<Transform>();

        if (plane == null)
            plane = GameObject.CreatePrimitive(PrimitiveType.Quad);
        plane.transform.parent = CameraTransform;
        plane.transform.position = transform.position;
        plane.transform.rotation = transform.rotation;
        plane.transform.localScale = new Vector3(2, 2, 2);
        plane.transform.Translate(0.0f, 0.0f, 0.5f);
        //plane.transform.LookAt(CameraTransform.position);

        // set material
        Renderer rend = plane.GetComponent<Renderer>();

        rend.material = Resources.Load("fadeViewMaterial", typeof(Material)) as Material;

        return plane;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            FadeEffectNow();
        }
    }
}