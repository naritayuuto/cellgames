using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nizigen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�񎟌��z��̏�����
        //new[,] {{�v�f�P,�v�f�Q},{�v�f�R,�v�f�S},...};
                          //�c�A��
        int[,] iAry = new int[5,3]
            {
                {0,1,2 },
                {10,11,12 },
                {20,21,22 },
                {30,31,32 },
                {40,41,42 }
            };

        //�z��̎������擾����
        Debug.Log($"�z��̎����� = {iAry.Rank}");

        //Length�͔z��S�̗̂v�f���i5*3 �܂�15�j��Ԃ�
        Debug.Log($"Length = {iAry.Length}");

        //�e�������Ƃ̗v�f����GetLength()���\�b�h����擾�o����
        Debug.Log($"�P������ = {iAry.GetLength(0)}");
        Debug.Log($"2������ = {iAry.GetLength(1)}");

        //�ʏ�̔z���1���ǉ�������
        //�v�f����ׂ邾���Ƃ����_�͒ʏ�̔z��Ɠ���
        //�f�[�^�A�N�Z�X�Ɋe�����̃C���f�b�N�X��ǉ��ł���.


        for (var i = 0; i < 5; i++)
        {
            for(int k = 0; k < 3; k++)
            {
                Debug.Log($"{i},{k} = {iAry[i, k]}");
            }
        }
        //foreach���g�����Ƃ��o����
        foreach(var e in iAry)
        {
            Debug.Log($"e={e}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
