using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    #region Field

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _audioClip;

    private int _random;

    #endregion

    #region Methods

    public void PlaySound()
    {
        _source.GetComponent<AudioSource>();
        _random = Random.Range(0, _audioClip.Length);
        _source.clip = _audioClip[_random];
        _source.Play();
    }

    #endregion
}
