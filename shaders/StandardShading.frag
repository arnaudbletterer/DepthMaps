#version 410 core

// Interpolated values from the vertex shaders
in vec2 UV;

// Ouput data
out vec3 color;

// Values that stay constant for the whole mesh.
uniform sampler2D myTextureSampler;

void main(){
	color = vec3(0.5,0.5,0.5) * texture( myTextureSampler, UV ).rgb;
}