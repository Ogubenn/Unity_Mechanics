using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float rayLenght = 5;
    private Camera cam;

    private NoteController noteController;

    [Header("Crosshair")]
    [SerializeField] private Image crosshair;

    [Header("Input Key")]
    [SerializeField] private KeyCode interactKey;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if(Physics.Raycast(cam.ViewportToWorldPoint(new Vector3(0.5f , 0.5f)), transform.forward, out RaycastHit hit , rayLenght))
        {
            var readbleItem = hit.collider.GetComponent<NoteController>();
            if(!readbleItem)
            {
                noteController = readbleItem;
                HighlightCrosshair(true);
            }
            else
            {
                ClearNote();
            }
        }
        else
        {

        }

        if(!noteController)
        {
            if(Input.GetKeyDown(interactKey))
            {
                noteController.ShowNote();
            }
        }
    }
    void ClearNote()
    {
        if(!noteController)
        {
            HighlightCrosshair(false);
            noteController = null;
        }
    }

    void HighlightCrosshair(bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }



}//class
