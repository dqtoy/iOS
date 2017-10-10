//Maya ASCII 2012 scene
//Name: mesh_awesome.ma
//Last modified: Wed, Dec 07, 2011 05:31:35 PM
//Codeset: UTF-8
requires maya "2012";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2012";
fileInfo "version" "2012 x64";
fileInfo "cutIdentifier" "201103110020-796618";
fileInfo "osv" "Mac OS X 10.7";
createNode transform -n "planarTrimmedSurface2";
	setAttr ".rp" -type "double3" -0.38197632701974271 0.22144921864367717 0 ;
	setAttr ".sp" -type "double3" -0.38197632701974271 0.22144921864367717 0 ;
createNode mesh -n "planarTrimmedSurfaceShape2" -p "planarTrimmedSurface2";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 275 ".uvst[0].uvsp";
	setAttr ".uvst[0].uvsp[0:249]" -type "float2" 0.99830675 0.15232342 0.34351328
		 0.22002605 0.97583318 0.17081603 0.3694011 0.14652885 0.82867163 0.52185917 0.85580701
		 0.31732285 0.34332442 0.22225007 0.54028696 0.70380163 0.52992553 0.54649121 0.97625363
		 0.036670983 0.98304796 0.92402053 0 0.45909813 0.21257161 1 0.18211742 0 1 0.056414809
		 0.84182763 0.5177142 0.016679307 0.5177142 0.28280404 0.5177142 0.28280404 0.0046389373
		 0.082911447 0.21301667 0.28280404 0.21301667 0.34394553 0.21301667 0.64140201 0.15742485
		 0.64140201 0.02120341 0.64140201 0.27344877 0.64140201 0.5177142 0.28280404 0.99510324
		 0.12548871 0.82241178 0.28280404 0.82241178 0.98303795 0.82241178 0.64140201 0.52663332
		 0.64140201 0.73694611 0.64140201 0.82241178 0.64140201 0.9700315 -0.84227657 0.33991194
		 -1.53099859 -0.0042344187 -1.34968293 0.95981646 -0.85258353 0.33176434 -1.71257603
		 0.60593146 -1.53443658 -0.0044127926 -1.24261451 0.46685123 -1.23921883 0.070810109
		 -0.17221491 0.045132689 -0.74138075 0.051971462 -1.24288404 0.470065 -1.23961031
		 0.47570258 -0.39918429 0.023981191 -0.45602328 0.45088819 -0.10775441 0.38927859
		 -0.10494363 0.41222927 -0.58449554 0.98324645 -1.51018584 0.93026745 -1.51018584
		 -0.00031608139 -1.69141257 0.5177142 -1.51018584 0.5177142 -1.61224937 0.21301667
		 -1.51018584 0.21301667 -1.61434674 0.82241178 -1.51018584 0.82241178 -0.43439192
		 0.19098152 -0.43439192 0.9654265 -0.99765784 0.5177142 -0.43439192 0.5177142 -0.77677429
		 0.5177142 -1.15158784 0.5177142 -1.15158784 0.3520343 -1.24044192 0.21301667 -1.056044102
		 0.21301667 -0.61448318 0.21301667 -0.43580166 0.21301667 -0.43439192 0.21301667 -0.79298991
		 0.057717774 -0.79298991 0.21301667 -0.79298991 0.47369787 -1.15158784 0.72201318
		 -1.22723365 0.82241178 -0.43439192 0.82241178 -0.66452384 0.82241178 -0.11541195
		 0.5177142 -0.14076927 0.21301667 -0.14746489 0.82241178 -1.79865849 0.52890831 -2.18372774
		 1.069102049 -2.17948246 1.069318175 -2.76558232 0.062056106 -2.97730541 0.51383507
		 -2.12265992 -0.042314224 -2.15238619 -0.056631964 -1.7941823 0.50994331 -2.25667191
		 0.48941547 -2.42969918 0.19463669 -2.25134897 0.47169179 -2.76141858 0.48637077 -2.46142888
		 0.73341113 -2.36185598 1.032967329 -2.36185598 -0.022383461 -2.36185598 0.27034795
		 -2.36185598 0.6302194 -2.97714162 0.5177142 -2.74640727 0.5177142 -2.83762145 0.21301667
		 -2.36185598 0.21301667 -2.39493895 0.21301667 -2.60116887 0.21301667 -2.73539567
		 0.039577998 -2.73539567 0.21301667 -2.73539567 0.43415135 -2.78994203 0.82241178
		 -2.36185598 0.82241178 -2.73539567 0.53163815 -2.73539567 0.82241178 -2.73539567
		 0.90840644 -1.7949121 0.5177142 -2.27781177 0.5177142 -1.98831654 0.17991662 -1.98831654
		 0.5177142 -1.98831654 0.21301667 -1.96830678 0.21301667 -1.98831654 0.81520313 -1.99309194
		 0.82241178 -3.57445431 0.12129701 -3.8221221 0.27644229 -3.62687182 0.28066972 -3.30473065
		 -0.091680862 -3.87132311 -0.028414248 -3.06215167 0.35119405 -3.016083717 0.11236803
		 -3.089295864 0.3765839 -3.040098667 0.61635476 -3.37526369 0.75761062 -3.55579209
		 0.51318115 -3.2570262 0.59378904 -3.94003987 0.47273463 -2.98574853 0.78505683 -3.67763615
		 1.12710929 -3.36068511 0.11171106 -3.35034966 0.21943542 -3.38320851 0.092933483
		 -3.66177368 0.27992159 -3.66177368 -0.064860031 -3.66177368 1.12524056 -3.66177368
		 0.3530601 -3.92450571 0.5177142 -3.66177368 0.5177142 -3.85110831 0.21301667 -3.66177368
		 0.21301667 -3.81162 0.82241178 -3.66177368 0.82241178 -3.55542731 0.5177142 -3.21469235
		 -0.045666788 -3.21469235 0.40802121 -3.59116888 0.21301667 -3.21469235 0.21301667
		 -3.3509388 0.21301667 -3.035283566 0.21301667 -3.21469235 0.59443349 -3.21469235
		 1.066049218 -3.21469235 0.82241178 -2.99760127 0.82241178 -4.00011062622 0.15232342
		 -4.65490341 0.22002605 -4.022583485 0.17081603 -4.62901688 0.14652885 -4.16974783
		 0.52185917 -4.14261055 0.31732288 -4.65509224 0.22224969 -4.46830702 0.54865682 -4.46849203
		 0.54648638 -4.45812702 0.70380163 -4.022163868 0.036670983 -4.015368938 0.92402059
		 -4.9984169 0.45909813 -4.78584528 1 -4.81629658 8.2499181e-11 -3.99841452 0.056414809
		 -4.73756742 0.99663824 -4.73756742 0.0036246756 -4.98173761 0.5177142 -4.73756742
		 0.5177142 -4.91550541 0.21301667 -4.73756742 0.21301667 -4.87292624 0.82241178 -4.73756742
		 0.82241178 -4.15658998 0.5177142 -4.37896967 0.15654825 -4.37896967 0.27099279 -4.37896967
		 0.5177142 -4.37896967 0.02018922 -4.6544714 0.21301667 -4.37896967 0.52719301 -4.37896967
		 0.73387748 -4.37896967 0.97156638 -4.37896967 0.82241178 -4.015378952 0.82241178
		 -6.70753431 0.20310263 -6.12398911 0.052186549 -6.4798255 -0.03129961 -5.1231389
		 0.33991194 -5.92445612 0.42771071 -5.62526178 -0.018336952 -6.28384304 0.27202326
		 -5.53664732 0.3037605 -5.10278749 0.94211352 -5.12652445 0.96190947 -5.80122423 0.77572829
		 -6.72110701 0.85967469 -6.48869085 0.94147336 -6.72111511 0.86487699 -6.72110701
		 0.24432914 -6.7211175 0.24113519 -5.81336164 0.25299141 -5.81336164 0.77518499 -5.81336164
		 0.5177142 -6.15918159 0.5177142 -6.35496998 0.5177142 -6.72110701 0.5177142 -6.53055763
		 0.00221275 -6.53055763 0.5177142 -6.53055763 0.21301667 -6.71335173 0.21301667 -6.040982246
		 0.21301667 -6.1719594 0.026932158 -6.1719594 0.21301667 -6.1719594 0.49177849 -6.53055763
		 0.93242455 -6.72110701 0.82241178 -6.53055763 0.82241178 -6.43818617 0.82241178 -5.11712885
		 0.5177142 -5.47390175 0.5177142 -5.6470108 0.5177142 -5.45476341 -0.01551942 -5.45476341
		 0.5177142 -5.78940296 0.21301667 -5.45476341 0.21301667 -5.19424677 0.21301667 -5.45476341
		 0.58766544 -5.10682964 0.82241178 -5.39053917 0.82241178 -6.91429186 -0.018336952
		 -7.86000872 -0.014722398 -7.074142933 1.00014543533 -6.82035732 0.46771035 -7.96494961
		 0.45935827 -7.14965677 -0.023949577 -7.23714209 0.29211199 -6.93848324 -0.036826205
		 -7.25356436 0.45838952 -7.50971317 0.43864098 -7.30275965 0.743294;
	setAttr ".uvst[0].uvsp[250:274]" -7.53028536 0.45449069 -7.3289628 0.76178342
		 -7.23415565 0.47461617 -6.84433079 0.3391428 -6.84433079 0.53704751 -6.84433079 0.5177142
		 -7.94252777 0.5177142 -7.52000713 0.5177142 -7.24472332 0.5177142 -7.59140968 0.5177142
		 -7.59140968 0.035933413 -7.92030907 0.21301667 -7.59140968 0.21301667 -6.86901474
		 0.21301667 -7.54967642 0.21301667 -7.204669 0.21301667 -7.21787024 0.28397855 -7.21787024
		 0.5177142 -7.59140968 0.98177016 -7.78075504 0.82241178 -7.59140968 0.82241178 -6.97266293
		 0.82241178 -7.21787024 0.82241178 -7.21787024 0.99500501 -6.83563614 0.5177142;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".bnr" 0;
	setAttr -s 275 ".pt";
	setAttr ".pt[0:165]" -type "float3"  -35.501343 21.31842 2.7357979 -35.501343 
		20.81151 2.2288876 -35.501343 21.17996 2.5973377 -35.501343 21.361818 2.7791958 -35.501343 
		18.551596 -0.03102684 -35.501343 20.083019 1.5003967 -35.501343 20.794859 2.2122364 
		-35.501343 17.189337 -1.3932858 -35.501343 18.367168 -0.2154541 -35.501343 22.184345 
		3.6017227 -35.501343 15.540491 -3.0421314 -35.501343 19.021505 0.43888283 -35.501343 
		14.97161 -3.6110125 -35.501343 22.458883 3.8762608 -35.501343 22.036518 3.4538956 
		-35.501343 18.582628 5.7220459e-06 -35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 
		7.6293945e-06 -35.501343 22.424179 3.8415565 -35.501343 20.863993 2.2813702 -35.501343 
		20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 21.280228 2.6976051 
		-35.501343 22.300156 3.7175331 -35.501343 20.411518 1.8288956 -35.501343 18.58263 
		7.6293945e-06 -35.501343 15.008274 -3.5743484 -35.501343 16.301268 -2.2813549 -35.501343 
		16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 18.51585 -0.066772461 
		-35.501343 16.941174 -1.641449 -35.501343 16.301268 -2.2813549 -35.501343 15.195993 
		-3.3866291 -35.501343 19.913889 1.3312664 -35.501343 22.490616 3.9079933 -35.501343 
		15.272477 -3.3101454 -35.501343 19.974915 1.392292 -35.501343 17.922121 -0.66050148 
		-35.501343 22.491951 3.9093285 -35.501343 18.963457 0.38083458 -35.501343 21.928736 
		3.3461132 -35.501343 22.120991 3.5383682 -35.501343 22.06979 3.4871674 -35.501343 
		18.939394 0.35677147 -35.501343 18.897181 0.31455803 -35.501343 22.279343 3.6967201 
		-35.501343 19.082975 0.50035286 -35.501343 19.544266 0.96164322 -35.501343 19.372427 
		0.78980446 -35.501343 15.097028 -3.4855947 -35.501343 15.493719 -3.0889034 -35.501343 
		22.461279 3.8786564 -35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 7.6293945e-06 
		-35.501343 20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 16.301268 
		-2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 21.028976 2.4463539 -35.501343 
		15.230473 -3.35215 -35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 7.6293945e-06 
		-35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 7.6293945e-06 -35.501343 19.823126 
		1.2405033 -35.501343 20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 
		20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 20.863993 2.2813702 
		-35.501343 22.026762 3.4441395 -35.501343 20.863993 2.2813702 -35.501343 18.912193 
		0.32957077 -35.501343 17.052982 -1.5296402 -35.501343 16.301268 -2.2813549 -35.501343 
		16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 18.58263 7.6293945e-06 
		-35.501343 20.863993 2.2813702 -35.501343 16.301268 -2.2813549 -35.501343 18.498816 
		-0.083806992 -35.501343 14.454223 -4.1283998 -35.501343 14.452604 -4.1300182 -35.501343 
		21.99428 3.4116573 -35.501343 18.611673 0.029050827 -35.501343 22.775732 4.1931095 
		-35.501343 22.882933 4.3003101 -35.501343 18.640814 0.058191299 -35.501343 18.794512 
		0.21188927 -35.501343 21.001514 2.4188919 -35.501343 18.927214 0.34459114 -35.501343 
		18.817308 0.2346859 -35.501343 16.967657 -1.6149654 -35.501343 14.724774 -3.8578482 
		-35.501343 22.626505 4.0438824 -35.501343 20.434736 1.8521137 -35.501343 17.740269 
		-0.84235382 -35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 7.6293945e-06 -35.501343 
		20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 20.863993 2.2813702 
		-35.501343 20.863993 2.2813702 -35.501343 22.162529 3.5799065 -35.501343 20.863993 
		2.2813702 -35.501343 19.20829 0.62566757 -35.501343 16.301268 -2.2813549 -35.501343 
		16.301268 -2.2813549 -35.501343 18.478376 -0.10424614 -35.501343 16.301268 -2.2813549 
		-35.501343 15.657399 -2.9252234 -35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 
		7.6293945e-06 -35.501343 21.111822 2.5291996 -35.501343 18.58263 7.6293945e-06 -35.501343 
		20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 16.35524 -2.2273827 
		-35.501343 16.301268 -2.2813549 -35.501343 21.550724 2.9681015 -35.501343 20.389105 
		1.8064823 -35.501343 20.357454 1.7748318 -35.501343 23.145355 4.5627327 -35.501343 
		22.671659 4.0890369 -35.501343 19.829416 1.2467937 -35.501343 21.617579 3.034956 
		-35.501343 19.639315 1.0566921 -35.501343 17.844078 -0.73854446 -35.501343 16.786449 
		-1.7961731 -35.501343 18.616571 0.033948898 -35.501343 18.013033 -0.56958961 -35.501343 
		18.919405 0.33678246 -35.501343 16.580956 -2.001667 -35.501343 14.01989 -4.5627327 
		-35.501343 21.622498 3.039875 -35.501343 20.815933 2.2333107 -35.501343 21.763092 
		3.1804695 -35.501343 20.363054 1.7804317 -35.501343 22.944538 4.3619156 -35.501343 
		14.033896 -4.5487261 -35.501343 19.815445 1.2328224 -35.501343 18.58263 7.6293945e-06 
		-35.501343 18.58263 7.6293945e-06 -35.501343 20.863993 2.2813702 -35.501343 20.863993 
		2.2813702 -35.501343 16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 
		18.58263 7.6293945e-06 -35.501343 22.800833 4.2182102 -35.501343 19.403934 0.82131195 
		-35.501343 20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 20.863993 
		2.2813702 -35.501343 20.863995 2.2813721 -35.501343 18.008209 -0.5744133 -35.501343 
		14.47708 -4.1055422 -35.501343 16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 
		-35.501343 21.31842 2.7357979 -35.501343 20.81151 2.2288876 -35.501343 21.17996 2.5973377 
		-35.501343 21.361818 2.7791958 -35.501343 18.551596 -0.03102684 -35.501343 20.083019 
		1.5003967 -35.501343 20.794863 2.2122402;
	setAttr ".pt[166:274]" -35.501343 18.350952 -0.23167038 -35.501343 18.367205 
		-0.21541786 -35.501343 17.189337 -1.3932858 -35.501343 22.184345 3.6017227 -35.501343 
		15.540491 -3.0421314 -35.501343 19.021505 0.43888283 -35.501343 14.97161 -3.6110125 
		-35.501343 22.458883 3.8762608 -35.501343 22.036518 3.4538956 -35.501343 14.996781 
		-3.5858412 -35.501343 22.431774 3.8491516 -35.501343 18.58263 7.6293945e-06 -35.501343 
		18.58263 7.6293945e-06 -35.501343 20.863993 2.2813702 -35.501343 20.863993 2.2813702 
		-35.501343 16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 18.582628 
		5.7220459e-06 -35.501343 21.286791 2.7041683 -35.501343 20.429907 1.8472843 -35.501343 
		18.58263 7.6293945e-06 -35.501343 22.307749 3.7251263 -35.501343 20.863993 2.2813702 
		-35.501343 18.51166 -0.070962906 -35.501343 16.964149 -1.6184731 -35.501343 15.184502 
		-3.3981209 -35.501343 16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 
		20.938221 2.3555984 -35.501343 22.068176 3.4855537 -35.501343 22.693264 4.1106415 
		-35.501343 19.913889 1.3312664 -35.501343 19.256504 0.67388153 -35.501343 22.596128 
		4.0135059 -35.501343 20.42219 1.8395672 -35.501343 20.184566 1.601944 -35.501343 
		15.405025 -3.177598 -35.501343 15.256863 -3.3257599 -35.501343 16.650867 -1.9317551 
		-35.501343 16.022268 -2.5603542 -35.501343 15.409828 -3.1727943 -35.501343 15.983316 
		-2.5993061 -35.501343 20.629547 2.0469246 -35.501343 20.65346 2.070837 -35.501343 
		20.56469 1.9820671 -35.501343 16.6549 -1.9277229 -35.501343 18.58263 7.6293945e-06 
		-35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 
		7.6293945e-06 -35.501343 22.442345 3.8597221 -35.501343 18.58263 7.6293945e-06 -35.501343 
		20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 20.863993 2.2813702 
		-35.501343 22.257263 3.6746407 -35.501343 20.863993 2.2813702 -35.501343 18.776819 
		0.1941967 -35.501343 15.477568 -3.1050549 -35.501343 16.301268 -2.2813549 -35.501343 
		16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 18.58263 7.6293945e-06 
		-35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 7.6293945e-06 -35.501343 22.575111 
		3.9924889 -35.501343 18.58263 7.6293945e-06 -35.501343 20.863993 2.2813702 -35.501343 
		20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 18.058884 -0.52373886 
		-35.501343 16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 22.596207 
		4.0135841 -35.501343 22.569143 3.9865208 -35.501343 14.970522 -3.6121006 -35.501343 
		18.957024 0.37440109 -35.501343 19.019558 0.43693542 -35.501343 22.63826 4.0556374 
		-35.501343 20.271742 1.6891193 -35.501343 22.734646 4.1520233 -35.501343 19.026812 
		0.44418907 -35.501343 19.174675 0.59205246 -35.501343 16.893646 -1.6889763 -35.501343 
		19.056004 0.47338104 -35.501343 16.755211 -1.8274117 -35.501343 18.905317 0.32269478 
		-35.501343 19.919647 1.3370247 -35.501343 18.437876 -0.14474678 -35.501343 18.58263 
		7.6293945e-06 -35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 7.6293945e-06 
		-35.501343 18.58263 7.6293945e-06 -35.501343 18.58263 7.6293945e-06 -35.501343 22.189867 
		3.6072445 -35.501343 20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 
		20.863993 2.2813702 -35.501343 20.863993 2.2813702 -35.501343 20.863993 2.2813702 
		-35.501343 20.33268 1.7500572 -35.501343 18.58263 7.6293945e-06 -35.501343 15.108103 
		-3.4745197 -35.501343 16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 
		16.301268 -2.2813549 -35.501343 16.301268 -2.2813549 -35.501343 15.009009 -3.5736132 
		-35.501343 18.58263 7.6293945e-06;
	setAttr -s 275 ".vt";
	setAttr ".vt[0:165]"  63.013519287 -21.096971512 0 58.93724442 -20.59006119 0
		 62.87361526 -20.95851135 0 59.098403931 -21.14036942 0 61.95749283 -18.33014679 0
		 62.12637329 -19.86157036 0 58.93606567 -20.57341003 0 60.16221619 -16.96788788 0
		 60.09771347 -18.14571953 0 62.87623215 -21.96289635 0 62.9186058 -15.31904221 0 56.79877853 -18.80005646 0
		 58.12209702 -14.75016117 0 57.93251038 -22.23743439 0 63.024047852 -21.8150692 0
		 62.039394379 -18.36117935 0 56.90261459 -18.36118126 0 58.55931473 -18.36118126 0
		 58.55931473 -22.20273018 0 57.31492615 -20.64254379 0 58.55931473 -20.64254379 0
		 58.93993759 -20.64254379 0 60.79168701 -21.058778763 0 60.79168701 -22.078706741 0
		 60.79168701 -20.1900692 0 60.79168701 -18.36118126 0 58.55931473 -14.78682518 0 57.57998276 -16.079818726 0
		 58.55931473 -16.079818726 0 62.91846848 -16.079818726 0 60.79168701 -18.29440117 0
		 60.79168701 -16.71972466 0 60.79168701 -16.079818726 0 60.79168701 -14.97454453 0
		 51.55537033 -19.69244003 0 47.2678833 -22.26916695 0 48.39662552 -15.051028252 0
		 51.49120712 -19.75346565 0 46.13751221 -17.70067215 0 47.24648285 -22.27050209 0
		 49.063156128 -18.74200821 0 49.084293365 -21.70728683 0 55.7266922 -21.89954185 0
		 52.18347549 -21.84834099 0 49.061496735 -18.7179451 0 49.081855774 -18.67573166 0
		 54.31374359 -22.057893753 0 53.95990753 -18.86152649 0 56.12797928 -19.32281685 0
		 56.14547348 -19.15097809 0 53.16012955 -14.87557888 0 47.39744949 -15.2722702 0 47.39744949 -22.23983002 0
		 46.26926041 -18.36118126 0 47.39744949 -18.36118126 0 46.76207352 -20.64254379 0
		 47.39744949 -20.64254379 0 46.74901581 -16.079818726 0 47.39744949 -16.079818726 0
		 54.094566345 -20.80752754 0 54.094566345 -15.0090236664 0 50.58807755 -18.36118126 0
		 54.094566345 -18.36118126 0 51.9631424 -18.36118126 0 49.62982178 -18.36118126 0
		 49.62982178 -19.60167694 0 49.07667923 -20.64254379 0 50.22460938 -20.64254379 0
		 52.97344971 -20.64254379 0 54.085792542 -20.64254379 0 54.094566345 -20.64254379 0
		 51.86219406 -21.80531311 0 51.86219406 -20.64254379 0 51.86219406 -18.6907444 0 49.62982178 -16.83153343 0
		 49.15890503 -16.079818726 0 54.094566345 -16.079818726 0 52.66193008 -16.079818726 0
		 56.080307007 -18.36118126 0 55.92245102 -20.64254379 0 55.88076782 -16.079818726 0
		 45.60162354 -18.27736664 0 43.20446014 -14.23277378 0 43.23088837 -14.2311554 0 39.5822525 -21.77283096 0
		 38.26420593 -18.39022446 0 43.58462524 -22.55428314 0 43.39957047 -22.66148376 0
		 45.6294899 -18.41936493 0 42.7503624 -18.5730629 0 41.67322159 -20.78006554 0 42.78346252 -18.70576477 0
		 39.60818481 -18.59585953 0 41.47569275 -16.74620819 0 42.095561981 -14.50332546 0
		 42.095561981 -22.405056 0 42.095561981 -20.21328735 0 42.095561981 -17.51881981 0
		 38.2652359 -18.36118126 0 39.70162201 -18.36118126 0 39.13378906 -20.64254379 0 42.095561981 -20.64254379 0
		 41.88961029 -20.64254379 0 40.60577393 -20.64254379 0 39.77018738 -21.94108009 0
		 39.77017212 -20.64254379 0 39.77017212 -18.9868412 0 39.43060684 -16.079818726 0
		 42.095561981 -16.079818726 0 39.77017212 -18.25692749 0 39.77017212 -16.079818726 0
		 39.77017212 -15.43595028 0 45.62494659 -18.36118126 0 42.61875916 -18.36118126 0
		 44.42095184 -20.89037323 0 44.42095184 -18.36118126 0 44.42095184 -20.64254379 0
		 44.54551697 -20.64254379 0 44.42095184 -16.13379097 0 44.39122391 -16.079818726 0
		 34.54679871 -21.32927513 0 33.0049972534 -20.16765594 0 34.22048187 -20.1360054 0
		 36.22590256 -22.92390633 0 32.69879532 -22.45021057 0 37.73602676 -19.60796738 0
		 38.022899628 -21.39612961 0 37.5670433 -19.41786575 0 37.8733139 -17.62262917 0 35.78681564 -16.56500053 0
		 34.66300964 -18.39512253 0 36.52287674 -17.79158401 0 32.2709198 -18.69795609 0 38.21165466 -16.35950661 0
		 33.90446091 -13.79844093 0 35.87757111 -21.40104866 0 35.94190979 -20.59448433 0
		 35.73735428 -21.54164314 0 34.0032081604 -20.14160538 0 34.0032081604 -22.72308922 0
		 34.0032081604 -13.81244755 0 34.0032081604 -19.59399605 0 32.36763 -18.36118126 0
		 34.0032081604 -18.36118126 0 32.82454681 -20.64254379 0 34.0032081604 -20.64254379 0
		 33.070373535 -16.079818726 0 34.0032081604 -16.079818726 0 34.66524506 -18.36118126 0
		 36.7864151 -22.57938385 0 36.7864151 -19.18248558 0 34.44274521 -20.64254379 0 36.7864151 -20.64254379 0
		 35.93824387 -20.64254379 0 37.90327454 -20.6425457 0 36.7864151 -17.78676033 0 36.7864151 -14.25563145 0
		 36.7864151 -16.079818726 0 38.13787079 -16.079818726 0 31.89696693 -21.096971512 0
		 27.82069778 -20.59006119 0 31.75706673 -20.95851135 0 27.98184967 -21.14036942 0
		 30.84092712 -18.33014679 0 31.0098209381 -19.86157036 0 27.81951714 -20.57341385 0;
	setAttr ".vt[166:274]" 28.98231316 -18.12950325 0 28.98115921 -18.14575577 0
		 29.045686722 -16.96788788 0 31.75967979 -21.96289635 0 31.80205727 -15.31904221 0
		 25.68223 -18.80005646 0 27.0055484772 -14.75016117 0 26.815979 -22.23743439 0 31.90751457 -21.8150692 0
		 27.3060894 -14.77533245 0 27.3060894 -22.21032524 0 25.78606224 -18.36118126 0 27.3060894 -18.36118126 0
		 26.1983757 -20.64254379 0 27.3060894 -20.64254379 0 26.46344376 -16.079818726 0 27.3060894 -16.079818726 0
		 30.92284012 -18.36117935 0 29.53846359 -21.065341949 0 29.53846359 -20.20845795 0
		 29.53846359 -18.36118126 0 29.53846359 -22.086299896 0 27.82338905 -20.64254379 0
		 29.53846359 -18.29021072 0 29.53846359 -16.74270058 0 29.53846359 -14.96305275 0
		 29.53846359 -16.079818726 0 31.80191803 -16.079818726 0 15.04249382 -20.71677208 0
		 18.67522621 -21.84672737 0 16.46004677 -22.47181511 0 24.90579987 -19.69244003 0
		 19.91737747 -19.035055161 0 21.77994537 -22.37467957 0 17.68009186 -20.20074081 0
		 22.33159637 -19.9631176 0 25.032444 -15.18357563 0 24.88472557 -15.035413742 0 20.68453026 -16.42941856 0
		 14.95798969 -15.8008194 0 16.40485764 -15.18837929 0 14.95798969 -15.76186752 0 14.95795631 -20.40809822 0
		 14.95793533 -20.43201065 0 20.60897064 -20.34324074 0 20.60897255 -16.4334507 0 20.60897064 -18.36118126 0
		 18.45614433 -18.36118126 0 17.23730659 -18.36118126 0 14.95799923 -18.36118126 0
		 16.14422417 -22.22089577 0 16.14422417 -18.36118126 0 16.14422417 -20.64254379 0
		 15.0062789917 -20.64254379 0 19.19196701 -20.64254379 0 18.37659836 -22.035814285 0
		 18.37659836 -20.64254379 0 18.37659836 -18.55537033 0 16.14422417 -15.25611877 0
		 14.9579916 -16.079818726 0 16.14422417 -16.079818726 0 16.71926308 -16.079818726 0
		 24.94321442 -18.36118126 0 22.72220421 -18.36118126 0 21.64455223 -18.36118126 0
		 22.84134483 -22.35366249 0 22.84134483 -18.36118126 0 20.75812149 -20.64254379 0
		 22.84134483 -20.64254379 0 24.46313477 -20.64254379 0 22.84134483 -17.83743477 0
		 25.0073299408 -16.079818726 0 23.24115944 -16.079818726 0 13.75537014 -22.37475777 0
		 7.86801863 -22.3476944 0 12.760252 -14.74907303 0 14.34014606 -18.73557472 0 7.21468163 -18.79810905 0
		 12.29015636 -22.41681099 0 11.7455368 -20.050292969 0 13.60477448 -22.51319695 0
		 11.64330387 -18.8053627 0 10.048706055 -18.95322609 0 11.33705044 -16.67219734 0
		 9.92068195 -18.83455467 0 11.17392826 -16.53376198 0 11.7641449 -18.68386841 0 14.19089794 -19.69819832 0
		 14.19089794 -18.21642685 0 14.19089794 -18.36118126 0 7.3543129 -18.36118126 0 9.98462391 -18.36118126 0
		 11.69834232 -18.36118126 0 9.54012108 -18.36118126 0 9.54012012 -21.96841812 0 7.49263144 -20.64254379 0
		 9.54012108 -20.64254379 0 14.03723526 -20.64254379 0 9.79992294 -20.64254379 0 11.94769192 -20.64254379 0
		 11.86550999 -20.11123085 0 11.86550903 -18.36118126 0 9.54012108 -14.8866539 0 8.36139297 -16.079818726 0
		 9.54012108 -16.079818726 0 13.39199543 -16.079818726 0 11.86550903 -16.079818726 0
		 11.86550903 -14.78756046 0 14.24502373 -18.36118126 0;
	setAttr -s 379 ".ed";
	setAttr ".ed[0:165]"  29 10 0 10 33 0 33 32 1 32 29 1 24 5 0 5 15 0 15 25 1
		 25 24 1 17 16 1 16 11 0 11 19 0 19 20 1 20 17 1 19 13 0 13 18 0 18 20 1 0 2 0 2 22 0
		 22 23 1 23 9 0 9 14 0 14 0 0 22 3 0 3 21 0 21 20 1 18 23 0 21 1 0 1 6 0 6 24 0 25 17 1
		 26 12 0 12 27 0 27 28 1 28 26 1 27 16 0 17 28 1 15 4 0 4 30 0 30 25 1 30 8 0 8 7 0
		 7 31 0 31 32 1 32 28 1 33 26 0 31 29 0 80 60 0 60 76 1 76 80 1 51 57 0 57 58 1 58 51 1
		 53 55 0 55 56 1 56 54 1 54 53 1 55 39 0 39 35 0 35 52 0 52 56 1 57 38 0 38 53 0 54 58 1
		 60 50 0 50 77 0 77 76 1 72 68 1 68 47 0 47 69 0 69 70 1 70 62 1 62 63 1 63 73 0 73 72 1
		 64 54 1 56 66 1 66 40 0 40 44 0 44 45 0 45 65 0 65 64 1 52 41 0 41 66 0 71 43 0 43 68 0
		 72 71 1 67 71 0 72 67 1 34 37 0 37 61 0 61 64 1 65 67 0 73 34 0 75 36 0 36 51 0 58 75 1
		 74 75 0 64 74 1 62 76 1 77 63 0 61 74 0 79 48 0 48 49 0 49 78 0 78 62 1 70 79 1 59 46 0
		 46 42 0 42 79 0 70 59 1 78 80 0 69 59 0 81 118 0 118 115 1 115 112 1 112 81 0 94 111 0
		 111 110 1 110 108 1 108 94 1 105 103 1 103 106 0 106 105 1 104 95 0 95 101 1 101 102 1
		 102 90 0 90 103 0 105 104 1 100 84 0 84 104 0 105 100 1 98 85 0 85 100 0 106 92 0
		 92 99 0 99 98 1 109 93 0 93 97 0 97 108 1 110 109 1 107 98 0 99 109 0 110 107 1 111 107 0
		 117 88 0 88 112 0 115 116 1 116 117 1 96 101 1 101 116 1 115 113 1 113 89 0 89 91 0
		 91 96 0 95 87 0 87 86 0 86 114 0 114 116 1 114 117 0 119 83 0 83 82 0 82 94 0 108 119 1
		 118 119 0 97 113 0;
	setAttr ".ed[166:331]" 96 102 0 158 156 0 156 157 1 157 158 1 140 134 0 134 146 0
		 146 147 1 147 140 1 138 121 0 121 144 0 144 145 1 145 138 1 144 124 0 124 139 0 139 145 1
		 146 142 0 142 143 1 143 147 1 154 125 0 125 127 0 127 150 0 150 152 1 152 154 1 151 122 0
		 122 138 0 145 151 1 120 151 0 139 123 0 123 149 0 149 152 1 152 153 1 153 135 0 135 137 0
		 137 120 0 149 126 0 126 154 0 156 140 0 147 157 1 148 129 0 129 131 0 131 155 0 155 157 1
		 143 148 1 155 128 0 128 133 0 133 158 0 142 132 0 132 141 0 141 143 1 150 130 0 130 148 0
		 141 136 0 136 153 0 191 192 1 192 193 1 193 170 0 170 191 0 175 172 0 172 181 0 181 182 1
		 182 175 1 177 171 0 171 179 0 179 180 1 180 178 1 178 177 1 179 173 0 173 176 0 176 180 1
		 181 177 0 178 182 1 186 185 1 185 164 0 164 183 0 183 186 1 188 160 0 160 165 0 165 185 0
		 186 178 1 180 188 1 184 162 0 162 188 0 176 187 0 187 184 1 159 161 0 161 184 0 187 169 0
		 169 174 0 174 159 0 191 175 0 182 192 1 189 167 0 167 166 0 166 168 0 168 190 0 190 192 1
		 186 189 1 183 163 0 163 189 0 190 193 0 237 202 0 202 203 0 203 238 0 238 237 1 227 206 0
		 206 224 0 224 226 1 226 227 1 220 198 0 198 210 0 210 212 1 212 213 1 213 223 0 223 222 1
		 222 220 1 218 217 1 217 215 1 215 208 0 208 209 0 209 219 0 219 218 1 194 216 0 216 218 1
		 219 194 0 221 195 0 195 220 0 222 221 1 216 196 0 196 221 0 222 218 1 223 200 0 200 214 0
		 214 217 1 224 207 0 207 205 0 205 225 0 225 226 1 225 215 0 217 226 1 212 211 1 211 213 0
		 214 227 0 235 197 0 197 228 0 228 232 1 232 234 1 234 235 1 210 233 0 233 234 1 232 229 1
		 229 201 0 201 230 0 230 212 1 233 199 0 199 231 0 231 234 1 231 235 0 236 229 0 232 236 1
		 228 237 0 238 236 0 230 204 0 204 211 0 274 254 0 254 255 1 255 274 1;
	setAttr ".ed[332:378]" 271 241 0 241 273 0 273 272 1 272 271 1 263 253 0 253 255 1
		 255 267 1 267 266 1 266 265 0 265 263 1 259 256 1 256 243 0 243 261 0 261 262 1 262 259 1
		 261 240 0 240 260 0 260 262 1 239 263 0 265 244 0 244 246 0 246 239 0 264 262 1 260 264 0
		 257 259 1 264 245 0 245 266 0 267 258 1 258 252 0 252 247 0 247 248 0 248 250 0 250 257 0
		 268 269 0 269 270 1 270 268 1 269 256 0 259 270 1 254 271 0 272 267 1 272 270 1 257 251 0
		 251 249 0 249 258 0 273 268 0 253 242 0 242 274 0;
	setAttr -s 109 ".fc[0:108]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 29 10 33 32
		f 4 4 5 6 7
		mu 0 4 24 5 15 25
		f 5 8 9 10 11 12
		mu 0 5 17 16 11 19 20
		f 4 13 14 15 -12
		mu 0 4 19 13 18 20
		f 6 16 17 18 19 20 21
		mu 0 6 0 2 22 23 9 14
		f 6 22 23 24 -16 25 -19
		mu 0 6 22 3 21 20 18 23
		f 7 26 27 28 -8 29 -13 -25
		mu 0 7 21 1 6 24 25 17 20
		f 4 30 31 32 33
		mu 0 4 26 12 27 28
		f 4 34 -9 35 -33
		mu 0 4 27 16 17 28
		f 4 36 37 38 -7
		mu 0 4 15 4 30 25
		f 8 39 40 41 42 43 -36 -30 -39
		mu 0 8 30 8 7 31 32 28 17 25
		f 4 44 -34 -44 -3
		mu 0 4 33 26 28 32
		f 3 -43 45 -4
		mu 0 3 32 31 29
		f 3 46 47 48
		mu 0 3 80 60 76
		f 3 49 50 51
		mu 0 3 51 57 58
		f 4 52 53 54 55
		mu 0 4 53 55 56 54
		f 5 56 57 58 59 -54
		mu 0 5 55 39 35 52 56
		f 5 60 61 -56 62 -51
		mu 0 5 57 38 53 54 58
		f 4 -48 63 64 65
		mu 0 4 76 60 50 77
		f 8 66 67 68 69 70 71 72 73
		mu 0 8 72 68 47 69 70 62 63 73
		f 8 74 -55 75 76 77 78 79 80
		mu 0 8 64 54 56 66 40 44 45 65
		f 4 -60 81 82 -76
		mu 0 4 56 52 41 66
		f 4 83 84 -67 85
		mu 0 4 71 43 68 72
		f 3 86 -86 87
		mu 0 3 67 71 72
		f 8 88 89 90 -81 91 -88 -74 92
		mu 0 8 34 37 61 64 65 67 72 73
		f 4 93 94 -52 95
		mu 0 4 75 36 51 58
		f 5 96 -96 -63 -75 97
		mu 0 5 74 75 58 54 64
		f 4 98 -66 99 -72
		mu 0 4 62 76 77 63
		f 3 100 -98 -91
		mu 0 3 61 74 64
		f 6 101 102 103 104 -71 105
		mu 0 6 79 48 49 78 62 70
		f 5 106 107 108 -106 109
		mu 0 5 59 46 42 79 70
		f 4 110 -49 -99 -105
		mu 0 4 78 80 76 62
		f 3 -70 111 -110
		mu 0 3 70 69 59
		f 4 112 113 114 115
		mu 0 4 81 118 115 112
		f 4 116 117 118 119
		mu 0 4 94 111 110 108
		f 3 120 121 122
		mu 0 3 105 103 106
		f 7 123 124 125 126 127 -121 128
		mu 0 7 104 95 101 102 90 103 105
		f 4 129 130 -129 131
		mu 0 4 100 84 104 105
		f 7 132 133 -132 -123 134 135 136
		mu 0 7 98 85 100 105 106 92 99
		f 5 137 138 139 -119 140
		mu 0 5 109 93 97 108 110
		f 5 141 -137 142 -141 143
		mu 0 5 107 98 99 109 110
		f 3 144 -144 -118
		mu 0 3 111 107 110
		f 5 145 146 -115 147 148
		mu 0 5 117 88 112 115 116
		f 7 149 150 -148 151 152 153 154
		mu 0 7 96 101 116 115 113 89 91
		f 6 -125 155 156 157 158 -151
		mu 0 6 101 95 87 86 114 116
		f 3 159 -149 -159
		mu 0 3 114 117 116
		f 5 160 161 162 -120 163
		mu 0 5 119 83 82 94 108
		f 6 164 -164 -140 165 -152 -114
		mu 0 6 118 119 108 97 113 115
		f 3 -150 166 -126
		mu 0 3 101 96 102
		f 3 167 168 169
		mu 0 3 158 156 157
		f 4 170 171 172 173
		mu 0 4 140 134 146 147
		f 4 174 175 176 177
		mu 0 4 138 121 144 145
		f 4 178 179 180 -177
		mu 0 4 144 124 139 145
		f 4 181 182 183 -173
		mu 0 4 146 142 143 147
		f 5 184 185 186 187 188
		mu 0 5 154 125 127 150 152
		f 4 189 190 -178 191
		mu 0 4 151 122 138 145
		f 10 192 -192 -181 193 194 195 196 197 198 199
		mu 0 10 120 151 145 139 123 149 152 153 135 137
		f 4 200 201 -189 -196
		mu 0 4 149 126 154 152
		f 4 -169 202 -174 203
		mu 0 4 157 156 140 147
		f 7 204 205 206 207 -204 -184 208
		mu 0 7 148 129 131 155 157 147 143
		f 5 209 210 211 -170 -208
		mu 0 5 155 128 133 158 157
		f 4 -183 212 213 214
		mu 0 4 143 142 132 141
		f 8 -188 215 216 -209 -215 217 218 -197
		mu 0 8 152 150 130 148 143 141 136 153
		f 4 219 220 221 222
		mu 0 4 191 192 193 170
		f 4 223 224 225 226
		mu 0 4 175 172 181 182
		f 5 227 228 229 230 231
		mu 0 5 177 171 179 180 178
		f 4 232 233 234 -230
		mu 0 4 179 173 176 180
		f 4 235 -232 236 -226
		mu 0 4 181 177 178 182
		f 4 237 238 239 240
		mu 0 4 186 185 164 183
		f 7 241 242 243 -238 244 -231 245
		mu 0 7 188 160 165 185 186 178 180
		f 6 246 247 -246 -235 248 249
		mu 0 6 184 162 188 180 176 187
		f 6 250 251 -250 252 253 254
		mu 0 6 159 161 184 187 169 174
		f 4 -220 255 -227 256
		mu 0 4 192 191 175 182
		f 9 257 258 259 260 261 -257 -237 -245 262
		mu 0 9 189 167 166 168 190 192 182 178 186
		f 4 263 264 -263 -241
		mu 0 4 183 163 189 186
		f 3 -221 -262 265
		mu 0 3 193 192 190
		f 4 266 267 268 269
		mu 0 4 237 202 203 238
		f 4 270 271 272 273
		mu 0 4 227 206 224 226
		f 7 274 275 276 277 278 279 280
		mu 0 7 220 198 210 212 213 223 222
		f 6 281 282 283 284 285 286
		mu 0 6 218 217 215 208 209 219
		f 4 287 288 -287 289
		mu 0 4 194 216 218 219
		f 4 290 291 -281 292
		mu 0 4 221 195 220 222
		f 5 293 294 -293 295 -289
		mu 0 5 216 196 221 222 218
		f 6 296 297 298 -282 -296 -280
		mu 0 6 223 200 214 217 218 222
		f 5 299 300 301 302 -273
		mu 0 5 224 207 205 225 226
		f 4 303 -283 304 -303
		mu 0 4 225 215 217 226
		f 3 305 306 -278
		mu 0 3 212 211 213
		f 4 307 -274 -305 -299
		mu 0 4 214 227 226 217
		f 5 308 309 310 311 312
		mu 0 5 235 197 228 232 234
		f 8 313 314 -312 315 316 317 318 -277
		mu 0 8 210 233 234 232 229 201 230 212
		f 4 319 320 321 -315
		mu 0 4 233 199 231 234
		f 3 322 -313 -322
		mu 0 3 231 235 234
		f 3 323 -316 324
		mu 0 3 236 229 232
		f 5 325 -270 326 -325 -311
		mu 0 5 228 237 238 236 232
		f 4 327 328 -306 -319
		mu 0 4 230 204 211 212
		f 3 329 330 331
		mu 0 3 274 254 255
		f 4 332 333 334 335
		mu 0 4 271 241 273 272
		f 6 336 337 338 339 340 341
		mu 0 6 263 253 255 267 266 265
		f 5 342 343 344 345 346
		mu 0 5 259 256 243 261 262
		f 4 347 348 349 -346
		mu 0 4 261 240 260 262
		f 5 350 -342 351 352 353
		mu 0 5 239 263 265 244 246
		f 3 354 -350 355
		mu 0 3 264 262 260
		f 12 356 -347 -355 357 358 -340 359 360 361 362 363 364
		mu 0 12 257 259 262 264 245 266 267 258 252 247 248 250
		f 3 365 366 367
		mu 0 3 268 269 270
		f 4 368 -343 369 -367
		mu 0 4 269 256 259 270
		f 5 -331 370 -336 371 -339
		mu 0 5 255 254 271 272 267
		f 8 372 -370 -357 373 374 375 -360 -372
		mu 0 8 272 270 259 257 251 249 258 267
		f 4 376 -368 -373 -335
		mu 0 4 273 268 270 272
		f 4 377 378 -332 -338
		mu 0 4 253 242 274 255;
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
connectAttr "planarTrimmedSurfaceShape2.iog" ":initialShadingGroup.dsm" -na;
// End of mesh_awesome.ma
