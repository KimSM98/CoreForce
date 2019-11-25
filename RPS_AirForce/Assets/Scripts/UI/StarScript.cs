using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    float alpha = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha <= 0.5f && alpha <= 1)
            alpha += 0.1f;
        else if(alpha > 1.0f)
            alpha -= 0.1f;

        this.GetComponent<SpriteRenderer>().color = new Color(1,1,1, alpha);
    }
}
