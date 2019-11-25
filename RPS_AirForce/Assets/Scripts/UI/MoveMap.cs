using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public float Speed = 0.5f;
    public GameObject[] MapStars;

    int StarNum = 0;

    Vector2 firstPos;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (StarNum == MapStars.Length)
            StarNum = 0;

        if (MapStars[StarNum].transform.position.y < -10f)
        {
            MapStars[StarNum].transform.position = new Vector2(0, 10f);
            StarNum++;
            Debug.Log("다음 " + StarNum);
        }
            
            
       /* if (this.transform.position.y < -9f)
            this.transform.position = firstPos;
            */
        this.transform.Translate(new Vector2(0, Speed * -0.1f));

        //MapStars[StarNum].transform.Translate(new Vector2(0, Speed * -0.1f));
    }
}
