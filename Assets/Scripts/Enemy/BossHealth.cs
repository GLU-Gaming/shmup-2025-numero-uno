using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] RectTransform canvas;

    [SerializeField] Image bar;

    private BossGeneral bossGeneral;

    void Start()
    {
        bossGeneral = boss.GetComponent<BossGeneral>();
    }

    void Update()
    {
        if (boss.activeSelf)
        {
            Vector2 viewportPosition = Camera.main.WorldToViewportPoint(boss.transform.position);
            Vector2 finalPosition = new Vector2(viewportPosition.x * canvas.sizeDelta.x, viewportPosition.y * canvas.sizeDelta.y);
            bar.transform.position = finalPosition * ((float)Screen.height / 1080);
        } else
        {
            Vector2 viewportPosition = Camera.main.WorldToViewportPoint(new Vector3(-100, 0, 0));
            Vector2 finalPosition = new Vector2(viewportPosition.x * canvas.sizeDelta.x, viewportPosition.y * canvas.sizeDelta.y);
            bar.transform.position = finalPosition * ((float)Screen.height / 1080);
        }

        bar.fillAmount = (float)bossGeneral.health / bossGeneral.maxHealth;
    }
}
