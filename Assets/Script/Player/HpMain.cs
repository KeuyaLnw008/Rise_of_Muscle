using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpMain : MonoBehaviour
{
    public int HpPlayer1 { get; set; }
    public int HpPlayer2 { get; set; }
    [SerializeField] private Slider sliderPlayer1;
    [SerializeField] private Slider sliderPlayer2;

    [SerializeField] private Player2DProfile _player;
    private void Awake()
    {
        HpPlayer1 = _player.maxHp;
        HpPlayer2 = _player.maxHp;
        sliderPlayer1.maxValue = _player.maxHp;
        sliderPlayer2.maxValue = _player.maxHp;
        sliderPlayer1.value = _player.maxHp;
        sliderPlayer2.value = _player.maxHp;
    }
    private void Update()
    {
        sliderPlayer1.value = HpPlayer1;
        sliderPlayer2.value = HpPlayer2;
    }
}
