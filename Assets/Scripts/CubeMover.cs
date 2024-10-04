using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeMover : MonoBehaviour {
    public bool active = false;

    private float radius = 5f;
    public bool cooldown = false;
    public bool reachedEnd = false;
    public Vector3 control;
    public bool xMode = false;

    private void Update() {
        if (active) {

            Vector3 controlx = new Vector3(-1f * Mathf.Cos(4f * Time.time), -0.5f * Mathf.Sin(8f * Time.time), 0f);
            Vector3 controly = new Vector3(-1f * 0.5f * Mathf.Sin(8f * Time.time), -1f * Mathf.Cos(4f * Time.time), 0f);
            control = controly;

            /*if (transform.position.magnitude > 4.9975f) {
                reachedEnd = true;
            }*/

            //if ((control * radius).magnitude - transform.position.magnitude < 0f && reachedEnd) {
            if (PassOrigin(control, radius)) {
                if (cooldown) {
                    cooldown = false;
                } else {
                    xMode = !xMode;
                    cooldown = true;
                }
                reachedEnd = false;
            }

            if (xMode) {
                control = controlx;
            } else {
                control = controly;
            }

            transform.position = control * radius;

            float temp = 0f;
            temp += transform.position.x * transform.position.x;
            temp += transform.position.y * transform.position.y;
            temp += transform.position.z * transform.position.z;
            temp = Mathf.Pow(temp, 0.5f);

        } else {
            Move();
        }
    }

    private bool PassOrigin(Vector3 ctrl, float radius) {
        ctrl *= radius;
        switch (xMode) {
            case true:
                //if long
                if (transform.position.x < 2.5f && transform.position.x > -2.5f) {
                    switch (ctrl.x > 0f) {
                        //next x
                        case true:
                            //if next x is positive
                            if (transform.position.x < 0f) {
                                //true if current x is negative
                                return true;
                            } else return false;
                        case false:
                            //if next x is negative
                            if (transform.position.x > 0f) {
                                //true if current x is positive
                                return true;
                            } else return false;
                    }
                } else return false;
                
            case false:
                //if tall
                if (transform.position.y < 2.5f && transform.position.y > -2.5f) {
                    switch (ctrl.y > 0f) {
                        //next y
                        case true:
                            //if next y is positive
                            if (transform.position.y < 0f) {
                                //true if current y is negative
                                return true;
                            } else return false;
                        case false:
                            //if next y is negative
                            if (transform.position.y > 0f) {
                                //true if current y is positive
                                return true;
                            } else return false;
                    }
                } else return false;
                
    }
        
        
    }

    private void Move() {
        Vector3 vec = Vector3.zero;
        vec.y += (Input.GetKey(KeyCode.W)) ? 1 : (Input.GetKey(KeyCode.S)) ? -1 : 0;
        vec.x += (Input.GetKey(KeyCode.D)) ? 1 : (Input.GetKey(KeyCode.A)) ? -1 : 0;
        float speed = 5f;
        transform.position += vec * speed * Time.deltaTime;
    }
}
