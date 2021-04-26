using System;

namespace Lesson3
{
    public static class MethodsForTest
    {
        //1. Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).        
        public static float PointDistanceClass(PointFloatClass pointOne, PointFloatClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            
            return MathF.Sqrt((x * x) + (y * y));
        }

        //2. Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
        public static float PointDistanceStructF(PointStructF pointOne, PointStructF pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        //3. Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
        public static double PointDistanceStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        //4. Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).
        public static float PointDistanceSrtuctShort(PointStructF pointOne, PointStructF pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
    }
}
