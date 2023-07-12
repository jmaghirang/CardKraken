using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//static class with useful static functions for reference in other classes
public static class Utils
{
    //ApproximatelyEqual returns true if a and b values are within EPISILON distance of each other
    public static float EPSILON = 1f;
    public static bool ApproximatelyEqual(float a, float b)
    {
        return Mathf.Abs(a-b) < EPSILON;
    }

    //FixAngle returns an adjusted angle for values of a approximatelyEqual to 0, 90, 180, etc. degrees
    public static float FixAngle(float a)
    {
        if(ApproximatelyEqual(a, 0))
            return 0;
        if(ApproximatelyEqual(a, 90))
            return 90;
        if(ApproximatelyEqual(a, 180))
            return 180;
        if(ApproximatelyEqual(a, 270))
            return 270;
        if(ApproximatelyEqual(a, 360))
            return 360;
        if(ApproximatelyEqual(a, -90))
            return -90;
        return a;
    }

    //Degrees360 adjusts the given angleDegrees to a value within 0 and 360
    public static float Degrees360(float angleDegrees)
    {
        if(angleDegrees >= 360)
            angleDegrees -= 360;
        if(angleDegrees < 0)
            angleDegrees += 360;
        return angleDegrees;
    }

    public static bool cardsOverlap(RectTransform a, RectTransform b) {
        return (a.WorldRect()).Overlaps(b.WorldRect());
    }

    public static Rect WorldRect(this RectTransform rectTransform)
    {
        Vector2 sizeDelta = rectTransform.sizeDelta;
        Vector2 pivot = rectTransform.pivot;
            
        float rectTransformWidth = sizeDelta.x * rectTransform.lossyScale.x;
        float rectTransformHeight = sizeDelta.y * rectTransform.lossyScale.y;

        Vector3 position = rectTransform.TransformPoint(rectTransform.rect.center);
        float x = position.x - rectTransformWidth * 0.5f;
        float y = position.y - rectTransformHeight * 0.5f;
            
        return new Rect(x,y, rectTransformWidth, rectTransformHeight);
    }
}
