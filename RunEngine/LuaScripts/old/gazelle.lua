local Points = {
	{0.0, 2.35, 0.2},	--0
	{0.5, 2.3, 0.2},
	{0.8, 2.2, 0.2},
	{1.0, 1.9, 0.2},
	{1.0, 1.9, 0.5},
	{0.8, 2.3, 0.5},
	{0.5, 2.4, 0.5},
	{0.0, 2.45, 0.5},
	{1.0, 1.75, 0.5},
	{1.0, 1.5, 0.6},
	{1.001, -2.1, 0.2},	--10
	{1.001, -2.1, 0.5},
	{1.001, -2.4, 0.5},
	{0.8, 2.3, 0.65},
	{0.8, 2.2, 0.8},
	{1.0, 1.6, 1.1},
	{0.0, 2.32, 0.8},
	{0.7, 2.15, 0.9},
	{0.5, 2.3, 0.8},
	{0.4, 2.4, 0.6},
	{0.7, 2.35, 0.6},	--20
	{0.8, -2.5, 1.1},
	{0.7, -2.5, 1.8},
	{0.1, -2.5, 1.8},
	{0.1, -2.5, 1.1},
	{0.9, -2.501, 0.5},
	{0.7, -2.501, 0.5},
	{0.7, -2.501, 0.2},
	{0.0, 1.95, 1.1},
	{0.0, 1.25, 1.8},
	{0.0, 1.0, 2.0},	--30
	{0.8, 0.9, 2.0},
	{0.8, 1.15, 1.8},
	{0.8, 1.8, 1.15},
	{0.9, -2.501, 0.2},
	{1.001, -2.4, 0.2},
	{0.9, 0.95, 1.8},
	{1.0, 1.25, 0.5},
	{0, 0.1, 2.0},
	{0.1, 0.0, 2.0},
	{1.0, 1.1, 0.2},	--40
	{0, -0.1, 2.0},
	{1.0, 0.4, 0.2},
	{0.9, -2.3, 1.8},
	{1.0, 0.4, 1.1},
	{0.9, 0.4, 1.8},
	{1.0, -2.4, 1.1},
	{0.9, -2.4, 1.8},
	{0.8, -2.4, 2.0},
	{0.0, -2.4, 2.0},
	{1.0, -2.3, 1.1},	--50
	{1.0, -0.9, 0.2},
	{1.0, -1.7, 0.2},
	{1.0, -2.4, 0.2},
	{1.0, -1.05, 0.5},
	{1.0, -1.3, 0.6},
	{1.0, -1.55, 0.5},
	{0.9, -1.9, 1.8},
	{0.9, -2.5, 0.2},
	{0.9, -2.5, 1.1},
	{0.8, -2.5, 1.8},	--60
	{0.0, -2.5, 1.8},
	{0.0, -2.5, 0.2},
	{1.0, 0.3, 1.102},
	{0.9, 0.3, 1.802},
	{0.9, -0.6, 1.802},
	{1.0, -0.6, 1.102},
	{1.0, -0.7, 1.102},
	{0.9, -0.7, 1.802},
	{0.9, -1.6, 1.802},
	{1.0, -1.6, 1.102},	--70
	{1.0, -1.7, 1.102},
	{0.9, -1.7, 1.802},
	{0.9, -2.3, 1.802},
	{1.0, -2.3, 1.102},
	{0.8, -2.501, 1.1},
	{0.7, -2.501, 1.8},
	{0.1, -2.501, 1.8},
	{0.1, -2.501, 1.1},
	{1.0, 0.3, 1.1},
	{0.9, 0.3, 1.8},	--80
	{0.9, -0.7, 1.8},
	{1.0, -0.7, 1.1},
	{1.0, -0.8, 1.1},
	{0.9, -0.8, 1.8},
	{0.9, -1.8, 1.8},
	{1.0, -1.8, 1.1},
	{1.0, -1.9, 1.1},
};
  
local Verges = {
	{0, 7, 6,		{1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}},
	{6, 1, 0,		{1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}},
	{1, 6, 5,		{1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}},
	{5, 2, 1,		{1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}},
	{2, 5, 4,		{1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}},
	{4, 3, 2,		{1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}},
	{3, 4, 8,		{1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}, {1, 0.2, 0.2, 0.2}},
	{4, 9, 8,		nil, nil, nil},
	{4, 5, 13,		nil, nil, nil},
	{4, 13, 15,		nil, nil, nil},
	{13, 14, 15,	nil, nil, nil},
	{4, 15, 9,		nil, nil, nil},
	{14, 33, 15,	nil, nil, nil},
	{14, 17, 33,	nil, nil, nil},
	{13, 20, 14,	{2, 2, 2, 1}, {2, 2, 2, 1}, {2, 2, 2, 1}},
	{14, 18, 17,	{2, 2, 2, 1}, {2, 2, 2, 1}, {2, 2, 2, 1}},
	{14, 20, 18,	{2, 2, 2, 1}, {2, 2, 2, 1}, {2, 2, 2, 1}},
	{18, 20, 19,	{2, 2, 2, 1}, {2, 2, 2, 1}, {2, 2, 2, 1}},
	{5, 20, 13,		nil, nil, nil},
	{5, 6, 20,		nil, nil, nil},
	{6, 19, 20,		nil, nil, nil},
	{6, 7, 19,		nil, nil, nil},
	{7, 18, 19,		nil, nil, nil},
	{7, 16, 18,		nil, nil, nil},
	{28, 33, 16,	nil, nil, nil},
	{17, 18, 33,	nil, nil, nil},
	{18, 16, 33,	nil, nil, nil},
	{15, 33, 32,	nil, nil, nil},
	{15, 32, 36,	nil, nil, nil},
	{29, 30, 31,	nil, nil, nil},
	{31, 32, 29,	nil, nil, nil},
	{37, 42, 40,	nil, nil, nil},
	{37, 44, 42,	nil, nil, nil},
	{42, 54, 51,	nil, nil, nil},
	{42, 44, 54,	nil, nil, nil},
	{9, 15, 37,		nil, nil, nil},
	{15, 44, 37,	nil, nil, nil},
	{31, 36, 32,	nil, nil, nil},
	{31, 45, 36,	nil, nil, nil},
	{31, 48, 45,	nil, nil, nil},
	{45, 48, 47,	nil, nil, nil},
	{30, 49, 31,	nil, nil, nil},
	{31, 49, 48,	nil, nil, nil},
	{44, 55, 54,	nil, nil, nil},
	{44, 46, 55,	nil, nil, nil},
	{46, 56, 55,	nil, nil, nil},
	{46, 53, 56,	nil, nil, nil},
	{52, 56, 53,	nil, nil, nil},
	{46, 58, 53,	nil, nil, nil},
	{46, 59, 58,	nil, nil, nil},
	{46, 47, 60,	nil, nil, nil},
	{46, 60, 59,	nil, nil, nil},
	{47, 48, 60,	nil, nil, nil},
	{48, 49, 61,	nil, nil, nil},
	{48, 61, 60,	nil, nil, nil},
	{58, 59, 21,	nil, nil, nil},
	{58, 21, 62,	nil, nil, nil},
	{59, 22, 21,	nil, nil, nil},
	{59, 60, 22,	nil, nil, nil},
	{60, 23, 22,	nil, nil, nil},
	{60, 61, 23,	nil, nil, nil},
	{61, 24, 23,	nil, nil, nil},
	{61, 62, 24,	nil, nil, nil},
	{62, 21, 24,	nil, nil, nil},
	{44, 45, 80,	nil, nil, nil},
	{44, 80, 79,	nil, nil, nil},
	{82, 81, 84,	nil, nil, nil},
	{82, 84, 83,	nil, nil, nil},
	{86, 85, 57,	nil, nil, nil},
	{86, 57, 87,	nil, nil, nil},
	{50, 43, 47,	nil, nil, nil},
	{50, 47, 46,	nil, nil, nil},
	{28, 29, 32,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{32, 33, 28,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{36, 45, 44,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{15, 36, 44,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{79, 80, 81,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{79, 81, 82,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{83, 84, 85,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{83, 85, 86,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{87, 57, 43,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{87, 43, 50,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{21, 22, 23,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
	{21, 23, 24,	{0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}, {0.2, 0.2, 0.2, 0.8}},
};

dofile 'LuaScripts\\old\\wheel.lua'

CreateGazelle = function(map, x, y, z, m)

	local RandColor = Color(255, math.random(256)-1, math.random(256)-1, math.random(256)-1);

	local CheckC = function(color)
		if color then
			return Color(color[1]*255,color[2]*255,color[3]*255,color[4]*255);
		else
			return RandColor;
		end;
	end;

	
	local points = setmetatable({}, {__index = table});
	for k, v in ipairs(Points) do
		points:insert(Vector( v[1], v[3], v[2]));
		points:insert(Vector(-v[1], v[3], v[2]));
	end;

	local indices = setmetatable({}, {__index = table});
	local vertex = setmetatable({}, {__index = table});
	for k, v in ipairs(Verges) do
		--indices:insert(v[1]*2+0);
		--indices:insert(v[2]*2+0);
		--indices:insert(v[3]*2+0);
		--indices:insert(v[1]*2+1);
		--indices:insert(v[2]*2+1);
		--indices:insert(v[3]*2+1);

		vertex:insert(Vertex(Points[v[1]+1][1],Points[v[1]+1][3],Points[v[1]+1][2],CheckC(v[4]),0,0));
		vertex:insert(Vertex(Points[v[2]+1][1],Points[v[2]+1][3],Points[v[2]+1][2],CheckC(v[5]),0,0));
		vertex:insert(Vertex(Points[v[3]+1][1],Points[v[3]+1][3],Points[v[3]+1][2],CheckC(v[6]),0,0));

		vertex:insert(Vertex(-Points[v[1]+1][1],Points[v[1]+1][3],Points[v[1]+1][2],CheckC(v[4]),0,0));
		vertex:insert(Vertex(-Points[v[2]+1][1],Points[v[2]+1][3],Points[v[2]+1][2],CheckC(v[5]),0,0));
		vertex:insert(Vertex(-Points[v[3]+1][1],Points[v[3]+1][3],Points[v[3]+1][2],CheckC(v[6]),0,0));
	end;

	local model = Render:NewModel3D();
	model:SetVertices(ToListVertex(vertex));
	
	local result = Object3D();
	--result.Actor = Physic:CreateBox(x, y, z, 1, m);
	result.Actor = Physic:CreateConvexMesh(ToListVector(points),ToListInt(indices), x, y, z, m);
	result.Model = model;

	map:AddObject(result);
	
	local wheel1 = CreateWheel(map,x+2.7/3,y+0.5/3,z+4.5/3,m/20,1, -1);
	local wheel2 = CreateWheel(map,x-2.7/3,y+0.5/3,z+4.5/3,m/20,1,  1);
	local wheel3 = CreateWheel(map,x+2.7/3,y+0.5/3,z-3.8/3,m/20,1, -1);
	local wheel4 = CreateWheel(map,x-2.7/3,y+0.5/3,z-3.8/3,m/20,1,  1);
		
	local join1 = Physic:CreateJoint(wheel1.Actor, result.Actor, Vector(x+2.7/3,y+0.5/3,z+4.5/3), Vector(-1,0,0));
	local join2 = Physic:CreateJoint(wheel2.Actor, result.Actor, Vector(x-2.7/3,y+0.5/3,z+4.5/3), Vector(-1,0,0));
	local join3 = Physic:CreateJoint(wheel3.Actor, result.Actor, Vector(x+2.7/3,y+0.5/3,z-3.8/3), Vector(-1,0,0));
	local join4 = Physic:CreateJoint(wheel4.Actor, result.Actor, Vector(x-2.7/3,y+0.5/3,z-3.8/3), Vector(-1,0,0));

	local drive = {
		Stop = function()
			join1:SetDrive(75, 0);
			join2:SetDrive(75, 0);
			join3:SetDrive(75, 0);
			join4:SetDrive(75, 0);
		end;
		Left = function()
			wheel1.Actor:Rotate(Vector(0,-math.pi/4,0));
			wheel2.Actor:Rotate(Vector(0,-math.pi/4,0));
		end;
		Forward = function()
			join1:SetDrive(75, 20);
			join2:SetDrive(75, 20);
			join3:SetDrive(75, 20);
			join4:SetDrive(75, 20);
		end;
		Right = function()
			wheel1.Actor:Rotate(Vector(0,math.pi/4,0));
			wheel2.Actor:Rotate(Vector(0,math.pi/4,0));
		end;
		Back = function()
			join1:SetDrive(75, -10);
			join2:SetDrive(75, -10);
			join3:SetDrive(75, -10);
			join4:SetDrive(75, -10);
		end;

	};
	
	return result, drive;
end;