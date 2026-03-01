using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioSource defaultAudioSource;
    [SerializeField] private AudioSource bossAudioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip energyClip;

    public void PlayShootSound()
    {
        effectAudioSource.PlayOneShot(shootClip);
    }

    public void PlayReLoadSound()
    {
        effectAudioSource.PlayOneShot(reloadClip);
    }

    public void PlayEnergySound()
    {
        effectAudioSource.PlayOneShot(energyClip);
    }

    public void PlayDefaultMusic()
    {
        bossAudioSource.Stop();
        
            defaultAudioSource.Play();
        
    }
    public void PlayBossMusic()
    {
        defaultAudioSource.Stop();
        
            bossAudioSource.Play();
        
    }

    public void StopBackgroundMusic()
    {
        defaultAudioSource.Stop();
        bossAudioSource.Stop();
        effectAudioSource.Stop();
    }
}
