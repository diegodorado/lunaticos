using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text meteoroidsCountText;

    public Slider oxigenSlider;
    public float oxigenDischargeRate = 0.1f;

    public Slider timeSlider;
    public float timeDischargeRate = 0.01f;

    public GameObject gameOverPanel;
    public Text gameOverText;
    public MouseLook hMouseLook;
    public MouseLook vMouseLook;
    public CharacterMotor characterMotor;

    private int m_meteoroidsCount;
    public int meteoroidsCount
    {
        get
        {
            return m_meteoroidsCount;
        }
        set
        {
            m_meteoroidsCount = value;
            if (meteoroidsCountText != null)
                meteoroidsCountText.text = meteoroidsCount.ToString();
        }
    }

    private float m_oxigen;
    public float oxigen
    {
        get
        {
            return m_oxigen;
        }
        set
        {
            m_oxigen = value;
            if (oxigenSlider != null)
                oxigenSlider.value = value;
        }
    }


    private float m_time;
    public float time
    {
        get
        {
            return m_time;
        }
        set
        {
            m_time = value;
            if (timeSlider != null)
                timeSlider.value = value;
        }
    }

    public bool dead { get; set; }

    void Start()
    {
        oxigen = 1f;
        time = 1f;
        dead = false;
    }

    void Update()
    {
        if (dead)
            return;

        if (oxigen <= 0)
            Die(false);
        else
            oxigen -= oxigenDischargeRate * Time.deltaTime;

        if (time <= 0)
            Die(true);
        else
            time -= timeDischargeRate * Time.deltaTime;
    }

    void Die(bool timeOver)
    {
        dead = true;
        if(timeOver)
            gameOverText.text = string.Format("tu tiempo se agoto.\n\n lograste juntar {0} meteoroides.", meteoroidsCount);
        else
            gameOverText.text = string.Format("tu oxigeno se agoto. recuerda entrar a la base para recargarlo\n\n lograste juntar {0} meteoroides.", meteoroidsCount);

        gameOverPanel.SetActive(true);

        //disable controls
        hMouseLook.enabled = false;
        vMouseLook.enabled = false;
        characterMotor.enabled = false; 



    }

}
