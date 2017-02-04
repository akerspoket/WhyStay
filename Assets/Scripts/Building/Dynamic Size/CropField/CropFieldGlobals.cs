using UnityEngine;
using System.Collections;

public class CropFieldGlobals : DynamicSizeBuilding{
    // Public variables
    [Header("Growth Variables")]
    [Tooltip("How many days it takes to get a full grown crop")]
    public float growingSpeed;
    //[Tooltip("How much a full grown crop yields")]
    //public float yieldFactor;
    //[Tooltip("")]
    private float growthPercentage = 0;
    
    public override void Update()
    {
        // How many days the fram took   
        float deltaDays = Time.deltaTime / 86400;

        growthPercentage += growingSpeed * deltaDays;
        growthPercentage = Mathf.Max(growthPercentage, 1.0f);
    }
}
