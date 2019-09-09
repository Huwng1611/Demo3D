using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    public AudioSource sound;
    private float volume = 1f;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        sound.volume = volume;
    }

    public void ChangeVolume(float vol)
    {
        volume = vol;
    }
}
