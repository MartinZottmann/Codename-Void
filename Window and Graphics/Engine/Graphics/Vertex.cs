﻿using OpenTK;

namespace MartinZottmann.Engine.Graphics
{
    public struct VertexObject
    {
        public Vector3[] vertices;

        public Color4[] colors;
    }

    public struct VertexP3C4
    {
        public Vector3 position;

        public Color4 color;

        public VertexP3C4(Vector3 position, Color4 color)
        {
            this.position = position;
            this.color = color;
        }

        public VertexP3C4(float x, float y, float z, float r, float g, float b, float a) : this(new Vector3(x, y, z), new Color4(r, g, b, a)) { }

        public string[] GetAttributeLayout()
        {
            return new string[] {
                "in_Position",
                "in_Color"
            };
        }

        //public static readonly int Stride = Marshal.SizeOf(default(VertexData));
    }

    public struct VertexP3N3T2
    {
        public Vector3 position;

        public Vector3 normal;

        public Vector2 texcoord;

        public VertexP3N3T2(Vector3 position, Vector3 normal, Vector2 texcoord)
        {
            this.position = position;
            this.normal = normal;
            this.texcoord = texcoord;
        }

        public VertexP3N3T2(float px, float py, float pz, float nx, float ny, float nz, float s, float t) : this(new Vector3(px, py, pz), new Vector3(nx, ny, nz), new Vector2(s, t)) { }

        public string[] GetAttributeLayout()
        {
            return new string[] {
                "in_Position",
                "in_Normal",
                "in_TexCoord"
            };
        }
    }

    public struct VertexP3N3T2SOA
    {
        public Vector3[] position;

        public Vector3[] normal;

        public Vector2[] texcoord;

        public VertexP3N3T2SOA(Vector3[] position, Vector3[] normal, Vector2[] texcoord)
        {
            this.position = position;
            this.normal = normal;
            this.texcoord = texcoord;
        }

        public string[] GetAttributeLayout()
        {
            return new string[] {
                "in_Position",
                "in_Normal",
                "in_TexCoord"
            };
        }
    }
}