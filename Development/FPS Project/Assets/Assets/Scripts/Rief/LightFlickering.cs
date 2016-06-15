using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

    public Vector2 waitTime;
    public Vector2 lightMultiplier;
    public float offTime;
    private float cooldown;
    private bool isRunning;
    private float intensity;
    private Light light;

    void Start () {
        light = GetComponent<Light>();
        intensity = light.intensity;
    }

    float SetCooldown () {
        float random = Random.Range(waitTime.x, waitTime.y);
        return random;
    }

    void Update () {
        if(!isRunning) {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0) {
                StartCoroutine(LightFlicker());
            }
        }
    }

    public IEnumerator LightFlicker () {
        isRunning = true;
        light.intensity = intensity * Random.Range(lightMultiplier.x, lightMultiplier.y);
        yield return new WaitForSeconds(offTime);
        light.intensity = intensity;
        cooldown = SetCooldown();
        isRunning = false;
    }
}
