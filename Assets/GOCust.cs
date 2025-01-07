using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GOCust : MonoBehaviour
{

    public Image image;
    public TMP_Text text;
    public GameObject go;
    public Button btn;
    public RectTransform rt;
    public Vector3 startPos;
    public bool allowMove;
    public Vector3 offScreenPos;
    public bool offScreen = true;

    public GOCust(Image imagePrm) {
        image = imagePrm;
        rt = image.GetComponent<RectTransform>();
        startPos = rt.position;
        allowMove = false;
    }

    public GOCust(TMP_Text textPrm) {
        text = textPrm;
        rt = text.GetComponent<RectTransform>();
        startPos = rt.position;
        allowMove = false;
    }

    public GOCust(GameObject goPrm) {
        go = goPrm;
        rt = go.GetComponent<RectTransform>();
        startPos = rt.position;
        allowMove = false;
    }

    public GOCust(Button btnPrm) {
        btn = btnPrm;
        rt = btn.GetComponent<RectTransform>();
        startPos = rt.position;
        allowMove = false;
    }

    // public void Move(float moveAmount, bool hor) {
    public void Move() {
        Vector3 target = determineDirection();
        // horizontal
        if (isHorizontal()) {
            // ke kanan
            if (target.x - rt.position.x < 0) {
                if (rt.position.x > target.x) {     
                    Vector3 newPosition = rt.position + new Vector3(-20f, 0f, 0f);
                    rt.position = newPosition;
                    if (rt.position.x <= target.x) stopMove();
                } else stopMove();
            // ke kiri
            } else {
                if (rt.position.x < target.x) {     
                    Vector3 newPosition = rt.position + new Vector3(20f, 0f, 0f);
                    rt.position = newPosition;
                    if (rt.position.x >= target.x) stopMove();
                } else stopMove();
            }
        } else {
            // ke bawah
            if (target.y - rt.position.y < 0) {
                if (rt.position.y > target.y) {     
                    Vector3 newPosition = rt.position + new Vector3(0f, -20f, 0f);
                    rt.position = newPosition;
                    if (rt.position.y <= target.y) stopMove();
                } else stopMove();
            // ke atas
            } else {
                if (rt.position.y < target.y) {     
                    Vector3 newPosition = rt.position + new Vector3(0f, 20f, 0f);
                    rt.position = newPosition;
                    if (rt.position.y >= target.y) stopMove();
                } else stopMove();
            }
        }
        // if (hor && )
        // if (hor && moveAmount < 0) {
        //     if (rt.position.x > startPos.x) {
        //         Vector3 newPosition = rt.position + new Vector3(moveAmount, 0f, 0f);
        //         rt.position = newPosition;
        //     } else {
        //         allowMove = false;
        //         // offScreen = !offScreen;
        //     }
        // } else if (hor && moveAmount >= 0) {
        //     if (rt.position.x < startPos.x) {
        //         Vector3 newPosition = rt.position + new Vector3(moveAmount, 0f, 0f);
        //         rt.position = newPosition;
        //     } else {
        //         allowMove = false;
        //     }
        // } else if (!hor && moveAmount < 0) {
        //     if (rt.position.y > startPos.y) {
        //         Vector3 newPosition = rt.position + new Vector3(0f, moveAmount, 0f);
        //         rt.position = newPosition;
        //     } else {
        //         allowMove = false;
        //     }
        // } else {
        //     if (rt.position.y < startPos.y) {
        //         Vector3 newPosition = rt.position + new Vector3(0f, moveAmount, 0f);
        //         rt.position = newPosition;
        //     } else {
        //         allowMove = false;
        //     }
        // }
        
    }

    private bool isHorizontal()
    {
        return startPos.y == offScreenPos.y;
    }

    private Vector3 determineDirection()
    {
        if (offScreen) return startPos;
        else return offScreenPos;
    }

    private void stopMove()
    {
        allowMove = false;
        offScreen = !offScreen;
    }

}
