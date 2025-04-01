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

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera != null)
        {
            originalBackgroundColor = mainCamera.backgroundColor;
        }
    }

    private void OnEnable()
    {
        phaseTimer = normalTime;
        bossGeneral.invincible = false;
    }

    private void Update()
    {
        phaseTimer -= Time.deltaTime;

        if (phaseTimer <= 0)
        {
            ChangePhase();
        }
    }

    private void ChangePhase()
    {
        bossGeneral.invincible = !bossGeneral.invincible;

        if (bossGeneral.invincible)
        {
            phaseTimer = invincableTime;

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

            originalBackgroundColor = mainCamera.backgroundColor;
            mainCamera.backgroundColor = Color.black;
        } else
        {
            phaseTimer = normalTime;

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

            mainCamera.backgroundColor = originalBackgroundColor;
        }
    }
}
