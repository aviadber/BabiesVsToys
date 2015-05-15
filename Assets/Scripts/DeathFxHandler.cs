using UnityEngine;
using System.Collections;

public class DeathFxHandler : MonoBehaviour {
    public  GameObject[] enemyExplodingEffects;
    public  GameObject[] obsticleExplodingEffects;
    private static int obsticleCounter = 0;
    private static int enemyCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void instantiateObsibleFx(Transform otherTransform)
    {
        Instantiate(obsticleExplodingEffects[obsticleCounter], otherTransform.position, otherTransform.rotation);
        obsticleCounter++;
        if (obsticleCounter >= obsticleExplodingEffects.Length)
            obsticleCounter = 0;

    }

    public void instantiateEnemyFx(Transform otherTransform)
    {
        Instantiate(enemyExplodingEffects[enemyCounter], otherTransform.position, otherTransform.rotation);
        enemyCounter++;
        if (enemyCounter >= enemyExplodingEffects.Length)
            enemyCounter = 0;
    }
}
