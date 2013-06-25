﻿using MartinZottmann.Engine.Graphics.OpenGL;
using MartinZottmann.Engine.Graphics.Shapes;
using MartinZottmann.Engine.Resources;
using OpenTK;

namespace MartinZottmann.Game.Entities
{
    class Floor : Physical
    {
        public Floor(ResourceManager resources)
            : base(resources)
        {
            var shape = new CubeHardNormals();
            shape.Translate(Matrix4.Scale(0.5f) * Matrix4.CreateTranslation(new Vector3(0, -1, 0)));

            graphic = new Engine.Graphics.OpenGL.Entity();
            graphic.Mesh(shape);
            graphic.Program = Resources.Programs["standard_cube"];
            var texture = new Texture("res/textures/debug-256.png", false, OpenTK.Graphics.OpenGL.TextureTarget.TextureCubeMap);
            graphic.Texture = texture;

            graphic.Program.UniformLocations["in_Texture"].Set(0);
            graphic.Program.UniformLocations["in_LightPosition"].Set(new Vector3(10, 10, 10));

            BoundingBox.Max = new Vector3d(0.5, 1.5, 0.5);
            BoundingBox.Min = new Vector3d(-0.5, -1.5, -0.5);
        }

        public override void Render(double delta_time)
        {
            graphic.Program.UniformLocations["in_Model"].Set(RenderContext.Model);
            graphic.Program.UniformLocations["in_View"].Set(RenderContext.View);
            graphic.Program.UniformLocations["in_ModelView"].Set(RenderContext.ViewModel);
            graphic.Program.UniformLocations["in_ModelViewProjection"].Set(RenderContext.ProjectionViewModel);
            graphic.Program.UniformLocations["in_NormalView"].Set(RenderContext.Normal);
            graphic.Draw();
        }
    }
}
