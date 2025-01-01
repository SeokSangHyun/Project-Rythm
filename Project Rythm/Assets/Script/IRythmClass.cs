using UnityEngine;


//--------------------------------------------------
// ����� ���뿡 ���� Interface Class
//--------------------------------------------------
public interface IRythmClass
{
    //��� �� ����
    NodeType nodeType { get; }
    int StartBeat { get; }          // ��Ʈ ���� ����
    int BeatTimming { get; }        // ��Ʈ ������ Ÿ�̹� (ex. 1�̸� �� ��Ʈ���� ���)
    int BeatCoolTime { get; }       // ��尡 ������ ���� ��ٸ��� �ð�

    int RailIndex { get; }          // ��尡 ���Ͽ� ������ ��ġ (0�̸� ��� Rail���� ����)

    void Beat(int beatCount);       //��Ʈ üũ
}
