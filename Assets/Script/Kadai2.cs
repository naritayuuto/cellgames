using UnityEngine;
using UnityEngine.UI;

public class Kadai2 : MonoBehaviour
{
    GameObject[,] cells;
    [SerializeField] int tate = 0;
    [SerializeField] int yoko = 0;
    int selecttate = 0;
    int selectyoko = 0;
    private void Start()
    {
        cells = new GameObject[tate, yoko];
        for (var r = 0; r < tate; r++)
        {
            for (var c = 0; c < yoko; c++)
            {
                var obj = new GameObject($"Cell({r}, {c})");
                obj.transform.parent = transform;
                cells[r,c] = obj;
                
                var image = obj.AddComponent<Image>();
                if (r == selecttate && c == selectyoko) { image.color = Color.red; }
                else { image.color = Color.white; }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // ���L�[��������
        {
            if (cells[selecttate, selectyoko])//��sell��I�����Ă�����
            {
                cells[selecttate, selectyoko].GetComponent<Image>().color = Color.white; //���I�����Ă���sell�𔒂�
            }
            for (int i = 0; i < yoko; i++)//for�����񂷗��R�A������sell�ɃA�N�Z�X���Ȃ��悤�ɂ��邽��
            {
                if (selectyoko == 0)//�[�܂ŗ�����
                {
                    selectyoko = yoko;
                }
                selectyoko--;//�ړ����邽�߂�
                if (cells[selecttate, selectyoko].GetComponent<Image>().enabled == true)//�ړ����sell����������
                {
                    cells[selecttate, selectyoko].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // �E�L�[��������
        {
            if (cells[selecttate, selectyoko])//��sell��I�����Ă�����
            {
                cells[selecttate, selectyoko].GetComponent<Image>().color = Color.white; //���I�����Ă���sell�𔒂�
            }
            for (int i = 0; i < yoko; i++)//for�����񂷗��R�A������sell�ɃA�N�Z�X���Ȃ��悤�ɂ��邽��
            {
                if (selectyoko == yoko-1)//�[�܂ŗ�����
                {
                    selectyoko = -1;
                }
                selectyoko++;//�ړ����邽�߂�
                if (cells[selecttate, selectyoko].GetComponent<Image>().enabled == true)//�ړ����sell����������
                {
                    cells[selecttate, selectyoko].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) // ��L�[��������
        {
            if (cells[selecttate, selectyoko])//��sell��I�����Ă�����
            {
                cells[selecttate, selectyoko].GetComponent<Image>().color = Color.white; //���I�����Ă���sell�𔒂�
            }
            for (int i = 0; i < tate; i++)//for�����񂷗��R�A������sell�ɃA�N�Z�X���Ȃ��悤�ɂ��邽��
            {
                if (selecttate == 0)//�[�܂ŗ�����
                {
                    selecttate = tate;
                }
                selecttate--;//�ړ����邽�߂�
                if (cells[selecttate, selectyoko].GetComponent<Image>().enabled == true)//�ړ����sell����������
                {
                    cells[selecttate, selectyoko].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) // ���L�[��������
        {
            if (cells[selecttate, selectyoko])//��sell��I�����Ă�����
            {
                cells[selecttate, selectyoko].GetComponent<Image>().color = Color.white; //���I�����Ă���sell�𔒂�
            }
            for (int i = 0; i < tate; i++)//for�����񂷗��R�A������sell�ɃA�N�Z�X���Ȃ��悤�ɂ��邽��
            {
                if (selecttate == tate-1)//�[�܂ŗ�����
                {
                    selecttate = -1;
                }
                selecttate++;//�ړ����邽�߂�
                if (cells[selecttate, selectyoko].GetComponent<Image>().enabled == true)//�ړ����sell����������
                {
                    cells[selecttate, selectyoko].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            cells[selecttate, selectyoko].GetComponent<Image>().enabled = false;
        }
    }
}