using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    public float playerHealth = 10;
    [SerializeField] TMP_Text PlayerHealthTXT;
    [SerializeField] TMP_Text HighscoreTXT;
    [SerializeField] TMP_Text OLDHighscoreTXT;
    public Transform bulletspawn;
    public GameObject bulletobj;
    public bool canshoot = true;
    public float shootTimer = 0;
    public float Highscore = 0;
    public float OLDHighscore = 0;

    private void Start()
    {
        PlayerHealthTXT.text = "HP:" + playerHealth;
        HighscoreTXT.text = "Score:" + " " + Highscore;
        OLDHighscore = PlayerPrefs.GetFloat("Highscore");
    }

    private void Update()
    {
      
        SaveData();

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


        HighscoreTXT.text = "Score:" + " " + Highscore;
        OLDHighscoreTXT.text = "HighScore:" + " " + OLDHighscore;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            playerHealth -= 1;
            PlayerHealthTXT.text = "HP:" + playerHealth;
        }
    }


    public void Kill()
    {
        Highscore += 100;
    }    

    public void SaveData()
    {
        if (Highscore > OLDHighscore)
        {
            OLDHighscore = Highscore;
            PlayerPrefs.SetFloat("Highscore", Highscore);
        }
    }

}
