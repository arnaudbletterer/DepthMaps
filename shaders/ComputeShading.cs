#version 430 core

layout (std430, binding=0)
buffer vertex_buffer { vec4 vertex[]; };

layout (binding=0)
uniform atomic_uint cur_index;

layout (binding=0)
uniform sampler2D in_tex;

uniform int width;
uniform int height;

layout (local_size_x = 16, local_size_y = 16, local_size_z = 1) in;
void main() {
	vec2 tex_coords = vec2(float(gl_GlobalInvocationID.x)/float(width), float(gl_GlobalInvocationID.y)/float(height));	//x,y in [-1;1]
	float depth = texture(in_tex, tex_coords).r*2-1;	//z in [-1;1]

	if(depth < 1)
	{
		uint index = atomicCounterIncrement(cur_index);
		vertex[index] = vec4(tex_coords.x*2-1, tex_coords.y*2-1, depth, 1.);
	}
}