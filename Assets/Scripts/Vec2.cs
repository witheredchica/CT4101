using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Vec2
{
    public float x = 0f;
    public float y = 0f;

    private static readonly Vec2 zeroVec = new Vec2(0f, 0f);
    private static readonly Vec2 oneVec = new Vec2(1f, 1f);

    public Vec2() {
        x = 0f;
        y = 0f;
    }

    public Vec2(float _x, float _y) {
        x = _x;
        y = _y;
    }

    public Vector3 ToVector3() {
        return new Vector3(x, y, 0f);
    }

    public float Magnitude() {
        return Mathf.Sqrt(x * x + y * y);
    }

    public override string ToString() {
        return "(" + x + ", " + y + ")";
    }

    public static Vec2 zero {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return zeroVec;
        }
    }

    public static Vec2 one {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return oneVec;
        }
    }

    //overload the add (+) operator
    public static Vec2 operator + (Vec2 a, Vec2 b) {
        return new Vec2(a.x + b.x, a.y + b.y);
    }

    //overload the minus (-) operator
    public static Vec2 operator - (Vec2 a, Vec2 b) {
        return new Vec2(a.x - b.x, a.y - b.y);
    }

    //overload the multiply (*) operator
    public static Vec2 operator * (Vec2 a, Vec2 b) {
        return new Vec2(a.x * b.x, a.y * b.y);
    }

    public static Vec2 operator * (Vec2 a, float b) {
        return new Vec2(a.x * b, a.y * b);
    }

    public static Vec2 operator * (float a, Vec2 b) {
        return new Vec2(a * b.x, a * b.y);
    }

    //overload the divide (/) operator
    public static Vec2 operator / (Vec2 a, float b) {
        return new Vec2(a.x / b, a.y / b);
    }

    public static Vec2 operator / (float a, Vec2 b) {
        return new Vec2(a / b.x, a / b.y);
    }

    //overload the power (^) operator
    public static Vec2 operator ^ (Vec2 a, int b) {
        Vec2 c = Vec2.one;
        for (int i = 0; i < b; i++) {
            c *= a;
        }
        return c;
    }
}