using UnityEngine;
using UnityEngine.UI;

public static class ImageExtensions
{
    public static Vector2 GetRandomLocalPositionInsideImage(this Image image)
    {
        // Получаем RectTransform компонента Image
        RectTransform rectTransform = image.GetComponent<RectTransform>();

        // Получаем размеры RectTransform
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        // Генерируем случайные координаты внутри размеров
        float randomX = Random.Range(0, width);
        float randomY = Random.Range(0, height);

        // Преобразуем координаты в мировые или локальные координаты
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
        // Получаем RectTransform компонента Image
        RectTransform rectTransform = image.GetComponent<RectTransform>();

        Vector2 localPosition = GetRandomLocalPositionInsideImage(image);

        return rectTransform.TransformPoint(localPosition);
    }
}