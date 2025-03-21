using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    public float playerHealth = 10;
    [SerializeField] TMP_Text PlayerHealthTXT;
    public Transform bulletspawn;
    public GameObject bulletobj;
    public bool canshoot = true;
    public float shootTimer = 0;

    private void Start()
    {

    }

    private void Update()
    {
      

        Debug.Log(playerHealth);
        if (playerHealth < 1)
        {
            Destroy(gameObject);
        }

        if (shootTimer > 0.2)
        {
            canshoot = true;
            shootTimer = 0;
        }


        if (canshoot == true)
        if (Input.GetKey(KeyCode.Z))
        {

            GameObject bullet = Instantiate(bulletobj, bulletspawn.position, bulletspawn.rotation);
                canshoot = false;
        }

        if (canshoot == false)
        {
            shootTimer += Time.deltaTime;
        }




    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            playerHealth -= 1;
            PlayerHealthTXT.text = "HP:" + playerHealth;
        }
    }


}
