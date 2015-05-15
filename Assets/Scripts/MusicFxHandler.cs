using UnityEngine;
using System.Collections;

public class MusicFxHandler : MonoBehaviour
{
    public AudioClip[] projectileHitAudioClips;
    public AudioClip[] obstacleExplosionAudioClips;
    private int projectileHitAudioClipsIndex=0;
    private int obstableExplosionClipIndex=0;
    public AudioSource audioSource;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playProjectileHitSfx()
    {
        audioSource.PlayOneShot(projectileHitAudioClips[projectileHitAudioClipsIndex],0.1f);
       
        projectileHitAudioClipsIndex++;
        if (projectileHitAudioClipsIndex >= projectileHitAudioClips.Length)
            projectileHitAudioClipsIndex = 0;
    }

    public void playObstableExplosionSoundFx()
    {
       audioSource.PlayOneShot(obstacleExplosionAudioClips[obstableExplosionClipIndex],0.1f);
        obstableExplosionClipIndex++;
        if (obstableExplosionClipIndex >= obstacleExplosionAudioClips.Length)
            obstableExplosionClipIndex = 0;
    }
}
