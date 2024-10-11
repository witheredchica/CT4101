using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testvec2 : MonoBehaviour
{
    private void Start() {
        Vec2 A = new Vec2(-7, 9);
        Vec2 B = new Vec2(3, 14);

        Debug.Log("A = " + A.ToString());
        Debug.Log("B = " + B.ToString());
        Debug.Log("A + B = " + (A + B).ToString());
        Debug.Log("A - B = " + (A - B).ToString());
        Debug.Log("3A - 2B = " + ((A * 3) - (B * 2)).ToString());
        Debug.Log("A ^ 3 = " + (A ^ 3).ToString());

        Vec3 C = new Vec3(-7, 9, 5);
        Vec3 D = new Vec3(3, 14, -8);

        Debug.Log("C = " + C.ToString());
        Debug.Log("D = " + D.ToString());
        Debug.Log("C + D = " + (C + D).ToString());
        Debug.Log("C - D = " + (C - D).ToString());
        Debug.Log("3C - 2D = " + ((C * 3) - (D * 2)).ToString());
        Debug.Log("C ^ 3 = " + (C ^ 3).ToString());
    }
}