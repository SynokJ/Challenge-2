using System;
using UnityEngine;

public class RPGHealth : MonoBehaviour
{
    private GameObject[] _heart;

    [Header("HP Components:")]
    [Tooltip("HP")]
    [Range(0, 10)]
    [SerializeField] private float _healthPoints;

    private void Start()
    {
        if (_healthPoints <= 0) _healthPoints = 10;
        _heart = GameObject.FindGameObjectsWithTag("Heart");
        StartCoroutine(ShowWork());
    }

    private System.Collections.IEnumerator ShowWork()
    {
        for (int i = 0; i < 10; ++i)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(2, 4));
            Damage(UnityEngine.Random.Range(1, 4));
        }
    }

    private void Damage(float damage)
    {
        if (damage > 0 && damage < 10) _healthPoints -= damage;
        Draw();
        if (_healthPoints <= 0)
            Destroy(gameObject);
    }

    private void Draw()
    {
        int start = 0;
        int end = ((int)_healthPoints * 2) / 4;
        for (int i = start; i < _heart.Length; ++i)
            _heart[i].SetActive(false);

        for (int i = start; i < end; ++i)
            _heart[i].SetActive(true);
    }
}
