using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EnemyInteractionArea : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _interactionPrefabs;

    private List<GameObject> _interactionObjects = new List<GameObject>();
    private GameObject _interactionObject;

    private Image _image;
    private Coroutine _beginInteractionCoroutine;

    private void Awake()
    {
        _image = GetComponent<Image>();

        foreach (var prefab in _interactionPrefabs)
        {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);

            _interactionObjects.Add(obj);
        }
    }

    private void Start()
    {
        _beginInteractionCoroutine = StartCoroutine(BeginInteractionCoroutine());
    }

    private IEnumerator BeginInteractionCoroutine()
    {
        while (true)
        {
            _interactionObject = _interactionObjects[Random.Range(0, _interactionObjects.Count)];

            _interactionObject.transform.position = _image.GetRandomPositionInsideImage();
            _interactionObject.SetActive(true);

            yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));

            _interactionObject.SetActive(false);
        }
    }
}
