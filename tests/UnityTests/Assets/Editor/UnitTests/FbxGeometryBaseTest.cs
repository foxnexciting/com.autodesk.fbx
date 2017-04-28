﻿// ***********************************************************************
// Copyright (c) 2017 Unity Technologies. All rights reserved.  
//
// Licensed under the ##LICENSENAME##. 
// See LICENSE.md file in the project root for full license information.
// ***********************************************************************

using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using FbxSdk;

namespace UnitTests
{
    public class FbxGeometryBaseTest : Base<FbxGeometryBase>
    {
        [Test]
        public void TestBasics()
        {
            var geometryBase = CreateObject ("geometry base");

            geometryBase.InitControlPoints (24);
            Assert.AreEqual (geometryBase.GetControlPointsCount (), 24);
            geometryBase.SetControlPointAt(new FbxVector4(1,2,3,4), 0);
            Assert.AreEqual(new FbxVector4(1,2,3,4), geometryBase.GetControlPointAt(0));

            int layerId0 = geometryBase.CreateLayer();
            int layerId1 = geometryBase.CreateLayer();
            var layer0 = geometryBase.GetLayer(layerId0);
            var layer1 = geometryBase.GetLayer(layerId1);
            Assert.AreNotEqual(layer0, layer1);

            // Fbx crashes setting a negative control point index, so we do some testing:
            Assert.That (() => geometryBase.SetControlPointAt (new FbxVector4(), -1), Throws.Exception.TypeOf<System.IndexOutOfRangeException>());

            // It doesn't crash with past-the-end, it resizes; make sure we don't block that.
            geometryBase.SetControlPointAt (new FbxVector4(1,2,3,4), 50); // does not throw
            Assert.AreEqual (geometryBase.GetControlPointsCount (), 51);

            // It doesn't crash getting negative nor past-the-end.
            // The vector returned is documented to be (0,0,0,1) but actually
            // seems to be (0,0,0,epsilon).
            geometryBase.GetControlPointAt(-1);
            geometryBase.GetControlPointAt(geometryBase.GetControlPointsCount() + 1);

            // You can even initialize to a negative number of control points:
            using (FbxGeometryBase geometryBase2 = CreateObject ("geometry base")) {
                // make sure this doesn't crash
                geometryBase2.InitControlPoints (-1);
            }
        }
    }
}