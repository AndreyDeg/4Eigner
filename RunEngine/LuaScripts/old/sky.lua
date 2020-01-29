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
	-- z=-1
	{0, 1, 2, {0,2},{1,2},{0,1}};
	{1, 3, 2, {1,2},{1,1},{0,1}};
	-- y=-1
	{0, 4, 1, {1,3},{2,3},{1,2}};
	{1, 4, 5, {1,2},{2,3},{2,2}};
	-- x = 1
	{1, 5, 3, {1,2},{2,2},{1,1}};
	{3, 5, 7, {1,1},{2,2},{2,1}};
	-- y = 1
	{2, 3, 6, {1,0}, {1,1}, {2,0}};
	{3, 7, 6, {1,1}, {2,1}, {2,0}};
	-- x = -1
	{0, 2, 4, {4,2},{4,1},{3,2}};
	{2, 6, 4, {4,1},{3,1},{3,2}};
	-- z = 1
	{4, 6, 5, {3,2},{3,1},{2,2}};
	{5, 6, 7, {2,2},{3,1},{2,1}};
};

CreateSky = function(map,texture,du,dv)

	local color = Color(255, 255, 255, 255);

	local size = 1;

	local vertex = setmetatable({}, {__index = table});
	for k, v in ipairs(Verges) do
		vertex:insert(Vertex(Points[v[1]+1][1]*size,Points[v[1]+1][2]*size,Points[v[1]+1][3]*size,color,v[4][1]/du,v[4][2]/dv));
		vertex:insert(Vertex(Points[v[2]+1][1]*size,Points[v[2]+1][2]*size,Points[v[2]+1][3]*size,color,v[5][1]/du,v[5][2]/dv));
		vertex:insert(Vertex(Points[v[3]+1][1]*size,Points[v[3]+1][2]*size,Points[v[3]+1][3]*size,color,v[6][1]/du,v[6][2]/dv));
	end;

	local model = Render:NewModel3D();
	model.ClearZBuf = true;
	model:SetVertices(ToListVertex(vertex));
	model:SetTexture(Render:LoadTexture(texture));

	map:AddSky(model);

	return model;
end;