using UnityEngine;

public class MusicFxHandler : MonoBehaviour
{
    public AudioSource audioSource;
    private int obstableExplosionClipIndex;
    public AudioClip[] obstacleExplosionAudioClips;
    public AudioClip[] projectileHitAudioClips;
    private int projectileHitAudioClipsIndex;
    public float volumeScalar;
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void playProjectileHitSfx()
    {
        audioSource.PlayOneShot(projectileHitAudioClips[projectileHitAudioClipsIndex], volumeScalar);

        projectileHitAudioClipsIndex++;
        if (projectileHitAudioClipsIndex >= projectileHitAudioClips.Length)
            projectileHitAudioClipsIndex = 0;
    }

    public void playObstableExplosionSoundFx()
    {
        audioSource.PlayOneShot(obstacleExplosionAudioClips[obstableExplosionClipIndex], volumeScalar);
        obstableExplosionClipIndex++;
        if (obstableExplosionClipIndex >= obstacleExplosionAudioClips.Length)
            obstableExplosionClipIndex = 0;
    }
}