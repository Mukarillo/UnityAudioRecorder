using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioPlayerSlider audioSlider;
    public Image buttonImage;

    public Sprite playSprite;
    public Sprite pauseSprite;

    private bool mInternalIsPlaying;

    public void SetAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        ResetPlayer();
    }

    public void PauseAudio()
    {
        ResetPlayer();
        audioSource.Pause();
    }

    public void ToggleClip()
    {
        buttonImage.sprite = !audioSource.isPlaying ? pauseSprite : playSprite;

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            mInternalIsPlaying = false;
        }
        else
        {
            audioSource.time = audioSource.clip.length * audioSlider.value;
            audioSource.Play();

            mInternalIsPlaying = true;
        }
    }

    public void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (mInternalIsPlaying)
                ResetPlayer(true);
            return;
        }

        audioSlider.value = audioSource.time / audioSource.clip.length;
    }

    private void ResetPlayer(bool resetSlider = false)
    {
        if(resetSlider)
            audioSlider.value = 0f;

        mInternalIsPlaying = false;
        buttonImage.sprite = playSprite;
    }
}
