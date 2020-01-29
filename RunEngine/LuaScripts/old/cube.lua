local Points = {
	{-1, -1, -1};
	{ 1, -1, -1};
	{-1,  1, -1};
	{ 1,  1, -1};
	{-1, -1,  1};
	{ 1, -1,  1};
	{-1,  1,  1};
	{ 1,  1,  1};
};

local Verges = {
	{0, 1, 2, nil, nil, nil};
	{1, 3, 2, nil, nil, nil};
	{0, 4, 1, nil, nil, nil};
	{1, 4, 5, nil, nil, nil};
	{1, 5, 3, nil, nil, nil};
	{3, 5, 7, nil, nil, nil};
	{2, 3, 6, nil, nil, nil};
	{3, 7, 6, nil, nil, nil};
	{0, 2, 4, nil, nil, nil};
	{2, 6, 4, nil, nil, nil};
	{4, 6, 5, nil, nil, nil};
	{5, 6, 7, nil, nil, nil};
};

CreateCube = function(map,x,y,z,size,m)

	local RandColor = Color(255, math.random(256)-1, math.random(256)-1, math.random(256)-1);
	
	if m < 1 then
		RandColor = Color(127, 127+math.random(128), 127+math.random(128), 127+math.random(128));
	end;

	local CheckC = function(color)
		if color then
			return Color(color[1]*255,color[2]*255,color[3]*255,color[4]*255);
		else
			return RandColor;
		end;
	end;

	local vertex = setmetatable({}, {__index = table});
	for k, v in ipairs(Verges) do
		vertex:insert(Vertex(Points[v[1]+1][1]*size,Points[v[1]+1][2]*size,Points[v[1]+1][3]*size,CheckC(v[4]),0,0));
		vertex:insert(Vertex(Points[v[2]+1][1]*size,Points[v[2]+1][2]*size,Points[v[2]+1][3]*size,CheckC(v[5]),0,0));
		vertex:insert(Vertex(Points[v[3]+1][1]*size,Points[v[3]+1][2]*size,Points[v[3]+1][3]*size,CheckC(v[6]),0,0));
	end;

	local result = Object3D();
	result.Actor = Physic:CreateBox(x, y, z, size, m);
	result.Model = Render:NewModel3D();
	result.Model:SetVertices(ToListVertex(vertex));

	map:AddObject(result);

	return result;
end;