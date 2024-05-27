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
        if (Input.GetMouseButtonDown(0)) //проверка на клик мыши
        {//выводит сообщение о проклике мыши
            print("был сделан клик мышью");
            //считывает положение мыши
            mousePos = Input.mousePosition;
            //выводит позиццю мыши на консоль
            print("экранные координаты" + mousePos);
            // преобразование координат экрана в координаты в игровом мире
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            //выводим координаты игрового мира в  консоль
            print("координаты игрового мира" + mousePosWorld);
            //преобразование вектора3д в вектора2   д
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

            // raycast2D
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);

            //произошло ли попадание по коллайдеру
            if(hit.collider != null)
            {
                print("произошло попадание по коллайдеру");
                //выводит название объекта по которому прозошел кллик
                print("название:" + hit.collider.gameObject.tag);

                //является ли место куда кликнули Grouns
                if(hit.collider.gameObject.tag == "Ground")
                {

                    //меняет расположение игрока
                    //player.transform.position = hit.point;
                    targetPos = hit.point;
                    //isMoving для движения игроков
                    isMoving = true;
                    //проверка на необходимость поворота моделики персонажа
                    CheckSpriteFlip();
                }
                else if(hit.collider.gameObject.tag == "Key")
                {
                    //если этто ключ
                    // отключение модельки
                    hit.collider.gameObject.SetActive(false);
                    //сохранить ключ в скриптте
                    key = true;
                    //количество камней увеличивается на 1
                    stones = stones + 1;
                }
                //этот коллайдер дверь?
                else if(hit.collider.gameObject.tag == "Door")
                {
                    //открыть дверь
                    if(stones >= 2)
                    {
                        //запустить следующий уровень
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                    }


                }
            }

            else
            {
                print("не было попадания по коллайдеру");
            }
        }
    }


    private void FixedUpdate()
    {
        //провеерка на движение игрока
        if(isMoving)
        {
            // перемещение игрока в пункт назначения
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed);
            print("игрок перемещается");

            //прибылл ли игрок в пункт назначения
            if (player.transform.position.x == targetPos.x && player.transform.position.y == targetPos.y)
            {
                //игрок в пункте назначения отключает перемещение 
                isMoving = false;
                print("игрок в пункте назначения");
            }
        }

    }
    void CheckSpriteFlip()
    {
        if(player.transform.position.x > targetPos.x)
        {
            //смотрит вправо
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            //смотрит влево
            player.GetComponent<SpriteRenderer>().flipX = true;

        }
    }
}
