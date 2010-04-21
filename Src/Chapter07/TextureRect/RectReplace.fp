// Rectangle Texture (replace) Shader
// Fragment Shader
// Richard S. Wright Jr.
// OpenGL SuperBible
#version 330

out vec4 vFragColor;

uniform samplerRect  rectangleImage;

smooth in vec2 vVaryingTexCoord;

void main(void)
    { 
    vFragColor = texture(rectangleImage, vVaryingTexCoord);
    }
    