using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootboxRarityColors
{
    public LootboxRarityColors(Color c1, Color c2)
    {
        color1 = c1;
        color2 = c2;
    }
    public Color color1;
    public Color color2;
}

public enum Rarity
{
    R2 = 2,
    R3 = 3,
    R4 = 4,
    R5 = 5,
    R6 = 6
}

public static class LootboxRarityColors_Store
{
    public static LootboxRarityColors getRarity(Rarity rarity)
    {
        switch (rarity)
        {
            default:
            case Rarity.R2:
            case Rarity.R3:
                return new LootboxRarityColors(new Color(1, 1, 1), new Color(1, 1, 1));
            case Rarity.R4:
                return new LootboxRarityColors(new Color(0.5647f, 0.586f, 1), new Color(0.152f, 0.2f, 1));
            case Rarity.R5:
                return new LootboxRarityColors(new Color(1, 0.8922791f, 0.2018868f), new Color(1, 0.850573f, 0));
                //     break;
                // case Rarity.R5:
                //     break;
                // case Rarity.R6:
                //     break;
        }
    }
}



public class LockerController : MonoBehaviour
{
    public float mod = 0;
    public float addMod = 0;

    public float maxRotation = 40;
    private float maxAddModRotation; // auto set

    public GameObject door;

    // public GameObject particle1go;
    // public GameObject particle2go;

    public ParticleSystem particle1;
    public ParticleSystem particle2;

    public Rarity currentRarity;

    private LootboxRarityColors currentColor = LootboxRarityColors_Store.getRarity(Rarity.R3);

    // public Image whitescreenImage;

    public void SetRarity(Rarity rarity)
    {
        currentRarity = rarity;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxAddModRotation = (135 - Mathf.Abs(maxRotation)) * Mathf.Sign(maxRotation);
        mod = 0;
        addMod = 0;
    }

    public void BringingStarted()
    {
        mod = 0;
        addMod = 0;
    }


    static void setColor(ParticleSystem particle, LootboxRarityColors colors)
    {
        var col = particle.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys(
            new GradientColorKey[] { new GradientColorKey(colors.color1, 0.0f), new GradientColorKey(colors.color2, 0.544f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(0.53125f, 0.109f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad;
    }

    static void setOpacity(ParticleSystem particleSystem, float opacity)
    {
        var renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        renderer.maxParticleSize = 0.5f * opacity * opacity * opacity;
    }

    // Update is called once per frame
    void Update()
    {
        mod = Mathf.Clamp01(mod);
        addMod = Mathf.Clamp01(addMod);
        door.transform.localRotation = Quaternion.Euler(0, mod * maxRotation + addMod * maxAddModRotation, 0);

        currentColor = LootboxRarityColors_Store.getRarity(currentRarity);
        setColor(particle1, currentColor);
        setColor(particle2, currentColor);

        setOpacity(particle1, mod);
        setOpacity(particle2, mod);

        // whitescreenImage.color = new Color(1, 1, 1, addMod * addMod);
    }
}
