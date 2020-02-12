using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomSpray : MonoBehaviour
{
    
    
    [SerializeField]
    private Transform Box;
    public int activity = 0;
    private RectTransform rect;
    private Image image;
    private Transform CameraView;
    [SerializeField]
    private GameObject Anim;
   
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    
    void Update()
    {
        var screenP = Camera.main.WorldToScreenPoint(Box.position);
        rect.position = screenP;
        var viewP = Camera.main.WorldToScreenPoint(rect.position);
        var distance = Vector2.Distance(viewP, Vector2.one * 0.5f);
        var show = distance < 0.3f;
        image.enabled = show;
        Box.LookAt(CameraView);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(Box.position, new Vector3(1, 1, 1));


    }
    public void OnClick()
    {
        if (activity < 1)
        {
            Anim.SetActive(true);
            activity++;
        }
        else
        {
            activity = 0;
            Anim.SetActive(false);
        }
    }
}

