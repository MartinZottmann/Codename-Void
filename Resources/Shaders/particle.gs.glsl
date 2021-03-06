#version 430 core

uniform mat4 in_ModelView;
uniform mat4 in_Projection;
uniform vec3 in_CameraPosition;
uniform vec3 in_CameraUp;
uniform float in_ParticleSize;

layout(points) in;
layout(triangle_strip, max_vertices = 4) out;

layout(location = 0) in vec4 in_Color[];

layout(location = 0) out vec4 out_Color;
layout(location = 1) out vec2 out_UV;

void main(void) {
    vec4 position = in_ModelView * gl_in[0].gl_Position;

    gl_Position = in_Projection * (position + vec4(-in_ParticleSize, -in_ParticleSize, 0, 0));
    out_Color = in_Color[0];
    out_UV = vec2(0, 0);
    EmitVertex();

    gl_Position = in_Projection * (position + vec4(in_ParticleSize, -in_ParticleSize, 0, 0));
    out_Color = in_Color[0];
    out_UV = vec2(0, 1);
    EmitVertex();

    gl_Position = in_Projection * (position + vec4(-in_ParticleSize, in_ParticleSize, 0, 0));
    out_Color = in_Color[0];
    out_UV = vec2(1, 0);
    EmitVertex();

    gl_Position = in_Projection * (position + vec4(in_ParticleSize, in_ParticleSize, 0, 0));
    out_Color = in_Color[0];
    out_UV = vec2(1, 1);
    EmitVertex();

    EndPrimitive();
}
/*
    vec3 position = gl_in[0].gl_Position.xyz;
    vec3 distance = normalize(in_CameraPosition - position);
    vec3 right = normalize(cross(distance, in_CameraUp));
    vec3 up = normalize(cross(right, distance));
    vec3 x = right * in_ParticleSize * 0.5;
    vec3 y = up * in_ParticleSize * 0.5;

    gl_Position = in_ModelViewProjection * vec4(position - x - y, 1.0);
    out_Color = in_Color[0];
    out_UV = vec2(0.0, 0.0);
    EmitVertex();

    gl_Position = in_ModelViewProjection * vec4(position - x + y, 1.0);
    out_Color = in_Color[0];
    out_UV = vec2(0.0, 1.0);
    EmitVertex();

    gl_Position = in_ModelViewProjection * vec4(position + x - y, 1.0);
    out_Color = in_Color[0];
    out_UV = vec2(1.0, 0.0);
    EmitVertex();

    gl_Position = in_ModelViewProjection * vec4(position + x + y, 1.0);
    out_Color = in_Color[0];
    out_UV = vec2(1.0, 1.0);
    EmitVertex();

    EndPrimitive();
*/
