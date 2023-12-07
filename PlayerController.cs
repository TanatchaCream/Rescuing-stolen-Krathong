using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public DoorController door;
    public DoorController1 door1;
    public DoorController2 door2;
    public float eyeDistance = 5.0f;
    private Ray ray;
    private RaycastHit hitData;
    public Text msg;
    public int itemCount = 0;
    public GameObject itemToDropPrefab;
    public Text itemCountText;
    public GameObject endGameCanvas;
    public AudioSource DoorOpenSound;
    public AudioSource PickUp;
    public Image WinMenu;

    void Start()
    {
        msg.gameObject.SetActive(false);
        UpdateItemCountText();
        WinMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //ray.origin = transform.position;
        //ray.direction = transform.forward;

        Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);

        if (Physics.Raycast(ray, out hitData, eyeDistance))
        {
            switch (hitData.transform.gameObject.tag)
            {
                case "doors":
                    msg.text = "Press Q to Open/Close";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        door.control();
                        DoorOpenSound.Play();
                    }
                    break;

                case "door1":
                    msg.text = "Press Q to Open/Close";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        door1.control1();
                        DoorOpenSound.Play();
                    }
                    break;

                case "door2":
                    msg.text = "Press Q to Open/Close";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        door2.control2();
                        DoorOpenSound.Play();
                    }
                    break;

                case "Monster":
                    msg.text = "Kill it left mouse";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.yellow);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Destroy(hitData.transform.gameObject);
                        DropItem(hitData.transform.position);
                    }
                    break;

                case "Item":
                    msg.text = "Press E to pick up";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitData.transform.gameObject);
                        itemCount++;
                        UpdateItemCountText();
                        PickUp.Play();

                        if (itemCount <= 5)
                        {
                            msg.text = itemCount + "/5Item";
                        }


                    }
                    break;

                default:
                    msg.gameObject.SetActive(false);
                    break;
            }
        }
        else
        {
            msg.gameObject.SetActive(false);
        }



        if (itemCount == 5)
        {
            GameWin();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void DropItem(Vector3 position)
    {
        if (itemToDropPrefab != null)
        {
            Instantiate(itemToDropPrefab, position, Quaternion.identity);
        }
    }

    void UpdateItemCountText()
    {
        itemCountText.text = "Item Count: " + itemCount;
    }

    public void GameWin()
    {
        WinMenu.gameObject.SetActive(true);
    }
}
