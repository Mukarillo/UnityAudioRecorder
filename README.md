# UnityAudioRecorder
Multi-platform helper to record audio.


## How to use
*you can find a pratical example inside this repository in Main scene*

### 1 - Create a new instance of ```AudioRecorder```
```c#
public class Exemple : MonoBehaviour
{
    private AudioRecorder recorder = new AudioRecorder();
}
```

### 2 - Call ```AudioRecorder.StartRecording``` with the callback and maximum length
```c#
public class Exemple : MonoBehaviour
{
    private AudioRecorder recorder = new AudioRecorder();
    
    public void Record()
    {
      recorder.StartRecording(OnFinishRecording, 20);
    }
    
    private void OnFinishRecording(AudioClip clip)
    {
      //clip is the recorded clip
    }
}
```

### 3 - If you want to end the record, just call ```AudioRecorder.EndRecording```. It will invoke the callback that was set in the StartRecording method.

## AudioRecorder `public` overview

### Properties

> `AudioRecorder.isRecording`
- *Description*: Returns true if is recording an audio.

### Methods

> `AudioRecorder.StartRecording`
- *Description*: Starts recording using the default microphone.

- *Parameters* :

|name  |type  |description  |
|--|--|--|
|`completeCallback` |**UnityAction\<AudioClip\>** |*Callback to be called when the recording is done.*  |
|`maxClipLenth` |**int** |*Maximum size of the clip in seconds.*  |

> `AudioRecorder.StopRecording`
- *Description*: Stops recording and do not callback.

> `DebugConsole.EndRecording`
- *Description*: Stops recording and callback.

## External tools
-[UnityWav - by DeadlyFingers](https://github.com/deadlyfingers/UnityWav) 
</br>-[SavWav - by DarkTable](https://gist.github.com/darktable/2317063)
