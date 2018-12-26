using UnityEngine;

public class ViewAudioRecorder : MonoBehaviour
{
    public AudioPlayer audioPlayer;

    private AudioRecorder mRecorder;

    private void Awake()
    {
        mRecorder = new AudioRecorder();
        HidePlayer();
    }

    public void StartRecording()
    {
        HidePlayer();
        mRecorder.StartRecording(FinishRecording);
    }

    public void EndRecording()
    {
        mRecorder.EndRecording();
    }

    private void FinishRecording(AudioClip clip)
    {
        SetClip(clip);
    }

    private void HidePlayer()
    {
        audioPlayer.gameObject.SetActive(false);
    }

    private void SetClip(AudioClip clip)
    {
        audioPlayer.gameObject.SetActive(true);
        audioPlayer.SetAudioClip(clip);
    }
}
