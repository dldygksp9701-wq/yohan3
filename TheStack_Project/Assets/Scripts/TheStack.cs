using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheStack : MonoBehaviour
{
    private const float boundSize = 3.5f;
    private const float movingBoundsSize = 1f;
    private const float stackMovingSpeed = 5.0f;
    private const float blockMovingSpeed = 3.5f;
    private const float errorMargin = 0.1f;

    public GameObject originBlock = null;

    private Vector3 prevBlockPosition;
    private Vector3 desiredPosition;
    private Vector3 stackBounds = new Vector2(boundSize, boundSize);
    
    Transform lastBlock = null;
    float blockTrangition = 0f;
    float secondaryPosition = 0f;

    int stackCount = -1;
    int comboCount = 0;
    void Start()
    {
        
        prevBlockPosition = Vector3.down;

        Spawn_Block();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Spawn_Block();
        }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, stackMovingSpeed * Time.deltaTime);
    }
    
    bool Spawn_Block()
    {
        if(lastBlock != null)
        
            prevBlockPosition = lastBlock.localPosition;
            GameObject newBlock = null;
            Transform newtrans = null;

            newBlock = Instantiate(originBlock);
            newtrans = newBlock.transform;
            newtrans.parent = this.transform;
            newtrans.localPosition = prevBlockPosition + Vector3.up;
            newtrans.localRotation = Quaternion.identity;
            newtrans.localScale = new Vector3(stackBounds.x, 1, stackBounds.y); //

            stackCount++;

            desiredPosition = Vector3.down * stackCount; //
            blockTrangition = 0f;

            lastBlock = newtrans;
            return true;
        
    }
}
