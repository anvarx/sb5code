// blur.fs
// outputs 1 color interpolated from VS
// 
#version 150 

varying vec4 vFragColor; 
varying vec2 vTex; 

uniform sampler2DMS textureUnit0;
uniform vec2 tc_offset[25];

// TODO remove this
uniform ivec2 textureUnit0Size;
 
out vec4 oColor;

void main(void) 
{ 
	vec4 sample[25];
    for (int i = 0; i < 25; i++)
    {
    	//ivec2 iTmp = textureSize2DMS(textureUnit0);
    	ivec2 iTmp = textureUnit0Size;
		vec2  tmp = floor(iTmp * (textureUnit0, vTex.st + tc_offset[i])); 
        sample[i] = texelFetch2DMS(textureUnit0, ivec2(tmp), 0);
    }

//   1  4  7  4 1
//   4 16 26 16 4
//   7 26 41 26 7 / 273
//   4 16 26 16 4
//   1  4  7  4 1

    oColor = (
                   (1.0  * (sample[0] + sample[4] + sample[20] + sample[24])) +
                   (4.0  * (sample[1] + sample[3] + sample[5] + sample[9] +
                            sample[15] + sample[19] + sample[21] + sample[23])) +
                   (7.0  * (sample[2] + sample[10] + sample[14] + sample[22])) +
                   (16.0 * (sample[6] + sample[8] + sample[16] + sample[18])) +
                   (26.0 * (sample[7] + sample[11] + sample[13] + sample[17])) +
                   (41.0 * sample[12])
                   ) / 273.0;

}