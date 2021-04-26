using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace Lesson3
{
    public class BenchmarkClass
    {
        private readonly int _count = 100000;

        private List<PointFloatClass> pointsFloatClass1;
        private List<PointFloatClass> pointsFloatClass2;

        private List<PointStructF> pointsFloatStruct1;
        private List<PointStructF> pointsFloatStruct2;

        private List<PointStruct> pointsDoubleStruct1;
        private List<PointStruct> pointsDoubleStruct2;

        public BenchmarkClass()
        {
            Random rnd = new Random();

            pointsFloatClass1 = new List<PointFloatClass>();
            pointsFloatClass2 = new List<PointFloatClass>();

            pointsFloatStruct1 = new List<PointStructF>();
            pointsFloatStruct2 = new List<PointStructF>();

            pointsDoubleStruct1 = new List<PointStruct>();
            pointsDoubleStruct2 = new List<PointStruct>();

            for (int i = 0; i < _count; i++)
            {
                pointsFloatClass1.Add(new PointFloatClass 
                { 
                    X = (float)rnd.NextDouble(), 
                    Y = (float)rnd.NextDouble() 
                });
                pointsFloatClass2.Add(new PointFloatClass
                {
                    X = (float)rnd.NextDouble(),
                    Y = (float)rnd.NextDouble()
                });

                pointsFloatStruct1.Add(new PointStructF 
                { 
                    X = (float)rnd.NextDouble(), 
                    Y = (float)rnd.NextDouble()
                });
                pointsFloatStruct2.Add(new PointStructF 
                { 
                    X = (float)rnd.NextDouble(), 
                    Y = (float)rnd.NextDouble()
                });

                pointsDoubleStruct1.Add(new PointStruct
                {
                    X = rnd.NextDouble(),
                    Y = rnd.NextDouble()
                });
                pointsDoubleStruct2.Add(new PointStruct
                {
                    X = rnd.NextDouble(),
                    Y = rnd.NextDouble()
                });
            }
        }

        [Benchmark]
        public void Test_PointDistanceClass()
        {
            for (int i = 0; i < _count; i++)
            {
                MethodsForTest.PointDistanceClass(pointsFloatClass1[i], pointsFloatClass2[i]);
            }            
        }

        [Benchmark]
        public void Test_PointDistanceStructF()
        {
            for (int i = 0; i < _count; i++)
            {
                MethodsForTest.PointDistanceStructF(pointsFloatStruct1[i], pointsFloatStruct2[i]);
            }
        }

        [Benchmark]
        public void Test_PointDistanceStruct()
        {
            for (int i = 0; i < _count; i++)
            {
                MethodsForTest.PointDistanceStruct(pointsDoubleStruct1[i], pointsDoubleStruct2[i]);
            }
        }

        [Benchmark]
        public void Test_PointDistanceSrtuctShort()
        {
            for (int i = 0; i < _count; i++)
            {
                MethodsForTest.PointDistanceSrtuctShort(pointsFloatStruct1[i], pointsFloatStruct2[i]);
            }
        }
    }
}
