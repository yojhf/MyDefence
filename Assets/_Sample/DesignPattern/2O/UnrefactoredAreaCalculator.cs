using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Solid
{
    public class Rectangle
    {
        public float Height;
        public float Width;

    }

    public class Circle
    {
        public float Radius;
    }

    public class UnrefactoredAreaCalculator
    {
        // Non-SOLID implementation: not using Open-Closed principle. Though
        // this approach works well with a small number of effects, it does
        // not scale and becomes unwieldy as the project grows.

        // �Ű������� �簢���� �޾� ������ ��ȯ�ϴ� �Լ�
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.Width * rectangle.Height;
        }

        // �Ű������� ���� �޾� ������ ��ȯ�ϴ� �Լ�
        public float GetCircleArea(Circle circle)
        {
            return circle.Radius * circle.Radius * Mathf.PI;
        }

        // Adds additional methods with additional shapes
        // e.g GetPentagonArea, GetHexagonArea, etc.
    }
}
