using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    public float playerHealth = 5;
    [SerializeField] TMP_Text PlayerHealthTXT;
    [SerializeField] TMP_Text HighscoreTXT;
    [SerializeField] TMP_Text OLDHighscoreTXT;
    [SerializeField] private GameObject bulletManagerHolder;
    private BatchManager bulletManager;
    public bool canshoot = true;
    public float shootTimer = 0;
    public int Highscore = 0;
    public int OLDHighscore = 0;

    [SerializeField] Vector3 spawnPos;

    private void Start()
    {
        PlayerHealthTXT.text = "HP:" + playerHealth;
        HighscoreTXT.text = "Score:" + " " + Highscore + "00";
        OLDHighscore = PlayerPrefs.GetInt("Highscore");
        OLDHighscoreTXT.text = "HighScore:" + " " + OLDHighscore + "00";

        bulletManager = bulletManagerHolder.GetComponent<BatchManager>();
    }

    private void Update()
    {
        if (shootTimer > 0.2)
        {
            canshoot = true;
            shootTimer = 0;
        }


        if (canshoot == true)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                bulletManager.Activate(transform.position, transform.rotation);
                canshoot = false;
            }
        }

        if (canshoot == false)
        {
            shootTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyProjectile"))
        {
            OnHit();

            if (other.gameObject.CompareTag("EnemyProjectile"))
            {
                other.gameObject.GetComponent<BatchChild>().Deactivate();
            }
        }
    }

    public void OnHit()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }

        playerHealth -= 1;
        PlayerHealthTXT.text = "HP:" + playerHealth;

        transform.position = spawnPos;
        // TODO: IFrames
    }

    public void Kill()
    {
        Highscore += 1;

        SaveData();

        HighscoreTXT.text = "Score:" + " " + Highscore + "00";
        OLDHighscoreTXT.text = "HighScore:" + " " + OLDHighscore + "00";
    }    

    public void SaveData()
    {
        if (Highscore > OLDHighscore)
        {
            OLDHighscore = Highscore;
            PlayerPrefs.SetInt("Highscore", Highscore);
        }
    }

}
