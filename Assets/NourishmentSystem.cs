using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NourishmentSystem : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite stage1, stage2, stage3, stage4;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        stage1 = Resources.Load<Sprite>("PlantA S1");
        stage2 = Resources.Load<Sprite>("PlantA S2");
        stage3 = Resources.Load<Sprite>("PlantA S3");
        stage4 = Resources.Load<Sprite>("PlantA S4");
        rend.sprite = stage2;
    }
}
