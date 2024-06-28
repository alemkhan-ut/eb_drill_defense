using UnityEngine;
using UnityEngine.UI;

public static class ImageExtensions
{
    public static Vector2 GetRandomLocalPositionInsideImage(this Image image)
    {
        // �������� RectTransform ���������� Image
        RectTransform rectTransform = image.GetComponent<RectTransform>();

        // �������� ������� RectTransform
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        // ���������� ��������� ���������� ������ ��������
        float randomX = Random.Range(0, width);
        float randomY = Random.Range(0, height);

        // ����������� ���������� � ������� ��� ��������� ����������
        Vector2 localPosition = new Vector2(randomX - width / 2, randomY - height / 2);

        return localPosition;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="image"></param>
    /// <returns>Get random world position</returns>
    public static Vector2 GetRandomPositionInsideImage(this Image image)
    {
        // �������� RectTransform ���������� Image
        RectTransform rectTransform = image.GetComponent<RectTransform>();

        Vector2 localPosition = GetRandomLocalPositionInsideImage(image);

        return rectTransform.TransformPoint(localPosition);
    }
}