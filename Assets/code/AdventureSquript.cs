using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdventureSquript : MonoBehaviour
{
    public Vector3 mousePos;
    public Camera mainCamera;
    public Vector3 mousePosWorld;
    public Vector2 mousePosWorld2D;
    RaycastHit2D hit;
    public GameObject player;
    public Vector2 targetPos;
    public float speed;
    public bool isMoving;

    public bool key =false;
    public int stones = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //�������� �� ���� ����
        {//������� ��������� � �������� ����
            print("��� ������ ���� �����");
            //��������� ��������� ����
            mousePos = Input.mousePosition;
            //������� ������� ���� �� �������
            print("�������� ����������" + mousePos);
            // �������������� ��������� ������ � ���������� � ������� ����
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            //������� ���������� �������� ���� �  �������
            print("���������� �������� ����" + mousePosWorld);
            //�������������� �������3� � �������2   �
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

            // raycast2D
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);

            //��������� �� ��������� �� ����������
            if(hit.collider != null)
            {
                print("��������� ��������� �� ����������");
                //������� �������� ������� �� �������� �������� �����
                print("��������:" + hit.collider.gameObject.tag);

                //�������� �� ����� ���� �������� Grouns
                if(hit.collider.gameObject.tag == "Ground")
                {

                    //������ ������������ ������
                    //player.transform.position = hit.point;
                    targetPos = hit.point;
                    //isMoving ��� �������� �������
                    isMoving = true;
                    //�������� �� ������������� �������� �������� ���������
                    CheckSpriteFlip();
                }
                else if(hit.collider.gameObject.tag == "Key")
                {
                    //���� ���� ����
                    // ���������� ��������
                    hit.collider.gameObject.SetActive(false);
                    //��������� ���� � ��������
                    key = true;
                    //���������� ������ ������������� �� 1
                    stones = stones + 1;
                }
                //���� ��������� �����?
                else if(hit.collider.gameObject.tag == "Door")
                {
                    //������� �����
                    if(stones >= 2)
                    {
                        //��������� ��������� �������
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                    }


                }
            }

            else
            {
                print("�� ���� ��������� �� ����������");
            }
        }
    }


    private void FixedUpdate()
    {
        //��������� �� �������� ������
        if(isMoving)
        {
            // ����������� ������ � ����� ����������
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed);
            print("����� ������������");

            //������� �� ����� � ����� ����������
            if (player.transform.position.x == targetPos.x && player.transform.position.y == targetPos.y)
            {
                //����� � ������ ���������� ��������� ����������� 
                isMoving = false;
                print("����� � ������ ����������");
            }
        }

    }
    void CheckSpriteFlip()
    {
        if(player.transform.position.x > targetPos.x)
        {
            //������� ������
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            //������� �����
            player.GetComponent<SpriteRenderer>().flipX = true;

        }
    }
}
