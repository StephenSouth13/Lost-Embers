using System.Collections;
using UnityEngine;

public class LightningManager : MonoBehaviour
{
    public Light lightning;
    public AudioSource thunderSound;
    public AudioClip thunderSoundClip;

    public float lightningFadeInTime = 0.15f;   // thời gian sáng lên
    public float lightningMaxIntensity = 1f;
    public float minInterval = 5f;

    private float timer;

    void Start()
    {
        lightning.enabled = false;
        lightning.intensity = 0f;
        timer = minInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            StartCoroutine(FlashLightning());
            timer = Random.Range(minInterval, minInterval + 5f);
        }
    }

    IEnumerator FlashLightning()
    {
        lightning.enabled = true;
        lightning.intensity = 0f;

        float elapsed = 0f;

        // Fade in: 0 -> max intensity
        while (elapsed < lightningFadeInTime)
        {
            elapsed += Time.deltaTime;
            lightning.intensity = Mathf.Lerp(
                0f,
                lightningMaxIntensity,
                elapsed / lightningFadeInTime
            );
            yield return null;
        }

        lightning.intensity = lightningMaxIntensity;

        thunderSound.PlayOneShot(thunderSoundClip);

        // giữ sáng ngắn
        yield return new WaitForSeconds(Random.Range(0.05f, 0.15f));

        lightning.enabled = false;
        lightning.intensity = 0f;
    }
}
