using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samplecode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�z��^�ϐ��̐錾
        //�v�f�^[] �ϐ���;
        //int[] iAry = new int[]{ 10,20,30};//int �^ 3 �v�f�̔z��𐶐�
        var iAry = new[] { 10, 20, 30 };

        Debug.Log($"iAry�z��̒�����{iAry.Length}");

        for(var i = 0; i < iAry.Length; i++)
        {
            Debug.Log($"iAry[{i}]={iAry[i]}");
        }

        foreach(var e in iAry)
        {
            Debug.Log($"e={e}");
        }
        //�z��v�f�ւ̃A�N�Z�X
        //iAry[0] = 10;
        //iAry[1] = 20;
        //iAry[2] = 30;
    }

    //void kiso()
    //{
    //�ϐ��^ �ϐ��� = �����l;
    //int i = 100;//�����^�̕ϐ�

    //string str = "������";

    //str = "Start";//�ϐ��͏㏑���\�A�^���قȂ�l�͑���s��

    //�ϐ��^���ÖٓI�ɐ��_���Ă���� var ���֗�
    //var v = 1234;//�����l����^�𐄘_����
    // var v;�@�G���[�A�������͏ȗ��ł��Ȃ�

    //�ϐ��^ �ϐ��� = �����l;
    //int i = 100;//�����^�̕ϐ�

    //�{���Z�q�ɖ镶���񌋍�
    //Debug.Log("i=" + i);

    //(��$�}�[�N������������i�������ԁj)
    //Debug.Log($"i={i}");//https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/tokens/interpolated

    //��̕������ԁA���̂�string.Format()�Ɠ��`
    //Debug.Log(string.Format("i={0}", i));
    //}
}
