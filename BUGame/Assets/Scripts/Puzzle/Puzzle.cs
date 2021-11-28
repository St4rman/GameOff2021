using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Puzzle : MonoBehaviour {

    [SerializeField] GameObject app;
    [SerializeField] Camera camref;
    [SerializeField] GameObject pa;
    


    public Texture2D image;
    public int blocksPerLine = 4;
    public int shuffleLength = 20;
    public float defaultMoveDuration=.2f;
    public float shuffleMoveDuration=.1f;
    public bool done=false;
    enum PuzzleState{Solved,Shuffling,Inplay};
    PuzzleState state;
    bool isShuffled = false;


    Block[,] blocks;
    Queue<Block> inputs;
    Block emptyBlock;
    bool blockIsMoving;
    int shuffleMovesRemaining;
    Vector2Int previousShuffleoffset;

    void Start()
    {
        CreatePuzzle();
    }
    void Update()
    {
        if(state==PuzzleState.Solved && !isShuffled)
        {
            StartShuffle();
        }

        if(done)
        {
            SwitchToApp temp = app.GetComponent<SwitchToApp>();
            temp.appCleaned = true;
            StartCoroutine(effect(0f, 0f));
        }
    }
    void CreatePuzzle()
    {
        blocks = new Block[blocksPerLine,blocksPerLine];
        Texture2D[,] imageSlices=ImageSlicer.GetSlices(image,blocksPerLine);
        for (int y = 0; y < blocksPerLine; y++)
        {
            for (int x = 0; x < blocksPerLine; x++)
            {
                GameObject blockObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
                blockObject.transform.position = -Vector2.one * (blocksPerLine - 1) * .5f + new Vector2(x, y+22);
                blockObject.transform.parent = transform;

                Block block = blockObject.AddComponent<Block>();
                block.OnBlockPressed += PlayerMoveBlockInput;
                block.OnFinsihed+=OnBlockFinishedMoving;
                block.Init(new Vector2Int(x,y),imageSlices[x,y]);
                blocks[x,y] = block;

                if (y == 0 && x == blocksPerLine - 1)
                {
                    emptyBlock = block;
                }
            }
        }

        inputs= new Queue<Block>();
    }

    void PlayerMoveBlockInput(Block blockToMove)
    {
        if(state==PuzzleState.Inplay)
        {
        inputs.Enqueue(blockToMove);
        MakeNextPlayerMove();
        }
    }
    void MakeNextPlayerMove()
    {
        while(inputs.Count>0&&!blockIsMoving)
        {
            MoveBlock(inputs.Dequeue(),defaultMoveDuration);
        }
    }
    void MoveBlock(Block blockToMove,float duration)
    {
        if ((blockToMove.coord - emptyBlock.coord).sqrMagnitude == 1)
        {
            blocks[blockToMove.coord.x,blockToMove.coord.y]=emptyBlock;
            blocks[emptyBlock.coord.x,emptyBlock.coord.y]=blockToMove;
            Vector2Int targetCoord = emptyBlock.coord;
            emptyBlock.coord = blockToMove.coord;
            blockToMove.coord = targetCoord;

            Vector2 targetPosition = emptyBlock.transform.position;
            emptyBlock.transform.position = blockToMove.transform.position;
            blockToMove.MoveToPosition(targetPosition,duration);
            blockIsMoving=true;
        }
    }
    void OnBlockFinishedMoving()
    {
        blockIsMoving=false;
        CheckIfSolved();
        if(state==PuzzleState.Inplay)
        {
            MakeNextPlayerMove();
        }
        if(shuffleMovesRemaining>0)
        {
            MakeNextShuffleMove();
        }
        else
        {
            state=PuzzleState.Inplay;
        }
    }
    void StartShuffle()
    {
        isShuffled =true;
        state=PuzzleState.Shuffling;
        shuffleMovesRemaining=shuffleLength;
        emptyBlock.gameObject.SetActive(false);
        MakeNextShuffleMove();
    }
    void MakeNextShuffleMove()
    {
        Vector2Int[] offsets={new Vector2Int(1,0),new Vector2Int(-1,0),new Vector2Int(0,1),new Vector2Int(0,-1)};
        int randomIndex=Random.Range(0,offsets.Length);
        for(int i=0;i<offsets.Length;i++)
        {
            Vector2Int offset= offsets[(randomIndex+i) % offsets.Length];
            if(offset!=previousShuffleoffset*-1)
            {
                Vector2Int moveBlockCoord = emptyBlock.coord + offset;
                if(moveBlockCoord.x>=0&& moveBlockCoord.x<blocksPerLine && moveBlockCoord.y>=0&& moveBlockCoord.y < blocksPerLine)
                {
                    MoveBlock(blocks[moveBlockCoord.x,moveBlockCoord.y],shuffleMoveDuration);
                    shuffleMovesRemaining--;
                    previousShuffleoffset=offset;
                    break;
                }
            }
        }
        
    }
    void CheckIfSolved()
     {
         foreach(Block block in blocks)
         {
             if(!block.IsAtStartingCoord())
             {
                 return;
             }
         }
         state = PuzzleState.Solved;
         emptyBlock.gameObject.SetActive(true);
         if(state==PuzzleState.Solved)
         {
             done=true;
             
         }
     }
    public IEnumerator effect(float dx, float dy)
    {
        camref.transform.DOMove(new Vector3(dx, dy, camref.transform.position.z), 0.5f, false);
        pa.SetActive(false);
        yield return null;
    }

}

