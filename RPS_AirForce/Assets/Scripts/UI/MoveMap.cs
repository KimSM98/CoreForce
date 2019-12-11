using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public float Speed = 2f;
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
        }
        this.transform.Translate(new Vector2(0, -Speed * Time.deltaTime));
    }
}
