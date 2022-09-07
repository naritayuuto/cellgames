using UnityEngine;
using UnityEngine.UI;

public class kadai : MonoBehaviour
{
    [SerializeField,Header("sell�̌�")] int sellcount = 0;//sells�̗v�f�̐�
    [SerializeField,Header("�I�𒆂�sell")] int sellselect = 0;//�I�𒆂�sell
    GameObject[] sells;
    private void Start()
    {
        sells = new GameObject[sellcount];
        for (var i = 0; i < sells.Length; i++)
        {
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;

            sells[i] = obj;

            var image = obj.AddComponent<Image>();
            if (sellselect == i) { image.color = Color.red; }
            else { image.color = Color.white; }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // ���L�[��������
        {
            if (sells[sellselect])//��sell��I�����Ă�����
            {
                sells[sellselect].GetComponent<Image>().color = Color.white; //���I�����Ă���sell�𔒂�
            }
            for (int i = 0; i < sells.Length; i++)//for�����񂷗��R�A������sell�ɃA�N�Z�X���Ȃ��悤�ɂ��邽��
            {
                if (sellselect == 0)//���[�܂ŗ�����
                {
                    sellselect = sells.Length;
                }
                sellselect--;//�ړ����邽�߂�
                if (sells[sellselect])//�ړ����sell����������
                {
                    sells[sellselect].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // �E�L�[��������
        {
            if (sells[sellselect])
            {
                sells[sellselect].GetComponent<Image>().color = Color.white;
            }
            for (int i = 0; i < sells.Length; i++)//�������z��̗v�f�̕����ɐڑ����Ă��܂����Ƃ��ɂ��̗v�f���΂����߂�for��
            {
                if (sellselect == sells.Length - 1)
                {
                    sellselect = -1;
                }
                sellselect++;
                if (sells[sellselect])
                {
                    sells[sellselect].GetComponent<Image>().color = Color.red;
                    break;
                }
            }
        }
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //   Destroy(sells[sellselect].gameObject);
        //}
        if (Input.GetButtonUp("Jump"))
        {
            Destroy(sells[sellselect].gameObject);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (var sell in sells)
            {
                Debug.Log(sell);
            }

            Debug.Log($"sellselect = {sellselect}");
        }
    }
}