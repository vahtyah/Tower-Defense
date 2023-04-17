using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public static void Create(GameObject effectPrefab, Vector3 position, Transform target, MonoBehaviour instance)
    {
        var effect = ObjectPooler.instance.ActivateObject(effectPrefab.tag);
        effect.SetActive(true);
        effect.transform.position = position;
        effect.transform.LookAt(target);
        var particle = effect.GetComponent<ParticleSystem>();
        var tracer = effect.transform.Find("Tracer").GetComponent<ParticleSystem>().main;
        tracer.startLifetimeMultiplier = Vector3.Distance(position, target.position) / tracer.startSpeedMultiplier;
        particle.Play();
        instance.StartCoroutine(StopParticle(particle, particle.main.startLifetimeMultiplier));
        
    }

    public static IEnumerator StopParticle(ParticleSystem effectPrefab, float timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        effectPrefab.Stop();
        ObjectPooler.instance.DeactivateObject(effectPrefab.gameObject);
    }
}
