//Maya ASCII 2012 scene
//Name: mesh_one.ma
//Last modified: Wed, Dec 07, 2011 05:26:28 PM
//Codeset: UTF-8
requires maya "2012";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2012";
fileInfo "version" "2012 x64";
fileInfo "cutIdentifier" "201103110020-796618";
fileInfo "osv" "Mac OS X 10.7";
createNode transform -n "planarTrimmedSurface4";
	setAttr ".rp" -type "double3" -0.33850219989344765 0.52738189165353333 0 ;
	setAttr ".sp" -type "double3" -0.33850219989344765 0.52738189165353333 0 ;
createNode mesh -n "planarTrimmedSurfaceShape4" -p "planarTrimmedSurface4";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 100 ".uvst[0].uvsp[0:99]" -type "float2" 0.86589134 0.019273477
		 0 0.56622601 0.74906683 1 1 0.5664978 0.41535768 0.57838142 0.033964742 0.54835457
		 0.57284552 0.0089113368 0.82074231 0 0.98502278 0.5 0.46179673 0.5 0.91421837 0.21428572
		 0.50456762 0.21428572 0.71428573 0.21428572 0.71428573 0.003841592 0.52595305 0.071428575
		 0.71428573 0.071428575 0.53677702 0.021196786 0.53677702 0.071428575 0.51526034 0.14285715
		 0.71428573 0.14285715 0.53677702 0.14285715 0.53677702 0.21428572 0.87881619 0.071428575
		 0.85714287 0.071428575 0.85714287 0.0084871883 0.89651728 0.14285715 0.85714287 0.14285715
		 0.85714287 0.21428572 0.94962054 0.35714287 0.48318216 0.35714287 0.71428573 0.35714287
		 0.49387491 0.2857143 0.71428573 0.2857143 0.53677702 0.2857143 0.53677702 0.35714287
		 0.93191946 0.2857143 0.85714287 0.2857143 0.85714287 0.35714287 0.71428573 0.5 0.47248945
		 0.42857143 0.71428573 0.42857143 0.53677702 0.42857143 0.53677702 0.5 0.96732169
		 0.42857143 0.85714287 0.42857143 0.85714287 0.5 0.93055475 0.71428573 0.0014340574
		 0.71428573 0.42857143 0.71428573 0.42857143 0.57707083 4.9888302e-05 0.5714286 0.32573402
		 0.5714286 0.14285715 0.55680054 0.14285715 0.5714286 0.2857143 0.56822747 0.2857143
		 0.5714286 0.14285715 0.71428573 0.00074197282 0.64285713 0.14285715 0.64285713 0.42857143
		 0.64285713 0.2857143 0.64285713 0.2857143 0.71428573 0.71428573 0.71428573 0.44364393
		 0.5714286 0.71428573 0.5714286 0.53677702 0.5714286 0.71428573 0.64285713 0.53677702
		 0.64285713 0.53677702 0.71428573 0.99981064 0.5714286 0.85714287 0.5714286 0.96839654
		 0.64285713 0.85714287 0.64285713 0.85714287 0.71428573 0.42857143 0.94860792 0.0028161055
		 0.85714287 0.42857143 0.85714287 0.14285715 0.85714287 0.0021261419 0.78571427 0.14285715
		 0.78571427 0.42857143 0.78571427 0.2857143 0.78571427 0.2857143 0.85714287 0.14285715
		 0.9019435 0.30589315 0.9285714 0.42857143 0.9285714 0.2857143 0.92527568 0.85487115
		 0.85714287 0.71428573 0.85714287 0.71428573 0.78571427 0.53677702 0.78571427 0.53677702
		 0.85714287 0.89271295 0.78571427 0.85714287 0.78571427 0.85714287 0.85285485 0.71428573
		 0.9952724 0.71428573 0.9285714 0.53677702 0.9285714 0.53677702 0.9662807 0.81702936
		 0.9285714;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".bnr" 0;
	setAttr -s 100 ".pt[0:99]" -type "float3"  -33.345257 26.840403 8.1202259 
		-33.345257 17.601505 -1.1186719 -33.345257 10.274392 -8.4457855 -33.345257 17.596914 
		-1.1232629 -33.345257 17.396179 -1.323998 -33.345257 17.903381 -0.81679583 -33.345257 
		27.01543 8.2952538 -33.345257 27.165962 8.4457855 -33.345257 18.720167 -1.001358e-05 
		-33.345257 18.720167 -1.001358e-05 -33.345257 23.546335 4.826158 -33.345257 23.546335 
		4.826158 -33.345257 23.546335 4.826158 -33.345257 27.101072 8.3808956 -33.345257 
		25.959419 7.2392421 -33.345257 25.959419 7.2392421 -33.345257 26.807915 8.087738 
		-33.345257 25.959419 7.2392421 -33.345257 24.752878 6.032701 -33.345257 24.752878 
		6.032701 -33.345257 24.752878 6.032701 -33.345257 23.546335 4.826158 -33.345257 25.959419 
		7.2392421 -33.345257 25.959419 7.2392421 -33.345257 27.022617 8.3024406 -33.345257 
		24.752878 6.032701 -33.345257 24.752878 6.032701 -33.345257 23.546335 4.826158 -33.345257 
		21.133251 2.413074 -33.345257 21.133251 2.413074 -33.345257 21.133251 2.413074 -33.345257 
		22.339794 3.619617 -33.345257 22.339794 3.619617 -33.345257 22.339794 3.619617 -33.345257 
		21.133251 2.413074 -33.345257 22.339794 3.619617 -33.345257 22.339794 3.619617 -33.345257 
		21.133251 2.413074 -33.345257 18.720167 -1.001358e-05 -33.345257 19.92671 1.206533 
		-33.345257 19.92671 1.206533 -33.345257 19.92671 1.206533 -33.345257 18.720167 -1.001358e-05 
		-33.345257 19.92671 1.206533 -33.345257 19.92671 1.206533 -33.345257 18.720167 -1.001358e-05 
		-33.345257 15.100542 -3.6196351 -33.345257 15.100542 -3.6196351 -33.345257 15.100542 
		-3.6196351 -33.345257 17.418318 -1.3018594 -33.345257 17.513626 -1.2065511 -33.345257 
		17.513626 -1.2065511 -33.345257 17.760715 -0.95946169 -33.345257 17.513626 -1.2065511 
		-33.345257 17.567698 -1.1524796 -33.345257 17.513626 -1.2065511 -33.345257 15.100542 
		-3.6196351 -33.345257 16.307083 -2.4130931 -33.345257 16.307083 -2.4130931 -33.345257 
		16.307083 -2.4130931 -33.345257 16.307083 -2.4130931 -33.345257 15.100542 -3.6196351 
		-33.345257 15.100542 -3.6196351 -33.345257 17.513624 -1.206553 -33.345257 17.513626 
		-1.2065511 -33.345257 17.513626 -1.2065511 -33.345257 16.307083 -2.4130931 -33.345257 
		16.307083 -2.4130931 -33.345257 15.100542 -3.6196351 -33.345257 17.513626 -1.2065511 
		-33.345257 17.513626 -1.2065511 -33.345257 16.307083 -2.4130931 -33.345257 16.307083 
		-2.4130931 -33.345257 15.100542 -3.6196351 -33.345257 11.142467 -7.5777097 -33.345257 
		12.687457 -6.0327201 -33.345257 12.687457 -6.0327201 -33.345257 12.687457 -6.0327201 
		-33.345257 13.893999 -4.8261781 -33.345257 13.893999 -4.8261781 -33.345257 13.893999 
		-4.8261781 -33.345257 13.893999 -4.8261781 -33.345257 12.687457 -6.0327201 -33.345257 
		11.930704 -6.7894731 -33.345257 11.480915 -7.2392621 -33.345257 11.480915 -7.2392621 
		-33.345257 11.536586 -7.1835914 -33.345257 12.687457 -6.0327201 -33.345257 12.687457 
		-6.0327201 -33.345257 13.893999 -4.8261781 -33.345257 13.893999 -4.8261781 -33.345257 
		12.687457 -6.0327201 -33.345257 13.893999 -4.8261781 -33.345257 13.893999 -4.8261781 
		-33.345257 12.759889 -5.9602885 -33.345257 10.35423 -8.3659477 -33.345257 11.480915 
		-7.2392621 -33.345257 11.480915 -7.2392621 -33.345257 10.843946 -7.8762307 -33.345257 
		11.480915 -7.2392621;
	setAttr -s 100 ".vt[0:99]"  36.24481583 -26.31302071 0 28.58184624 -17.074123383 0
		 35.21093369 -9.74701023 0 37.4316597 -17.069532394 0 32.25764847 -16.8687973 0 28.88236618 -17.37599945 0
		 33.65139771 -26.48804855 0 35.84525299 -26.63858032 0 37.29911423 -18.19278526 0
		 32.66862869 -18.19278526 0 36.67250443 -23.018953323 0 33.047145844 -23.018953323 0
		 34.90312576 -23.018953323 0 34.90312576 -26.57369041 0 33.23640442 -25.43203735 0
		 34.90312576 -25.43203735 0 33.33219528 -26.28053284 0 33.33219528 -25.43203735 0
		 33.14177322 -24.22549629 0 34.90312576 -24.22549629 0 33.33219528 -24.22549629 0
		 33.33219528 -23.018953323 0 36.35919952 -25.43203735 0 36.16739273 -25.43203735 0
		 36.1674118 -26.49523544 0 36.51585007 -24.22549629 0 36.16739273 -24.22549629 0 36.16739273 -23.018953323 0
		 36.98580933 -20.60586929 0 32.85788727 -20.60586929 0 34.90312576 -20.60586929 0
		 32.95251465 -21.81241226 0 34.90312576 -21.81241226 0 33.33219528 -21.81241226 0
		 33.33219528 -20.60586929 0 36.82915497 -21.81241226 0 36.16739273 -21.81241226 0
		 36.16739273 -20.60586929 0 34.90312576 -18.19278526 0 32.76325607 -19.39932823 0
		 34.90312576 -19.39932823 0 33.33219528 -19.39932823 0 33.33219528 -18.19278526 0
		 37.14245987 -19.39932823 0 36.16739273 -19.39932823 0 36.16739273 -18.19278526 0
		 36.81707764 -14.57316017 0 28.59447479 -14.57316017 0 32.37458801 -14.57316017 0
		 32.37458801 -16.8909359 0 28.58222389 -16.9862442 0 31.46448898 -16.9862442 0 29.84605026 -17.23333359 0
		 29.84605026 -16.9862442 0 31.11031914 -17.040315628 0 31.11031914 -16.9862442 0 29.84605026 -14.57316017 0
		 28.58834839 -15.77970219 0 29.84605026 -15.77970219 0 32.37458801 -15.77970219 0
		 31.11031914 -15.77970219 0 31.11031914 -14.57316017 0 34.90312576 -14.57316017 0
		 32.50798035 -16.98624229 0 34.90312576 -16.9862442 0 33.33219528 -16.9862442 0 34.90312576 -15.77970219 0
		 33.33219528 -15.77970219 0 33.33219528 -14.57316017 0 37.42998886 -16.9862442 0 36.16739273 -16.9862442 0
		 37.15197372 -15.77970219 0 36.16739273 -15.77970219 0 36.16739273 -14.57316017 0
		 32.37458801 -10.6150856 0 28.60668755 -12.16007519 0 32.37458801 -12.16007519 0 29.84605026 -12.16007519 0
		 28.60059929 -13.3666172 0 29.84605026 -13.3666172 0 32.37458801 -13.3666172 0 31.11031914 -13.3666172 0
		 31.11031914 -12.16007519 0 29.84605026 -11.40332222 0 31.28890038 -10.95353317 0
		 32.37458801 -10.95353317 0 31.11031914 -11.0092039108 0 36.14728928 -12.16007519 0
		 34.90312576 -12.16007519 0 34.90312576 -13.3666172 0 33.33219528 -13.3666172 0 33.33219528 -12.16007519 0
		 36.48218536 -13.3666172 0 36.16739273 -13.3666172 0 36.16739273 -12.23250675 0 34.90312576 -9.82684803 0
		 34.90312576 -10.95353317 0 33.33219528 -10.95353317 0 33.33219528 -10.31656456 0
		 35.81239319 -10.95353317 0;
	setAttr -s 172 ".ed";
	setAttr ".ed[0:165]"  99 2 0 2 95 0 95 96 1 96 99 1 43 8 0 8 45 1 45 44 1
		 44 43 1 25 10 0 10 27 1 27 26 1 26 25 1 12 21 1 21 20 1 20 19 1 19 12 1 16 6 0 6 13 0
		 13 15 1 15 17 1 17 16 1 14 16 0 17 14 1 15 19 1 20 17 1 18 14 0 20 18 1 21 11 1 11 18 0
		 0 22 0 22 23 1 23 24 1 24 0 0 23 15 1 13 7 0 7 24 0 22 25 0 26 23 1 26 19 1 27 12 1
		 35 28 0 28 37 1 37 36 1 36 35 1 30 34 1 34 33 1 33 32 1 32 30 1 12 32 1 33 21 1 31 11 0
		 33 31 1 34 29 1 29 31 0 10 35 0 36 27 1 36 32 1 37 30 1 38 42 1 42 41 1 41 40 1 40 38 1
		 30 40 1 41 34 1 39 29 0 41 39 1 42 9 1 9 39 0 28 43 0 44 37 1 44 40 1 45 38 1 71 46 0
		 46 73 1 73 72 1 72 71 1 48 61 1 61 60 1 60 59 1 59 48 1 54 51 0 51 55 1 55 54 1 50 1 0
		 1 5 0 5 52 0 52 53 1 53 50 1 52 54 0 55 53 1 56 47 1 47 57 0 57 58 1 58 56 1 57 50 0
		 53 58 1 51 4 0 4 49 0 49 59 1 60 55 1 60 58 1 61 56 1 62 68 1 68 67 1 67 66 1 66 62 1
		 38 64 1 64 65 1 65 42 1 63 9 0 65 63 1 64 66 1 67 65 1 49 63 0 67 59 1 68 48 1 8 3 0
		 3 69 0 69 70 1 70 45 1 70 64 1 69 71 0 72 70 1 72 66 1 73 62 1 74 84 0 84 85 1 85 74 1
		 80 76 1 76 82 1 82 81 1 81 80 1 75 78 0 78 79 1 79 77 1 77 75 1 78 47 0 56 79 1 48 80 1
		 81 61 1 81 79 1 82 77 1 83 75 0 77 83 1 84 86 0 86 82 1 76 85 1 86 83 0 92 94 0 94 93 1
		 93 92 1 88 91 1 91 90 1 90 89 1 89 88 1 62 89 1 90 68 1 90 80 1 91 76 1 46 92 0 93 73 1
		 93 89 1 94 87 0 87 88 1 95 98 0 98 97 1;
	setAttr ".ed[166:171]" 97 96 1 88 96 1 97 91 1 97 85 1 98 74 0 87 99 0;
	setAttr -s 73 ".fc[0:72]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 99 2 95 96
		f 4 4 5 6 7
		mu 0 4 43 8 45 44
		f 4 8 9 10 11
		mu 0 4 25 10 27 26
		f 4 12 13 14 15
		mu 0 4 12 21 20 19
		f 5 16 17 18 19 20
		mu 0 5 16 6 13 15 17
		f 3 21 -21 22
		mu 0 3 14 16 17
		f 4 -20 23 -15 24
		mu 0 4 17 15 19 20
		f 4 25 -23 -25 26
		mu 0 4 18 14 17 20
		f 4 27 28 -27 -14
		mu 0 4 21 11 18 20
		f 4 29 30 31 32
		mu 0 4 0 22 23 24
		f 5 33 -19 34 35 -32
		mu 0 5 23 15 13 7 24
		f 4 36 -12 37 -31
		mu 0 4 22 25 26 23
		f 4 38 -24 -34 -38
		mu 0 4 26 19 15 23
		f 4 39 -16 -39 -11
		mu 0 4 27 12 19 26
		f 4 40 41 42 43
		mu 0 4 35 28 37 36
		f 4 44 45 46 47
		mu 0 4 30 34 33 32
		f 4 -13 48 -47 49
		mu 0 4 21 12 32 33
		f 4 50 -28 -50 51
		mu 0 4 31 11 21 33
		f 4 52 53 -52 -46
		mu 0 4 34 29 31 33
		f 4 54 -44 55 -10
		mu 0 4 10 35 36 27
		f 4 56 -49 -40 -56
		mu 0 4 36 32 12 27
		f 4 57 -48 -57 -43
		mu 0 4 37 30 32 36
		f 4 58 59 60 61
		mu 0 4 38 42 41 40
		f 4 -45 62 -61 63
		mu 0 4 34 30 40 41
		f 4 64 -53 -64 65
		mu 0 4 39 29 34 41
		f 4 66 67 -66 -60
		mu 0 4 42 9 39 41
		f 4 68 -8 69 -42
		mu 0 4 28 43 44 37
		f 4 70 -63 -58 -70
		mu 0 4 44 40 30 37
		f 4 71 -62 -71 -7
		mu 0 4 45 38 40 44
		f 4 72 73 74 75
		mu 0 4 71 46 73 72
		f 4 76 77 78 79
		mu 0 4 48 61 60 59
		f 3 80 81 82
		mu 0 3 54 51 55
		f 5 83 84 85 86 87
		mu 0 5 50 1 5 52 53
		f 4 88 -83 89 -87
		mu 0 4 52 54 55 53
		f 4 90 91 92 93
		mu 0 4 56 47 57 58
		f 4 94 -88 95 -93
		mu 0 4 57 50 53 58
		f 6 -82 96 97 98 -79 99
		mu 0 6 55 51 4 49 59 60
		f 4 -96 -90 -100 100
		mu 0 4 58 53 55 60
		f 4 101 -94 -101 -78
		mu 0 4 61 56 58 60
		f 4 102 103 104 105
		mu 0 4 62 68 67 66
		f 4 -59 106 107 108
		mu 0 4 42 38 64 65
		f 4 109 -67 -109 110
		mu 0 4 63 9 42 65
		f 4 -108 111 -105 112
		mu 0 4 65 64 66 67
		f 5 -99 113 -111 -113 114
		mu 0 5 59 49 63 65 67
		f 4 115 -80 -115 -104
		mu 0 4 68 48 59 67
		f 5 116 117 118 119 -6
		mu 0 5 8 3 69 70 45
		f 4 120 -107 -72 -120
		mu 0 4 70 64 38 45
		f 4 121 -76 122 -119
		mu 0 4 69 71 72 70
		f 4 123 -112 -121 -123
		mu 0 4 72 66 64 70
		f 4 124 -106 -124 -75
		mu 0 4 73 62 66 72
		f 3 125 126 127
		mu 0 3 74 84 85
		f 4 128 129 130 131
		mu 0 4 80 76 82 81
		f 4 132 133 134 135
		mu 0 4 75 78 79 77
		f 4 136 -91 137 -134
		mu 0 4 78 47 56 79
		f 4 -77 138 -132 139
		mu 0 4 61 48 80 81
		f 4 -102 -140 140 -138
		mu 0 4 56 61 81 79
		f 4 141 -135 -141 -131
		mu 0 4 82 77 79 81
		f 3 142 -136 143
		mu 0 3 83 75 77
		f 5 144 145 -130 146 -127
		mu 0 5 84 86 82 76 85
		f 4 147 -144 -142 -146
		mu 0 4 86 83 77 82
		f 3 148 149 150
		mu 0 3 92 94 93
		f 4 151 152 153 154
		mu 0 4 88 91 90 89
		f 4 -103 155 -154 156
		mu 0 4 68 62 89 90
		f 4 -139 -116 -157 157
		mu 0 4 80 48 68 90
		f 4 158 -129 -158 -153
		mu 0 4 91 76 80 90
		f 4 159 -151 160 -74
		mu 0 4 46 92 93 73
		f 4 161 -156 -125 -161
		mu 0 4 93 89 62 73
		f 5 162 163 -155 -162 -150
		mu 0 5 94 87 88 89 93
		f 4 164 165 166 -3
		mu 0 4 95 98 97 96
		f 4 -152 167 -167 168
		mu 0 4 91 88 96 97
		f 4 -147 -159 -169 169
		mu 0 4 85 76 91 97
		f 4 170 -128 -170 -166
		mu 0 4 98 74 85 97
		f 4 171 -4 -168 -164
		mu 0 4 87 99 96 88;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".db" yes;
	setAttr ".bw" 4;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :initialShadingGroup;
	setAttr -s 7 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultShaderList1;
	setAttr -s 2 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :renderGlobalsList1;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "mentalRay";
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :defaultHardwareRenderGlobals;
	setAttr ".fn" -type "string" "im";
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "planarTrimmedSurfaceShape4.iog" ":initialShadingGroup.dsm" -na;
// End of mesh_one.ma