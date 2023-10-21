using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgmove : MonoBehaviour
{
    public float speed;
    public int startIDX;
    public int endIDX;
    public Transform[] sprites;

    public float diffWidth;

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = (Vector3.right * -1) * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

        if(sprites[endIDX].position.x < (diffWidth * 2) * (-1))
        {
            Vector3 backSpritePos = sprites[startIDX].localPosition;

            sprites[endIDX].transform.localPosition = backSpritePos + Vector3.right * diffWidth;

            int startidxSave = startIDX;
            startIDX = endIDX;
            endIDX = (startidxSave - 1 == -1) ? sprites.Length - 1 : startidxSave - 1;
        }
    }
}
