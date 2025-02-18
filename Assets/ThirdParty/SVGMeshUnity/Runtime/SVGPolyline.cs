﻿using System.Collections.Generic;
using SVGMeshUnity.Internals;
using SVGMeshUnity.Internals.Cdt2d;
using UnityEditor;
using UnityEngine;

namespace SVGMeshUnity
{
    public class SVGPolyline
    {
        // https://github.com/mattdesl/adaptive-bezier-curve

        public float Scale = 1f;
        public List<List<Vector2>> Polyline = new List<List<Vector2>>();

        private static WorkBufferPool WorkBufferPool = new WorkBufferPool();
        private BezierToPolyline BezierToPolyline;

        public SVGPolyline()
        {
            BezierToPolyline = new BezierToPolyline();
            BezierToPolyline.WorkBufferPool = WorkBufferPool;
        }
        
        public void Fill(SVGData svg)
        {
            Polyline.Clear();
            BezierToPolyline.Scale = Scale;
            BezierToPolyline.GetContours(svg, Polyline);
            
        }
    }
}