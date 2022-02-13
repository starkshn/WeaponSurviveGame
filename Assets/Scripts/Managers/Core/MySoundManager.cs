using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySoundManager
{
    // MP3 Player -> AudioSource
    // MP3 ���� -> AudioClip
    // ����(��) -> AudioListener

    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount]; // �뵵�� ����� ����� ����.


    // ĳ�� ������ �� _audioClips ��Ǿ 
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void init()
    {
        GameObject cube = GameObject.Find("Cube");
        if (cube == null)
        {
            cube = new GameObject { name = "Cube" };
            Object.DontDestroyOnLoad(cube);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));

            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = cube.transform;
            }

            _audioSources[(int)Define.Sound.Bgm].loop = true;
        }
    }

    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }

    public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        if (path.Contains("Sounds/") == false)
        {
            path = $"Sounds/{path}";
            // �̷��� �ϸ� UnityChan/���� ���� �̷������� path�ִ´�.
        }

        if (type == Define.Sound.Bgm)
        {
            AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Debug.Log($"AudioClip Missing ! {path}");
                return;
            }

            // ToDo (bgm ó���κ�)
            AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();


        }

        else if (type == Define.Sound.Effect)
        {
            AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Debug.Log($"AudioClip Missing ! {path}");
                return;
            }

            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect]; // Effect���� ��쿡�� PlayOneshot���� ��� ������ �ƴϱ� audioSource�� ��Ƴ���.
            audioSource.pitch = pitch;

            audioSource.PlayOneShot(audioClip); // Clip ���� ���� ������ ã���� clip�� �־����

        }

        // �����ϴ� ���� ����
        else
        {
            AudioClip audioClip = GetOrAddAudioClip(path);
            if (audioClip == null)
            {
                Debug.Log($"AudioClip Missing ! {path}");
                return;
            }

            AudioSource audioSource = _audioSources[(int)Define.Sound.Jump];

            audioSource.pitch = pitch;

            audioSource.PlayOneShot(audioClip);
        }
        // Ȥ�ö� ���� Ÿ���� �߰��� �ȴٸ� ���� if������ �� ó���� �ϸ�� ���̴�.
    }

    AudioClip GetOrAddAudioClip(string path) // audioClip ��ȯ�ϴ� �Լ�(���� Dictionary���� �κп���)
    {
        AudioClip audioClip = null;
        if (_audioClips.TryGetValue(path, out audioClip) == false) // ������ �̷��� ���� ����ְ� 
        {
            // ���ٸ� ������ ����������
            audioClip = Managers.Resource.Load<AudioClip>(path);
            _audioClips.Add(path, audioClip);
        }

        return audioClip;
    }

}
