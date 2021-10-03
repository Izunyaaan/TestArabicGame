using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] string letters = "";
    bool[] ledger = {true, true, true, true};
    public GameObject[] letter;
    public Text output;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

        //if outside of box move onto itself
        var upperBound = 5.926721f;
        var lowerBound = -4.800028f;
        var leftBound = -9.063748f;
        var rightBound = 9.009109f;

        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, 0);
        }
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, 0);
        }
        if (transform.position.y > upperBound)
        {
            transform.position = new Vector3(transform.position.x, lowerBound, 0);
        }
        if (transform.position.y < lowerBound)
        {
            transform.position = new Vector3(transform.position.x, upperBound, 0);
        }
        for(int i = 0; i< 4; i++)
        {
            var distance = Vector2.Distance(transform.position, letter[i].transform.position);
            if(distance < 1f){
                if (ledger[i])
                {
                    ledger[i] = false;
                    letter[i].SetActive(false);
                    switch (i)
                    {
                        case 0:
                            letters += "KI";
                            break;
                        case 1:
                            letters += "T";
                            break;
                        case 2:
                            letters += "A";
                            break;
                        case 3:
                            letters += "B";
                            break;
                    }
                }
            }
        }
        output.text = letters;

    }
}
