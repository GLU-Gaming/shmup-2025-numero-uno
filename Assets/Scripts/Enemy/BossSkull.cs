using System.Collections.Generic;
using UnityEngine;

public class BossSkull : MonoBehaviour
{
    [SerializeField] private Material blackMaterial;
    [SerializeField] private Material whiteMaterial;

    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    private Camera mainCamera;
    private Color originalBackgroundColor;

    [SerializeField] float normalTime;
    [SerializeField] float invincableTime;

    [SerializeField] BossGeneral bossGeneral;

    private float phaseTimer;

    private bool altNormal;

    [SerializeField] float speedFactor;
    [SerializeField] float constantSpeed;

    private Vector3 targetPos;

    [SerializeField] GameObject lazerManagerHolder;
    [SerializeField] GameObject bulletManagerHolder;
    [SerializeField] GameObject aimerManagerHolder;
    [SerializeField] GameObject spikeEnemyManagerHolder;

    private BatchManager lazerManager;
    private BatchManager bulletManager;
    private BatchManager aimerManager;
    private BatchManager spikeEnemyManager;

    private GameObject lazer1 = null;
    private GameObject lazer2 = null;

    [SerializeField] float tornadoAngleIncrement;
    private float tornadoAngle;

    [SerializeField] float bulletSpeed;

    private float lastTornadoSpawnTime = 0f;

    [SerializeField] float fixedDeltaTime;

    [SerializeField] float normalShootRate;
    [SerializeField] float altShootRate;
    [SerializeField] float altEnemyRate;

    [SerializeField] Transform player;

    private float shootTimer1;
    private float shootTimer2;

    [SerializeField] float normalShootAngle;
    [SerializeField] float altShootAngle;
    [SerializeField] int normalShootCount;
    [SerializeField] int altShootCount;

    [SerializeField] float lazerEnd;
    [SerializeField] float lazerStart;

    private void Start()
    {
        lazerManager = lazerManagerHolder.GetComponent<BatchManager>();
        bulletManager = bulletManagerHolder.GetComponent<BatchManager>();
        aimerManager = aimerManagerHolder.GetComponent<BatchManager>();
        spikeEnemyManager = spikeEnemyManagerHolder.GetComponent<BatchManager>();

        mainCamera = Camera.main;
        if (mainCamera != null)
        {
            originalBackgroundColor = mainCamera.backgroundColor;
        }
    }

    private void OnEnable()
    {
        phaseTimer = normalTime;
        altNormal = false;
        bossGeneral.invincible = false;

        transform.position = new Vector3(17f, 0f, 0f);
        targetPos = new Vector3(8.5f, 0f, 0f);
    }

    private void OnDisable()
    {
        if (bossGeneral.invincible)
        {
            ChangePhase();
        }
    }
    public float positionOffset;
    private void FixedUpdate()
    {
        phaseTimer -= Time.deltaTime;

        if (phaseTimer <= 0)
        {
            ChangePhase();
        }

        if (bossGeneral.invincible)
        {
            targetPos = new Vector3(8.5f, 0f, 0f);

            tornadoAngle += tornadoAngleIncrement;

            float timeSinceLast = Time.realtimeSinceStartup - lastTornadoSpawnTime;
            positionOffset = bulletSpeed * (timeSinceLast - fixedDeltaTime);

            bulletManager.Activate(transform.position + Quaternion.Euler(0, 0, tornadoAngle) * new Vector3(positionOffset, 0, 0), 
                Quaternion.Euler(0, 0, tornadoAngle), bulletSpeed);

            bulletManager.Activate(transform.position + Quaternion.Euler(0, 0, tornadoAngle + 90) * new Vector3(positionOffset, 0, 0), 
                Quaternion.Euler(0, 0, tornadoAngle + 90), bulletSpeed);

            bulletManager.Activate(transform.position + Quaternion.Euler(0, 0, tornadoAngle + 180) * new Vector3(positionOffset, 0, 0), 
                Quaternion.Euler(0, 0, tornadoAngle + 180), bulletSpeed);

            bulletManager.Activate(transform.position + Quaternion.Euler(0, 0, tornadoAngle + 270) * new Vector3(positionOffset, 0, 0), 
                Quaternion.Euler(0, 0, tornadoAngle + 270), bulletSpeed);

            lastTornadoSpawnTime = Time.realtimeSinceStartup;

            // move lazers
            lazer1.transform.position = new Vector3(0, Mathf.Lerp(lazerEnd, lazerStart, phaseTimer/invincableTime), 0);
            lazer2.transform.position = new Vector3(0, -Mathf.Lerp(lazerEnd, lazerStart, phaseTimer/invincableTime), 0);
        } else
        {
            if (altNormal)
            {
                shootTimer1 += Time.deltaTime;

                if (shootTimer1 > altShootRate)
                {
                    shootTimer1 -= altShootRate;

                    for (int i = 0; i < altShootCount; i++)
                    {
                        float angle = Mathf.Lerp(180 - altShootAngle / 2, 180 + altShootAngle / 2, (float)i / (altShootCount - 1));

                        aimerManager.Activate(transform.position, Quaternion.Euler(0, 0, angle));
                    }

                    targetPos = new Vector3(8.5f, player.position.y, 0);
                }

                shootTimer2 += Time.deltaTime;

                if (shootTimer2 > altEnemyRate)
                {
                    shootTimer2 -= altEnemyRate;

                    for (int i = -8; i < 9; i += 2)
                    {
                        spikeEnemyManager.Activate(new Vector3(16.5f, i, 0), Quaternion.Euler(Vector3.zero));
                    }
                }
            } else
            {
                shootTimer1 += Time.deltaTime;

                if (shootTimer1 > normalShootRate)
                {
                    shootTimer1 -= normalShootRate;

                    for (int i = 0; i < normalShootCount; i++)
                    {
                        float angle = Mathf.Lerp(180 - normalShootAngle/2, 180 + normalShootAngle/2, (float)i /(normalShootCount-1));

                        bulletManager.Activate(transform.position, Quaternion.Euler(0, 0, angle));
                        aimerManager.Activate(transform.position, Quaternion.Euler(0, 0, angle));
                    }

                    targetPos = new Vector3(8.5f, player.position.y, 0);
                }
            }
        }

        transform.position += (targetPos - transform.position) * Time.deltaTime * speedFactor + constantSpeed * Time.deltaTime * targetPos;
    }

    private void InvincibleStart()
    {
        lazer1 = lazerManager.Activate();
        lazer2 = lazerManager.Activate();

        tornadoAngle = 0;
        lastTornadoSpawnTime = Time.time;
    }

    private void ChangePhase()
    {
        bossGeneral.invincible = !bossGeneral.invincible;

        shootTimer1 = 0;
        shootTimer2 = 0;

        if (bossGeneral.invincible)
        {
            phaseTimer = invincableTime;

            InvincibleStart();

            // Find all renderers in the scene
            Renderer[] renderers = FindObjectsByType<Renderer>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            foreach (Renderer rend in renderers)
            {
                // Skip UI elements
                if (rend.gameObject.layer == LayerMask.NameToLayer("UI"))
                    continue;

                // Store original material if not already stored
                if (!originalMaterials.ContainsKey(rend))
                {
                    originalMaterials[rend] = rend.material;
                }

                // Set black material for background, white for everything else
                rend.material = rend.gameObject.CompareTag("Background") ? blackMaterial : whiteMaterial;
            }
        } else
        {
            phaseTimer = normalTime;

            altNormal = !altNormal;

            // Restore original materials
            foreach (var entry in originalMaterials)
            {
                if (entry.Key != null) // Ensure renderer still exists
                {
                    entry.Key.material = entry.Value;
                }
            }

            // Clear dictionary to reset for next phase change
            originalMaterials.Clear();
        }
    }
}
