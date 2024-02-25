using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    
    public Vector2Int posIndex;
    public Board_Controller board;//boardu kontrol eden scripte referans oluþturduk

    //match gem
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private bool mousePressed;
    private float swipeAngle = 0;
    private Gem otherGem;
    public GameObject destroyEffect;
    public enum GemType { blue1, blue2, green1, green2, green3, bomb,orange1,orange2,red1,red2,yellow1,yellow2,stone}

    public GemType type;
    public bool isMatched;
    public int blastSize = 2;
    [HideInInspector]
    private Vector2Int previousPos;
    public int scoreValue = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position,posIndex) >.01f)    
        {
            transform.position = Vector2.Lerp(transform.position, posIndex, board.gemSpeed * Time.deltaTime);
        }
        else
        {
            transform.position =new Vector3(posIndex.x,posIndex.y,0f);
            board.allGems[posIndex.x, posIndex.y] = this;
        }
        


        if (mousePressed && Input.GetMouseButtonUp(0)) 
        {
            mousePressed = false;
            if (board.currentState==Board_Controller.BoardState.move && board.roundMan.roundTime > 0) 
            {
                finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CalculateAngel();
            }
            
        }
    }
    public void SetUpGem(Vector2Int pos, Board_Controller theBoard)
    {
        posIndex = pos;
        board = theBoard;
    }
    private void OnMouseDown()
    {
        if (board.currentState==Board_Controller.BoardState.move&& board.roundMan.roundTime >0)
        {
            firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePressed = true;
        }

      
    }
    private void CalculateAngel()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x);
        swipeAngle =swipeAngle*180/Mathf.PI;

        if (Vector3.Distance(firstTouchPosition,finalTouchPosition) >.5f)
        {
            MovePieces();
        }
       
    }
    private void MovePieces()
    {
        previousPos = posIndex;
        if (swipeAngle <45 && swipeAngle >-45 && posIndex.x < board.width-1)
        {
            otherGem = board.allGems[posIndex.x+1,posIndex.y];
            otherGem.posIndex.x--;
            posIndex.x++;

        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && posIndex.y < board.height - 1)
        {
            otherGem = board.allGems[posIndex.x , posIndex.y+1];
            otherGem.posIndex.y--;
            posIndex.y++;
        }
         else if (swipeAngle < -45 && swipeAngle >= -135 && posIndex.y > 0)
        {
            otherGem = board.allGems[posIndex.x , posIndex.y -1];
            otherGem.posIndex.y++;
            posIndex.y--;
        }
        else if(swipeAngle > 135 || swipeAngle < -135 && posIndex.x > 0)
        {
            otherGem = board.allGems[posIndex.x - 1, posIndex.y ];
            otherGem.posIndex.x++;
            posIndex.x--;
        }
        board.allGems[posIndex.x,posIndex.y] = this;
        board.allGems[otherGem.posIndex.x, otherGem.posIndex.y] = otherGem;
        StartCoroutine(CheckMoveCo());
    }

    public IEnumerator CheckMoveCo()
    {
        board.currentState = Board_Controller.BoardState.wait;

        yield return new WaitForSeconds(.5f);
        board.matchFind.FindAllMatches();
        if (otherGem != null)
        {
            if (!isMatched && !otherGem.isMatched)
            {
                otherGem.posIndex = posIndex;
                posIndex = previousPos;

                board.allGems[posIndex.x, posIndex.y] = this;
                board.allGems[otherGem.posIndex.x, otherGem.posIndex.y] = otherGem;
                yield return new WaitForSeconds(.5f);
                board.currentState= Board_Controller.BoardState.move;
            }
            else
            {
                board.DestroyMatches();    
            }
        }
    }
}
