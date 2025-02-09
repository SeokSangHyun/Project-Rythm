using System;
using System.Linq;
using UnityEngine;

public class BeatDataClass
{
    bool[][] m_arrNode        { get; set; }

    //------------------------------------------------------------------------------------------------
    // 비트에 출력될 노드 배치 함수
    //------------------------------------------------------------------------------------------------

    // 피셔 예이츠 셔플 알고리즘을 통해 섞기
    void ShuffleArray(bool[] arr)
    {
        System.Random rand = new System.Random();
        int n = arr.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1); // 0부터 i 사이의 무작위 인덱스 선택
            (arr[i], arr[j]) = (arr[j], arr[i]); // Swap (C# 튜플 사용)
        }
    }
    
    public void InitializeBeatSetting()
    {
        GameObject objGameManager = GameObject.Find("GameManager");
        var listMyWeapon = objGameManager.GetComponent<WeaponManager>().GetMyWeaponList();
        
        // 1. 일단 WeaponObjectClass에서 무기, 노드 정보를 모두(list) 얻어옴
        // 2. 비트의 전체 크기를 구해야함
        //      ㄴ 전체 길이 = [무기 비트 총합] * D[난이도 계수] -> (1 비트 + 비트 사이 나누는 수(2))의 배수
        //          ㄴ 무기 비트 중에 중간이 비어 있는게 있을 경우? (o|oo , o|o|o ...)
        //          ㄴ 무기 비트 총합을 구할 때 비어 있는 것과 실제 있는 것을 구별
        //          ㄴ 비트 타입으로 모양을 구별함 -> 실질 모양은 알아서 구별해야함 -> 타입에 따라서 알아서 반환해주는 함수 추가 필요
        //      ㄴ 빈 비트의 수 = [전체 길이 - [무기 비트 총합]----------------------------------------
        // 착용중인 무기 가져오기
        //      ㄴ 비트를 모은 리스트
        // 3. 배치되는 노드의 알고리즘
        //      ㄴ 비트 일지 . 빈 비트 일지 확률 검사 -> 전체 비트 배열 채우기
        //      ㄴ 비트와 빈 비트에 남은 수가 없으면 배열 끝
        //      ㄴ 어떤 영역에 노드를 배치할 것인지 확인 필요
        //
        // 난이도가 필요함 = 난이도는 몬스터가 가지고 있고 비트가 많을수록 난이도가 올라감
        // 따라서 난이도에 따라서 빈 노드의 수가 적어짐
        //

        //listMyWeapon;--------------------------------------
        
        int total_length = 0;
        int full_cnt = 0;
        int empty_cnt = 0;

        var keys = listMyWeapon.Keys.ToList();
        var values = listMyWeapon.Values.ToList();
        
        for(int i = 0; i < listMyWeapon.Count; ++i)
        {
            var wNodeinfo = values[i];
            var node_cnt = wNodeinfo.GetNodeBeatPropertyCounts();
            
            // 무기의 노드에 따라서 1) 입력 있는 비트 , 2) 비어있는 비트의 갯수를구한다.
            full_cnt += node_cnt.Item1;
            empty_cnt += node_cnt.Item2;
        }
        
        //게임에서 사용하는 전체 노드의 길이를 구하자
        // ㄴ 상수는 추후 (난이도 계수) 값으로 대체 되어야 함
        total_length = (full_cnt + empty_cnt) * (1 + SystemManager.Instance.GetDifficulty());

        
        
        //----- 총 비트 수 계산을 끝 -----
        //노드 배치 분배 작업 CheckAreaPanel
        
        GameObject canvas = GameObject.Find("MainCanvas");
        Transform checkarea = canvas.transform.Find("CheckAreaPanel");
        int cnt_displayarea = 0;
        
        for (int i = 0; i < checkarea.childCount; ++i)
        {
            if (checkarea.GetChild(i).gameObject.activeSelf)
            {
                cnt_displayarea++;
            }
        }
        
        // arr[노드 출력 영역 갯수][전체 비트 수 / 노드 출력 영역 갯수] 의 배열 생성하여 노드 분배 
        
        // 변수 초기화
        m_arrNode = new bool[cnt_displayarea][];
        int OneLineBeatCount = (int)Math.Ceiling( (double)total_length/(double)cnt_displayarea );

        for (int i = 0; i < cnt_displayarea; ++i)
        {
            // 배열 초기화
            m_arrNode[i] = new bool[OneLineBeatCount];

            for (int j = 0; j < OneLineBeatCount; ++j)
            {
                m_arrNode[i][j] = true;    // 배열의값 채우기
            }
            
            // 비트에 초기화
            ShuffleArray(m_arrNode[i]);
        }
        
        // 이 때 노드 나오도록 업데이트
        SystemManager.Instance.SetIsGamePlay(true);
    }
    
    
    //비트 세팅 함수
    void InvokeBeat()
    {
        //m_arrNode에 있는 정보를 비트에 맞게 출력하면됨
    }
}
