using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // スコアを表示する
    public Text scoreText;
    // ハイスコアを表示する
    public Text highScoreText;

    // スコア
    public static float score = 0.0f;

    // ハイスコア
    public static float highScore = 0.0f;

    public float rate = 0.5f;

    // PlayerPrefsで保存するためのキー
    public string highScoreKey = "highScore";

    private static Score instance;
    
    //プロバティ
    public static Score Instance
    {
        get
        {
            
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        PlayerPrefs.DeleteAll();
    }

    
    // Update is called once per frame
    void Update()
    {
        // スコアがハイスコアより大きければ
        if (highScore < score)
        {
            highScore = score;

            PlayerPrefs.SetFloat(highScoreKey, highScore);

            highScoreText.text = "HighScore" + highScore.ToString();
        }

        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;

        // ハイスコアを取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
    }

    // ポイントの追加
    public void AddPoint(float point)
    {
        score = score + point;
        Debug.Log("Score=" + score);
    }

    public void AddDestroyPoint(float point)
    {
        score = score + (point * rate);

        Debug.Log("Score=" + score);
        rate = rate + 0.3f;
    }

    public void ResetRate()
    {
        rate = 0.5f;
    }

    // ハイスコアの保存
    public void Save()
    {
        // ハイスコアを保存する
        PlayerPrefs.SetFloat(highScoreKey, highScore);
        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        Initialize();
    }

}
