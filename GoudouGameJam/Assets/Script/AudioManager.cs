using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

// オーディオマネージャー
// シングルトンクラス
public class AudioManager : SingletonMonoBehaviour<AudioManager>
{

    public List<AudioClip> BGMList;
    public List<AudioClip> SEList;
    public int MaxSE = 10;

    private AudioSource bgmSource = null;
    private List<AudioSource> seSources = null;
    private Dictionary<string, AudioClip> bgmDict = null;
    private Dictionary<string, AudioClip> seDict = null;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        //create listener
        if (FindObjectsOfType(typeof(AudioListener)).All(o => !((AudioListener)o).enabled))
        {
            gameObject.AddComponent<AudioListener>();
        }
        //create audio sources
        bgmSource = this.gameObject.AddComponent<AudioSource>();
        seSources = new List<AudioSource>();

        //create clip dictionaries
        bgmDict = new Dictionary<string, AudioClip>();
        seDict = new Dictionary<string, AudioClip>();

        Action<Dictionary<string, AudioClip>, AudioClip> addClipDict = (dict, c) => {
            if (!dict.ContainsKey(c.name))
            {
                dict.Add(c.name, c);
            }
        };

        this.BGMList.ForEach(bgm => addClipDict(this.bgmDict, bgm));
        this.SEList.ForEach(se => addClipDict(this.seDict, se));
    }

	//SE再生
	//SEファイルの名前を引数に渡す
    public void PlaySE(string seName)
    {
        if (!this.seDict.ContainsKey(seName)) throw new ArgumentException(seName + " not found", "seName");

        AudioSource source = this.seSources.FirstOrDefault(s => !s.isPlaying);
        if (source == null)
        {
            if (this.seSources.Count >= this.MaxSE)
            {
                Debug.Log("SE AudioSource is full");
                return;
            }

            source = this.gameObject.AddComponent<AudioSource>();
            this.seSources.Add(source);
        }

        source.clip = this.seDict[seName];
        source.Play();
    }

	// SEをストップ
    public void StopSE()
    {
        this.seSources.ForEach(s => s.Stop());
    }

	//BGM再生
	//BGMファイルの名前を引数に渡す
    public void PlayBGM(string bgmName)
    {
        if (!this.bgmDict.ContainsKey(bgmName)) throw new ArgumentException(bgmName + " not found", "bgmName");
        if (this.bgmSource.clip == this.bgmDict[bgmName]) return;

        this.bgmSource.Stop();
        this.bgmSource.clip = this.bgmDict[bgmName];
        bgmSource.loop = true;
        this.bgmSource.Play();
    }

	// BGMストップ
    public void StopBGM()
    {
        this.bgmSource.Stop();
        this.bgmSource.clip = null;
    }

}