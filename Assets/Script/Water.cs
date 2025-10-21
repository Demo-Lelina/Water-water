using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public GameObject gameOverScreen; //  อ้างอิง GameOverImage ที่เราสร้าง

    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.CompareTag(collision.gameObject.tag) && !isDead)
        {
            isDead = true;
            Debug.Log("Death");
            ShowGameOverScreen();
        }
    }

    void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // แสดงภาพ GameOver
            Time.timeScale = 0f; // หยุดเวลาในเกม
        }
    }

    private void Update()
    {
        if (isDead && Input.GetKeyDown(KeyCode.Space))
        {
            // เมื่อผู้เล่นกดปุ่มใด ๆ จะรีสตาร์ตฉาก
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
