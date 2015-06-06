using UnityEngine;

public class MusicFxHandler : MonoBehaviour
{

    public AudioSource audioSource;
    private int obstableExplosionClipIndex=0;
    public AudioClip[] obstacleExplosionAudioClips;
    public AudioClip[] projectileHitAudioClips;
    public AudioClip[] shootSoundAudioClips;
    private int shootSoundIndex = 0;
    private int babySoundsIndex = 0 ;
    public AudioClip[] babySoundsAudioClips;
    private int projectileHitAudioClipsIndex = 0;
    public float volumeScalar;
    public float shootVolume;
    // Use this for initialization
    private void Start()
    {
    }


    public void playShootSounds()
    {
        audioSource.PlayOneShot(shootSoundAudioClips[shootSoundIndex],shootVolume);
        if (shootSoundIndex >= shootSoundAudioClips.Length)
            shootSoundIndex = 0;
    }
    public void playBabySounds()
    {
        audioSource.PlayOneShot(babySoundsAudioClips[babySoundsIndex],volumeScalar);
        babySoundsIndex++;
        if (babySoundsIndex >= babySoundsAudioClips.Length)
            babySoundsIndex = 0;
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