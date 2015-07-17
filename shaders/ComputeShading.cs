#version 430 core

layout (std430, binding=0)
buffer vertex_buffer { int vertex[]; };

//layout(binding=0)
//uniform atomic_uint cur_index;

//layout (binding=0, rgba32f)
//uniform sampler2D inTex;

layout (local_size_x = 16, local_size_y = 1, local_size_z = 1) in;
void main() {
//	atomicCounterDecrement(cur_index);
	vertex[gl_LocalInvocationID.x] = -vertex[gl_LocalInvocationID.x];

}
