using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioPlayerSlider : Slider {

    private AudioPlayer mAudioPlayer;

    protected override void Awake()
    {
        base.Awake();
        mAudioPlayer = transform.parent.GetComponent<AudioPlayer>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        mAudioPlayer.PauseAudio();
        base.OnPointerDown(eventData);
    }
}
