using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScore : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private RectTransform myRect;
    private Vector3 offset = new Vector3(3.25f, 1.25f, 0);

    // Start is called before the first frame update
    void Start()
    {
        myRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        myRect.position
            = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position + offset);
    }
}
