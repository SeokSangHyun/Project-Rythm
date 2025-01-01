using UnityEngine;

public static class StaticVariable
{
    //----------------------------------------------------------------------------------------------------
    // 비트를 누적하는 변수
    //----------------------------------------------------------------------------------------------------
    public static int iBeatAccCount = 0;
    public static void BeatCounting()
    {
        iBeatAccCount += 1;
    }




    //----------------------------------------------------------------------------------------------------
    // 생성한 노드를 누적하는 변수
    //----------------------------------------------------------------------------------------------------
    public static int iNodeCount = 0;
    public static void NodeCounting()
    {
        iNodeCount += 1;
    }
}
