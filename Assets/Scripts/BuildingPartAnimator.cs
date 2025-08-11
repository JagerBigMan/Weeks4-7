using System.Collections;
using UnityEngine;

public class BuildingPartAnimator : MonoBehaviour
{
    public AnimationCurve growthCurve;
    public float animationTime = 1f;

    public Transform buildingParts;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateParts());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator AnimateParts()
    {
        float t = 0f;
        while (t < animationTime)
        {
            t += Time.deltaTime;
            float progress = t / animationTime;             
            float scaleFactor = growthCurve.Evaluate(progress);    

            transform.localScale = Vector3.one * scaleFactor;
            yield return null;
        }

        transform.localScale = Vector3.one;  //This makes sure that the scale is locked to 1 which is the maximum size
    }
}
