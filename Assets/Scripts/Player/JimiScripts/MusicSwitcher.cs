using UnityEngine;

public class MusicSwitcher : MonoBehaviour


{
        public float timer = 0;
    [SerializeField] GameObject normal;
    [SerializeField] GameObject boss;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;


        if (timer > 60)
        {
            boss.SetActive(true);
            normal.SetActive(false);
        }
    }
}
