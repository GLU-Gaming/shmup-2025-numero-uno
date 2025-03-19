using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody rb;
    public float playerHealth = 10;
    [SerializeField] TMP_Text PlayerHealthTXT;
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerHealthTXT.text = "HP:" + playerHealth;
        if (playerHealth < 1)
        {
            Player.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            playerHealth -= 1;
        }
    }
}
