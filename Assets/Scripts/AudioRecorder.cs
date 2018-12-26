using UnityEngine;
using UnityEngine.Events;

public class AudioRecorder
{
    public bool isRecording { get; private set; }

    private AudioClip mRecordingClip;
	private readonly int mSampleRate = 44100;
	private readonly float mTrimCutoff = .01f;
	private UnityAction<AudioClip> mOnCompleteCallback;
       
	public void StartRecording(UnityAction<AudioClip> completeCallback, int maxClipLenth = 99)
	{
        if(isRecording)
        {
            Debug.LogWarning("AudioRecorder already recording.");
            return;
        }
        mOnCompleteCallback = completeCallback;
		mRecordingClip = Microphone.Start(null, true, maxClipLenth, mSampleRate);

		isRecording = true;
	}

    public void StopRecording()
    {
        isRecording = false;
        Microphone.End(null);
    }

    public void EndRecording()
	{
        StopRecording();

		AudioClip trimmedClip = SavWav.TrimSilence(mRecordingClip, mTrimCutoff);
		mOnCompleteCallback.Invoke(trimmedClip);      
	}
}
