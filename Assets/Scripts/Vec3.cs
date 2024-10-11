using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Vec3
{
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;

    private static readonly Vec3 zeroVec = new Vec3(0f, 0f, 0f);
    private static readonly Vec3 oneVec = new Vec3(1f, 1f, 1f);

    public Vec3() {
        x = 0f;
        y = 0f;
        z = 0f;
    }

    public Vec3(float _x, float _y, float _z) {
        x = _x;
        y = _y;
        z = _z;
    }

    public float Magnitude() {
        return Mathf.Sqrt(x * x + y * y + z * z);
    }

    public override string ToString() {
        return "(" + x + ", " + y + ", " + z + ")";
    }

    public static Vec3 zero {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return zeroVec;
        }
    }

    public static Vec3 one {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return oneVec;
        }
    }

    //oveload the add (+) operator
    public static Vec3 operator + (Vec3 a, Vec3 b) {
        return new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    //overload the subtract (-) operator
    public static Vec3 operator - (Vec3 a, Vec3 b) {
        return new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    //overload the multiply (*) operator 
    public static Vec3 operator * (Vec3 a, Vec3 b) {
        return new Vec3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    public static Vec3 operator * (Vec3 a, float b) {
        return new Vec3(a.x * b, a.y * b, a.z * b);
    }
    
    public static Vec3 operator * (float a, Vec3 b) {
        return new Vec3(a * b.x, a * b.y, a * b.z);
    }

    //overload the power (^) operator
    public static Vec3 operator ^ (Vec3 a, int b) {
        Vec3 c = Vec3.one;
        for (int i = 0; i < b; i++) {
            c *= a;
        }
        return c;
    }
}